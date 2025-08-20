using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    public void LevelMode()
    {
        SceneManager.LoadScene("Level Scene");
    }

    public void EndlessMode()
    {
        SceneManager.LoadScene("Endless Scene");
    }

    public void Quit()
    {
        Debug.LogWarning("It Does not work on Editor!!");
        Application.Quit();
    }
}
