using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseDisplay : MonoBehaviour
{
    [SerializeField] GameObject pauseDisplay;
    public bool GameIsPaused = false;

    StarterAssetsInputs starterAssetsInputs;

    void Start()
    {
        starterAssetsInputs = FindFirstObjectByType<StarterAssetsInputs>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseDisplay.SetActive(false);
        Time.timeScale = 1f; // resume everything
        GameIsPaused = false;
        
        starterAssetsInputs.SetCursorState(true); // enable cursor lock state
    }

    void Pause()
    {
        starterAssetsInputs.SetCursorState(false); // Disable cursor lock state

        pauseDisplay.SetActive(true);
        Time.timeScale = 0f; // stop everything (physics, timeline, particles, animator, etc.)
        GameIsPaused = true;
    }
}
