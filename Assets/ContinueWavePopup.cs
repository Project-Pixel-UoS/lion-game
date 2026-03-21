using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueWavePopup : MonoBehaviour
{
    private int levelToLoad;

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
        var data = SaveSystem.GetSaveData();

        GameStatsManager.Instance.currentLevel = data.gameStats.currentLevel;

        SceneManager.LoadScene("GameScene");
    }

    public void NewGame()
    {
        GameStatsManager.Instance.currentLevel = levelToLoad;

        SceneManager.LoadScene("GameScene");
    }
}
