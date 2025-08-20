using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text enemiesLeftText;
    [SerializeField] GameObject winDisplay;

    PlayerHealth playerHealth;

    int enemiesLeft = 0;

    const string ENEMIES_LEFT_STRING = "Enemies Left: ";

    private void Start()
    {
        playerHealth = FindFirstObjectByType<PlayerHealth>();
    }

    public void UpdateEnemiesLeft(int amount)
    {
        enemiesLeft += amount;
        enemiesLeftText.text = ENEMIES_LEFT_STRING + enemiesLeft.ToString();

        if (enemiesLeft <= 0 && playerHealth.currentHealth > 1)
        {
            StarterAssetsInputs starterAssetsInputs = FindFirstObjectByType<StarterAssetsInputs>();
            starterAssetsInputs.SetCursorState(false); // Disable cursor lock state
            winDisplay.SetActive(true);
        }
    }

    public void RestartLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
     
    public void Quit()
    {
        Debug.LogWarning("It Does not work on Editor!!");
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Start Menu");
    }
}
