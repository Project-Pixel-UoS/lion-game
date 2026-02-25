using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
        Debug.Log("Level " + levelIndex + " clicked!");
    }
}
