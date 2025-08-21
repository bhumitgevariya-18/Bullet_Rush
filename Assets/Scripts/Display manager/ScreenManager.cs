using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    [SerializeField] GameObject infoDisplay;
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

    public void InfoDisplay()
    {
        if (infoDisplay != null)
        {
            infoDisplay.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Info Display Canvas is not assigned!");
        }
    }

    public void CloseInfoDisplayOnAgree()
    {
        if (infoDisplay != null)
        {
            infoDisplay.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Info Display Canvas is not assigned!");
        }
    }
}
