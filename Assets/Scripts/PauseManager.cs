using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    // The panel object which contains the pause menu UI
    [SerializeField] private GameObject pauseUI; 

    public static bool isPaused { get; private set; }

    void Start()
    {
        // Make the pause menu invisible to begin with
        SetPaused(false);
    }

    void Update()
    {
    }

    public void Resume()
    {
        SetPaused(false);
    }

    public void Pause()
    {
        SetPaused(true);
    }

    private void SetPaused(bool paused)
    {
        isPaused = paused;

        if (pauseUI) pauseUI.SetActive(paused);

        // Code goes here for pausing the gameplay.

        // Freeze time
        // Time.timeScale = paused ? 0f : 1f;
    }

    // Possible restart button.
    // public void RestartScene()
    // {
        // SetPaused(false);
        // Restart the level
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    // }

    public void LoadMainMenu(string sceneName)
    {
        SetPaused(false);
        SceneManager.LoadScene(sceneName);
    }
}
