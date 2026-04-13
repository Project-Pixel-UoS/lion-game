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

    [Header("Stats")]
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI attackRangeText;
    [SerializeField] private TextMeshProUGUI attackSpeedText;
    [SerializeField] private TextMeshProUGUI attackDamageText;

    [Header("Input Blocking")]
    [SerializeField] private GameObject inputBlocker;

    private void Start()
    {
        // Add close button listener
        closeButton.onClick.AddListener(HidePanel);

        // Hide panel on start
        gameObject.SetActive(false);
        inputBlocker.SetActive(false);
    }

    /// <summary>
    /// Displays character information in the panel.
    /// </summary>
    /// <param name="data">The character data to display.</param>
    public void ShowCharacter(CharacterData data)
    {
        nameText.text = data.characterName;
        descriptionText.text = $"Toughness: {data.toughness}\n\n{data.description}";

        healthText.text = $"Health: {data.characterHealth}";
        attackRangeText.text = $"Attack Range: {data.attackRange} m";
        attackSpeedText.text = $"Attack Speed: {data.attackSpeed} /s";
        attackDamageText.text = $"Attack Damage: {data.attackDamage}";

        if (data.characterSprite != null)
        {
            characterImage.sprite = data.characterSprite;
        }

        inputBlocker.SetActive(true);
        gameObject.SetActive(true);
    }

    /// <summary>
    /// Hides the detail panel.
    /// </summary>
    private void HidePanel()
    {
        Debug.Log("Close detail panel");
        inputBlocker.SetActive(false);
        gameObject.SetActive(false);
    }
}