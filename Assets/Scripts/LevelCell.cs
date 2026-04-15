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
            SceneManager.LoadScene("Level" + levelIndex);
        }
    }
}
