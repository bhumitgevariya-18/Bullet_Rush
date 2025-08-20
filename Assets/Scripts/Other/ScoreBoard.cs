using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;

    const string SCORE = "Score: ";

    EnemyHealth enemyHealth;

    private void Start()
    {
        enemyHealth = FindFirstObjectByType<EnemyHealth>();
    }

    private void Update()
    {
        ManageScore();
    }

    void ManageScore()
    {
        scoreText.text = SCORE + enemyHealth.score.ToString();
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
