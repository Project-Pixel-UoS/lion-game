using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelCell : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private Button button;
    
    private int levelIndex;
    
    public void Setup(int index, bool isUnlocked)
    {
        levelIndex = index;
        levelText.text = index.ToString();
        button.interactable = isUnlocked;
        
        CanvasGroup group = GetComponent<CanvasGroup>();
        if (group != null)
        {
            group.alpha = isUnlocked ? 1f : 0.5f;
        }
    }

    public void OnClick()
    {
        if (levelIndex > 1) {
            Debug.Log("Level " + levelIndex + " clicked!");
        }
        else
        {
            // Check if save exists
            if (SaveSystem.SaveExists())
            {
                SaveSystem.SaveData data = SaveSystem.GetSaveData();
                Debug.Log("Save exists. Current saved level: " + data.gameStats.currentLevel);
                
                // Check if this level matches saved level
                if (data.gameStats.currentLevel == levelIndex)
                {
                    // Show popup instead of loading immediately
                    Debug.Log("Save exists for this level. Showing popup.");
                    return;
                }
            }

            if (GameStatsManager.Instance != null)
            {
                Debug.Log("Setting current saved level to: " + (levelIndex));
                GameStatsManager.Instance.currentLevel = levelIndex; // Set the current level in the GameStatsManager
            }            

            SceneManager.LoadScene("Level" + levelIndex);
        }
    }
}
