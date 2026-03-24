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

        // Load the correct level scene (same pattern as NewGame)
        SceneManager.LoadScene("Level" + levelToLoad);
    }

    public void NewGame()
    {       
        //GameStatsManager.Instance.currentLevel = levelToLoad;
        SceneManager.LoadScene("Level" + levelToLoad);
    }
}
