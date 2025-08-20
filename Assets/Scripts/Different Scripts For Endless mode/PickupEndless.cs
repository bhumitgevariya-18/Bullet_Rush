using UnityEngine;
using System.Collections;

public abstract class PickupEndless : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 100f;
    [SerializeField] float respawnDelay = 10f;   // ⏳ Time before pickup reappears

    const string PLAYER_STRING = "Player";
    const string HEALTH_PICKUP_STRING = "HealthPickup";

    private Collider col;
    private Renderer[] renderers;

    void Awake()
    {
        col = GetComponent<Collider>();
        renderers = GetComponentsInChildren<Renderer>(); // get all renderers (model, particles etc.)
    }

    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER_STRING))
        {
            if (this.CompareTag(HEALTH_PICKUP_STRING))
            {
                PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
                OnHealthPickup(playerHealth);
                StartCoroutine(RespawnRoutine());
                return;
            }

            ActiveWeaponEndless activeWeaponEndless = other.GetComponentInChildren<ActiveWeaponEndless>();
            OnPickup(activeWeaponEndless);
            StartCoroutine(RespawnRoutine());
        }
    }

    private IEnumerator RespawnRoutine()
    {
        col.enabled = false;
        foreach (Renderer r in renderers)
            r.enabled = false;

        yield return new WaitForSeconds(respawnDelay);

        // Show pickup again
        col.enabled = true;
        foreach (Renderer r in renderers)
            r.enabled = true;
    }

    protected abstract void OnPickup(ActiveWeaponEndless activeWeaponEndless);
    protected abstract void OnHealthPickup(PlayerHealth playerHealth);
}
