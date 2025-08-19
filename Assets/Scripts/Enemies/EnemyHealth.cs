using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] GameObject explosionVFX;
    [SerializeField] int startingHealth = 3;

    int currentHealth;

    GameManager gameManager;

    void Awake()
    {
        currentHealth = startingHealth;
    }

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        gameManager.UpdateEnemiesLeft(1); // one enemy has spawned
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            gameManager.UpdateEnemiesLeft(-1); // one enemy has been dsestroyed
            SelfDestruct();
        }
    }

    public void SelfDestruct()
    {
        Instantiate(explosionVFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
