using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueWavePopup : MonoBehaviour
{
    public int levelToLoad;

    public void Show(int level)
    {
        levelToLoad = level;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void ContinueGame()
    {
        // Set flag so the next scene knows to load from save
        SaveSystem.LoadRequested = true;
        if (GameStatsManager.Instance != null)
        {
            GameStatsManager.Instance.currentLevel = levelToLoad;
        }

        // Load the correct level scene (same pattern as NewGame)
        SceneManager.LoadScene("Level" + levelToLoad);
    }

    public void NewGame()
    {      
        SaveSystem.LoadRequested = false; // Ensure we start fresh without loading saved data
        if (GameStatsManager.Instance != null)
        {
            GameStatsManager.Instance.currentLevel = levelToLoad;            
            GameStatsManager.Instance.ResetStats();
        }
        SceneManager.LoadScene("Level" + levelToLoad);
    }
}
