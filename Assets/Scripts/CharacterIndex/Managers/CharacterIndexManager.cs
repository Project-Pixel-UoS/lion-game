using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages the character index grid, spawning character cards dynamically.
/// Automatically loads all CharacterData assets from Resources/CharacterData.
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

    [Header("Category Buttons")]
    [SerializeField] private UnityEngine.UI.Button lionButton;
    [SerializeField] private UnityEngine.UI.Button enemyButton;

    private CharacterData[] allCharacters;
    private CharacterType currentCategory = CharacterType.Lion;

    private void Start()
    {
        allCharacters = Resources.LoadAll<CharacterData>("CharacterData");

        if (allCharacters.Length == 0)
        {
            Debug.LogWarning("No CharacterData assets found in Resources/CharacterData!");
        }

        lionButton.onClick.AddListener(() => ShowCategory(CharacterType.Lion));
        enemyButton.onClick.AddListener(() => ShowCategory(CharacterType.Enemy));

        ShowCategory(CharacterType.Lion);
    }

    /// <summary>
    /// Shows characters of a specific category.
    /// </summary>
    /// <param name="category">The character type to display.</param>
    private void ShowCategory(CharacterType category)
    {
        currentCategory = category;

        titleText.text = category == CharacterType.Lion ? "Lion Index" : "Enemy Index";

        lionButton.gameObject.SetActive(category != CharacterType.Lion);
        enemyButton.gameObject.SetActive(category != CharacterType.Enemy);

        ClearCards();
        SpawnCharacterCards(category);
    }

    /// <summary>
    /// Clears all existing character cards from the grid.
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
            if (character.characterType != category) continue;

            GameObject cardObject = Instantiate(characterCardPrefab, contentParent);
            CharacterCard card = cardObject.GetComponent<CharacterCard>();

            if (card != null)
            {
                card.Setup(character, detailPanel);
            }
        }
    }

    /// <summary>
    /// Exits to main menu.
    /// </summary>
    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}