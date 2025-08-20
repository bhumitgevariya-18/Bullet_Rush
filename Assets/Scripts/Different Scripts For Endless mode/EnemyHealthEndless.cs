using UnityEngine;

public class EnemyHealthEndless : MonoBehaviour
{
    [SerializeField] GameObject explosionVFX;
    [SerializeField] int startingHealth = 3;

    [SerializeField] GameObject respawnPrefab;
    [SerializeField] bool canRespawn = true;

    int currentHealth;

    public int enemyIndex; // Index of the enemy in the EndlessEnemyManager

    GameManagerEndless gameManagerEndless;

    EndlessEnemyManager endlessEnemyManager;

    public GameObject RespawnPrefab => respawnPrefab;
    public bool CanRespawn => canRespawn;

    void OnEnable()
    {
        currentHealth = startingHealth; // Reset health when the enemy is spawned
    }

    void Start()
    {
        gameManagerEndless = FindFirstObjectByType<GameManagerEndless>();
        endlessEnemyManager = FindFirstObjectByType<EndlessEnemyManager>();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            gameManagerEndless.UpdateEnemiesKilled(1); // one enemy has been dsestroyed
            SelfDestruct();
        }
    }

    public void SelfDestruct()
    {
        if(explosionVFX != null)
        {
            Instantiate(explosionVFX, transform.position, Quaternion.identity);
        }

        if (!CompareTag("RobotEnemy"))
        {
            endlessEnemyManager.RespawnEnemy(enemyIndex); // Respawn the enemy after destruction
        }

        Destroy(gameObject);
    }
}
