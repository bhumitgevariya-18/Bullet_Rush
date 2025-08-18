using UnityEngine;
using Cinemachine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int startingHealth = 5;
    [SerializeField] CinemachineVirtualCamera deathvirtualCamera;
    [SerializeField] Transform weaponCamera;

    int currentHealth;
    int gameOverVirtualCameraPriority = 20;

    void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log(amount + " damage taken");

        if (currentHealth <= 0)
        {
            weaponCamera.parent = null; // Unparent the weapon camera
            deathvirtualCamera.Priority = gameOverVirtualCameraPriority; // Set the death camera priority higher so that it can switch to it
            Destroy(this.gameObject);
        }
    }
}
