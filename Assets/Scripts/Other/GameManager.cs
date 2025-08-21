using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text enemiesLeftText;

    PauseDisplay pauseDisplay;

    PlayerHealth playerHealth;

    int enemiesLeft = 0;

    const string ENEMIES_LEFT_STRING = "Enemies Left: ";

    private void Start()
    {
        playerHealth = FindFirstObjectByType<PlayerHealth>();
        pauseDisplay = FindFirstObjectByType<PauseDisplay>();
    }

    public void UpdateEnemiesLeft(int amount)
    {
        enemiesLeft += amount;
        enemiesLeftText.text = ENEMIES_LEFT_STRING + enemiesLeft.ToString();

        if (enemiesLeft <= 0 && playerHealth.currentHealth > 1)
        {
            playerHealth.GameFinished();
        }
    }

    public void RestartLevel()
    {
        pauseDisplay.Resume(); // Ensure the game is resumed before restarting

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
