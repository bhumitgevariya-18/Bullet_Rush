using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
using StarterAssets;

public class PlayerHealth : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] int startingHealth = 10;
    [SerializeField] CinemachineVirtualCamera deathvirtualCamera;
    [SerializeField] Transform weaponCamera;
    [SerializeField] Image[] shieldBars; // UI shield bars to represent health of shield
    [SerializeField] GameObject gameOverDisplay;
    [SerializeField] GameObject winDisplay;

    public int currentHealth;
    int gameOverVirtualCameraPriority = 20;

    void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        ManageHealthUI();

        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        weaponCamera.parent = null; // Unparent the weapon camera
        deathvirtualCamera.Priority = gameOverVirtualCameraPriority; // Set the death camera priority higher so that it can switch to it
        gameOverDisplay.SetActive(true); // Show the game over display
        StarterAssetsInputs starterAssetsInputs = FindFirstObjectByType<StarterAssetsInputs>();
        starterAssetsInputs.SetCursorState(false); // Disable cursor lock state
        Destroy(this.gameObject);
    }

    public void GameFinished()
    {
        if (!winDisplay) return; // If win display is not set, do nothing (for endless mode)
        weaponCamera.parent = null; // Unparent the weapon camera
        deathvirtualCamera.Priority = gameOverVirtualCameraPriority; // Set the death camera priority higher so that it can switch to it
        winDisplay.SetActive(true); // Show the game over display
        StarterAssetsInputs starterAssetsInputs = FindFirstObjectByType<StarterAssetsInputs>();
        starterAssetsInputs.SetCursorState(false); // Disable cursor lock state
        Destroy(this.gameObject);
    }

    void ManageHealthUI()
    {
        for (int i = 0; i < shieldBars.Length; i++)
        {
            if (i < currentHealth)
            {
                shieldBars[i].enabled = true; // Enable the shield bar
            }
            else
            {
                shieldBars[i].enabled = false; // Disable the shield bar
            }
        }
    }

    public void AddHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth > startingHealth)
        {
            currentHealth = startingHealth; // Cap health at starting health
        }
        ManageHealthUI();
    }
}
