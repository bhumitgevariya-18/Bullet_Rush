using UnityEngine;

public class EnemyHealthEndless : MonoBehaviour
{
    [SerializeField] GameObject explosionVFX;
    [SerializeField] int startingHealth = 3;

    int currentHealth;

    public int enemyIndex; // Index of the enemy in the EndlessEnemyManager

    GameManagerEndless gameManagerEndless;

    EndlessEnemyManager endlessEnemyManager;

    void Awake()
    {
        currentHealth = startingHealth;
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
        Instantiate(explosionVFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        if (!this.gameObject.CompareTag("RobotEnemy"))
        {
            endlessEnemyManager.RespawnEnemy(enemyIndex);
        }
    }
}
