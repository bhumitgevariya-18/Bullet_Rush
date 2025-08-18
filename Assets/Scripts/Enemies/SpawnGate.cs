using System.Collections;
using UnityEngine;

public class SpawnGate : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab; // Prefab of the enemy to spawn
    [SerializeField] float spawnDelay = 5f; // Time interval between spawns
    [SerializeField] Transform spawnPoint; // Point where the enemy will spawn

    PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = FindFirstObjectByType<PlayerHealth>();
        StartCoroutine(SpawnCoRoutine());
    }
    IEnumerator SpawnCoRoutine()
    {
        while(playerHealth)
        {
            Instantiate(enemyPrefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
