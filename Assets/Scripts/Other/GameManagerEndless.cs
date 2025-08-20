using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerEndless : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;

    PlayerHealth playerHealth;

    int enemiesKilled = 0;

    private void Start()
    {
        playerHealth = FindFirstObjectByType<PlayerHealth>();
    }

    public void UpdateEnemiesKilled(int amount)
    {
        enemiesKilled += amount;
        scoreText.text = enemiesKilled.ToString();
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
