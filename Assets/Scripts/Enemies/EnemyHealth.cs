using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] GameObject explosionVFX;
    [SerializeField] int startingHealth = 3;

    int currentHealth;

    void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            SelfDestruct();
        }
    }

    public void SelfDestruct()
    {
        Instantiate(explosionVFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
