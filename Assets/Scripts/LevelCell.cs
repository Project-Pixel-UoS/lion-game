using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

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
            if (SaveSystem.SaveExists())
            {
                SaveSystem.SaveData data = SaveSystem.GetSaveData();
                Debug.Log("Save exists. Current saved level: " + data.gameStats.currentLevel);
                
                if (data.gameStats.currentLevel == levelIndex)
                {
                    Debug.Log("Save exists for this level. Showing popup.");
                    
                    GameObject popup = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(go => go.name == "ContinuePopupPanel" && go.scene.isLoaded);popup.SetActive(true);
                    popup.SetActive(true);

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
