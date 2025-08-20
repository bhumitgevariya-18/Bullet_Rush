using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerEndless : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;

    int enemiesKilled = 0;

    const string SCORE = "Score: ";

    public void UpdateEnemiesKilled(int amount)
    {
        enemiesKilled += amount;
        scoreText.text = SCORE + enemiesKilled.ToString();
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
