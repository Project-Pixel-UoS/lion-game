using UnityEngine;

/// <summary>
/// Holds data for a single character/enemy in the game.
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
    public int characterHealth;
    public float attackRange;
    public float attackSpeed;
    public int attackDamage;
    public string toughness; // To be confirmed for both enemy and lion
    
    //Added properties for shop (Lion Shop)
    public int price; 
    public bool isUnlocked; // Added to track if bought
    
    [Header("Description")]
    [TextArea(3, 10)]
    public string description;

    [Header("Category")]
    public CharacterType characterType;
}

/// <summary>
/// Defines the character type.
/// </summary>
public enum CharacterType
{
    Lion,
    Enemy
}