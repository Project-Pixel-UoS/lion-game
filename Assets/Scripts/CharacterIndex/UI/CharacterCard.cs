using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Represents a single character card in the index grid.
/// </summary>
/// <remarks>
/// Maintained by: Dayini
/// </remarks>
public class CharacterCard : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Image characterImage;
    [SerializeField] private Button button;

    private CharacterData characterData;
    private CharacterDetailPanel detailPanel;

    /// <summary>
    /// Initializes the card with character data.
    /// </summary>
    /// <param name="data">The character data to display.</param>
    /// <param name="panel">Reference to the detail panel.</param>
    public void Setup(CharacterData data, CharacterDetailPanel panel)
    {
        characterData = data;
        detailPanel = panel;

        // Set the character sprite
        if (data.characterSprite != null)
        {
            characterImage.sprite = data.characterSprite;
        }

        // Add click listener
        button.onClick.AddListener(OnCardClicked);
    }

    /// <summary>
    /// Handles card click event.
    /// </summary>
    private void OnCardClicked()
    {
        Debug.Log("Card clicked! Character: " + characterData.characterName);

        if (detailPanel != null)
        {
            Debug.Log("Opening detail panel!");
            detailPanel.ShowCharacter(characterData);
        }
        else
        {
            Debug.LogError("Detail panel reference is null!");
        }
    }
}