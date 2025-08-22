using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class EndlessEnemyManager : MonoBehaviour
{
    public enum SpawnSpace { World, Local }

    [Tooltip("Layers that contain enemies (e.g., Enemy, EnemyTurret).")]
    [SerializeField] private LayerMask enemyLayers;

    [SerializeField] private float respawnDelay = 5f;
    [Tooltip("Use World to preserve exact world position/rotation; Local to preserve transform relative to parent.")]
    [SerializeField] private SpawnSpace spawnSpace = SpawnSpace.World;

    private List<SpawnSlot> slots = new List<SpawnSlot>();

    private GameObject[] activeEnemies;

    [System.Serializable]
    private class SpawnSlot
    {
        public Transform parent;

        public Vector3 worldPos;
        public Quaternion worldRot;

        public Vector3 localPos;
        public Quaternion localRot;

        public GameObject prefab;
        public bool canRespawn; 
    }

    void Start()
    {
        GameObject[] all = Object.FindObjectsByType<GameObject>(FindObjectsSortMode.None);
        List<GameObject> sceneEnemies = new List<GameObject>();

        foreach (var go in all)
        {
            if (IsInLayerMask(go.layer, enemyLayers))
            {
                if (go.TryGetComponent<EnemyHealthEndless>(out var eh))
                {
                    sceneEnemies.Add(go);
                }
            }
        }

        activeEnemies = new GameObject[sceneEnemies.Count];

        for (int i = 0; i < sceneEnemies.Count; i++)
        {
            var go = sceneEnemies[i];
            var t = go.transform;
            var eh = go.GetComponent<EnemyHealthEndless>();

            // Warn if no respawn prefab set
            if (eh.RespawnPrefab == null)
            {
                Debug.LogWarning($"[EndlessEnemyManager] '{go.name}' has no Respawn Prefab set. " +
                                 "Assign a prefab in EnemyHealthEndless to ensure correct respawn.");
            }

            var slot = new SpawnSlot
            {
                parent = t.parent,
                worldPos = t.position,
                worldRot = t.rotation,
                localPos = t.localPosition,
                localRot = t.localRotation,
                prefab = eh.RespawnPrefab != null ? eh.RespawnPrefab : go, // fallback (editor-only safe)
                canRespawn = eh.CanRespawn
            };

            slots.Add(slot);
            activeEnemies[i] = go;

            eh.enemyIndex = i;
        }
    }

    public void RespawnEnemy(int index)
    {
        if(index < 0 || index >= slots.Count) return;

        if(!slots[index].canRespawn) return;

        if (!slots[index].prefab.CompareTag("Tower"))
        {
            StartCoroutine(RespawnAfterDelay(index));
        }
            
    }

    private IEnumerator RespawnAfterDelay(int index)
    {
        yield return new WaitForSeconds(respawnDelay);

        var slot = slots[index];

        GameObject inst;

        if (spawnSpace == SpawnSpace.World)
        {
            inst = Instantiate(slot.prefab, slot.worldPos, slot.worldRot);

            if (slot.parent != null)
            {
                inst.transform.SetParent(slot.parent, true);
            }
        }
        else
        {
            inst = Instantiate(slot.prefab, slot.parent);
            inst.transform.localPosition = slot.localPos;
            inst.transform.localRotation = slot.localRot;
        }

        if (inst.TryGetComponent<EnemyHealthEndless>(out var eh))
        {
            eh.enemyIndex = index; 
        }
        else
        {
            Debug.LogWarning($"[EndlessEnemyManager] Respawned object at slot {index} has no EnemyHealthEndless.");
        }

        activeEnemies[index] = inst;
    }

    private static bool IsInLayerMask(int layer, LayerMask mask)
    {
        return (mask.value & (1 << layer)) != 0;
    }
}
