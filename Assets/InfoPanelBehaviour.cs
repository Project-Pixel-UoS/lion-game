using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InfoPanelBehaviour : MonoBehaviour
{
    public int numInfoPages = 0;
    public int infoIndex = 0;
    public string[] infoMessages;

    public GameObject infoPanel;

    public Image[] infoImages;

    public TMP_Text infoTextBox;
    public Image infoImageBox;

    public void ShowInfo()
    {       infoPanel.SetActive(true);
        BeginInfo();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TweenShowInfo();
        BeginInfo();
    }

    void BeginInfo()
    {
        infoIndex = 0;
        UpdateInfoPanel();
    }

    public void AdvanceInfo()
    {
        if (infoIndex < numInfoPages - 1)
        {
            infoIndex++;
            UpdateInfoPanel();
        }

        if (infoIndex >= numInfoPages - 1)
        {
            TweenHideInfo();
        }
        
    }

    public void BackInfo()
    {
        if (infoIndex > 0)
        {
            infoIndex--;
        }
        UpdateInfoPanel();
    }

    void UpdateInfoPanel()
    {
        if (infoIndex < infoMessages.Length)
        {
            infoTextBox.text = infoMessages[infoIndex];
            if (infoIndex < infoImages.Length)
            {
                infoImageBox.sprite = infoImages[infoIndex].sprite;
            }
        }
    }

    void TweenShowInfo()
    {
        infoPanel.SetActive(true); // enable first so it can scale
        LeanTween.scale(infoPanel, Vector3.one, 0.5f)
            .setEaseOutBack();
    }

    void TweenHideInfo()
    {
        LeanTween.scale(infoPanel, Vector3.zero, 0.5f)
            .setEaseInBack()
            .setOnComplete(() => infoPanel.SetActive(false));
    }
}
