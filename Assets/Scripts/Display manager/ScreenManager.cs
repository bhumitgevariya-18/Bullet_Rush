using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    public void LevelMode()
    {
        Time.timeScale = 1f; // Ensure time scale is reset in case it was paused
        SceneManager.LoadScene("Level Scene");
    }

    public void EndlessMode()
    {
        Time.timeScale = 1f; // Ensure time scale is reset in case it was paused
        SceneManager.LoadScene("Endless Scene");
    }

    public void Quit()
    {
        Debug.LogWarning("It Does not work on Editor!!");
        Application.Quit();
    }
}
