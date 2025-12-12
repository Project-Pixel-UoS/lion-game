using UnityEngine;
using TMPro;

/// <summary>
/// Manages the character index grid, spawning character cards dynamically.
/// </summary>
/// <remarks>
/// Maintained by: Dayini
/// </remarks>
public class CharacterIndexManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform contentParent;
    [SerializeField] private GameObject characterCardPrefab;
    [SerializeField] private CharacterDetailPanel detailPanel;
    [SerializeField] private TextMeshProUGUI titleText;

    [Header("Character Data")]
    [SerializeField] private CharacterData[] allCharacters;

    [Header("Category Buttons")]
    [SerializeField] private UnityEngine.UI.Button lionButton;
    [SerializeField] private UnityEngine.UI.Button enemyButton;

    private CharacterType currentCategory = CharacterType.Lion;

    private void Start()
    {
        // Setup button listeners
        lionButton.onClick.AddListener(() => ShowCategory(CharacterType.Lion));
        enemyButton.onClick.AddListener(() => ShowCategory(CharacterType.Enemy));

        // Show Lions by default
        ShowCategory(CharacterType.Lion);
    }

    /// <summary>
    /// Shows characters of a specific category.
    /// </summary>
    /// <param name="category">The character type to display.</param>
    private void ShowCategory(CharacterType category)
    {
        currentCategory = category;

        // Update title
        titleText.text = category == CharacterType.Lion ? "Lion Index" : "Enemy Index";

        // Clear existing cards
        ClearCards();

        // Spawn cards for selected category
        SpawnCharacterCards(category);
    }

    /// <summary>
    /// Clears all existing character cards.
    /// </summary>
    private void ClearCards()
    {
        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }
    }

    /// <summary>
    /// Spawns character cards filtered by category.
    /// </summary>
    /// <param name="category">The character type to filter by.</param>
    private void SpawnCharacterCards(CharacterType category)
    {
        foreach (CharacterData character in allCharacters)
        {
            // Only spawn cards matching the selected category
            if (character.characterType != category)
                continue;

            // Instantiate the card
            GameObject cardObject = Instantiate(characterCardPrefab, contentParent);

            // Setup the card with data and panel reference
            CharacterCard card = cardObject.GetComponent<CharacterCard>();
            if (card != null)
            {
                card.Setup(character, detailPanel);
            }
        }
    }
}