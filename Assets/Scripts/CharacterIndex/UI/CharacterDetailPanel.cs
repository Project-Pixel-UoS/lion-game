using UnityEngine;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// Manages the character detail popup panel.
/// </summary>
/// <remarks>
/// Maintained by: Dayini
/// </remarks>
public class CharacterDetailPanel : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Image characterImage;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private Button closeButton;

    private void Start()
    {
        // Add close button listener
        closeButton.onClick.AddListener(HidePanel);

        // Hide panel on start
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Displays character information in the panel.
    /// </summary>
    /// <param name="data">The character data to display.</param>
    public void ShowCharacter(CharacterData data)
    {
        nameText.text = data.characterName;
        descriptionText.text = $"Toughness: {data.toughness}\n\n{data.description}";

        if (data.characterSprite != null)
        {
            characterImage.sprite = data.characterSprite;
        }

        gameObject.SetActive(true);
    }

    /// <summary>
    /// Hides the detail panel.
    /// </summary>
    private void HidePanel()
    {
        Debug.Log("Close detail panel");
        gameObject.SetActive(false);
    }
}