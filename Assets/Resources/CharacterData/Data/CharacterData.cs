using UnityEngine;

/// <summary>
/// Holds data for a single character/enemy in the game.
/// For lions, also stores the prefab to spawn when placed and shop unlock state.
/// </summary>
/// <remarks>
/// Maintained by: Dayini
/// </remarks>

[CreateAssetMenu(fileName = "New Character", menuName = "Lion Game/Character Data")]
public class CharacterData : ScriptableObject
{
    [Header("Basic Info")]
    public string characterName;
    public Sprite characterSprite;

    [Header("Stats")]
    public string toughness; // To be confirmed for both enemy and lion

    [Header("Description")]
    [TextArea(3, 10)]
    public string description;

    [Header("Category")]
    public CharacterType characterType;

    [Header("Shop & Placement (Lions only)")]
    [Tooltip("The prefab that gets placed on a tile when this lion is deployed.")]
    public GameObject lionPrefab;

    [Tooltip("Cost in permanent currency to unlock in the shop.")]
    public int price;

    /// <summary>
    /// Whether this lion has been purchased in the shop.
    /// Saved to PLayerPrefs so it persists across game sessions.
    /// Key is unique per asset name so each lion has its own save lot.
    /// </summary>
    public tool isUnlocked
    {
        get => PlayerPrefs.GetInt($"Unlocked_{name}", 0) == 1;
        set
        {
            PlayerPrefs.SetInt($"Unlocked_{name}", value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }

}

/// <summary>
/// Defines the character type.
/// </summary>
public enum CharacterType
{
    Lion,
    Enemy
}