using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using TMPro;

/// <summary>
/// Handles the logic of a deployment menu for selecting lions or energy items. 
/// This script should be attached to the parent GameObject of the buttons in the deployment menu,
/// and will spawn buttons based on the type of menu requested (Lion or Energy).
/// The items to be spawned in the menu should be assigned in the Inspector as lists of GameObjects (lionPrefabs and energyPrefabs).
/// When a button is clicked, it will pass the corresponding prefab to the PlacementManager for placement.
/// Lion buttons are filtered to only show lions the player has unlocked in the shop.
/// </summary>
/// <remarks>
/// Maintained by: Michael Edems-Eze
/// </remarks>
/// 
/// <todo> - 
/// Add image of the gameobject to the button as well, but this is a bit more complex 
/// <todo>
public class LionEnergyMenuLoader : MonoBehaviour
{
    public DeploymentMenuType menuTypeRequested; // The type of menu this loader should create (Lion or Energy)
    public GameObject buttonPrefab; // Prefab for the buttons to spawn in the menu
    // Lists of prefabs to spawn in the menu, assigned in the Inspector
    public List<GameObject> lionPrefabs;
    public List<GameObject> energyPrefabs;

    [Header("Empty State (optional)")]
    [Tooltip("Shown when the player has no lions unlocked yet.")]
    public GameObject noLionsMessage;

    void Start()
    {
        // Auto-populate lionPrefabs from Resources on startup,
        // replacing the manually assigned list with only unlocked lions.
        LoadUnlockedLionsFromResource();
        SpawnButtons(menuTypeRequested);
    }

    /// <summary>
    /// Load CharacterData from Resources/CharacterData/ and fills lionPrefabs
    /// with only the prefabs belonging to lions the player has unlocked.
    /// This runs once on Start - the manual Inspector list is overridden.
    /// </summary>
    void LoadUnlockedLionsFromResource()
    {
        CharacterData[] unlockedLions = Resources.LoadAll<CharacterData>("CharacterData")
            .Where(c => c.characterType == CharacterType.Lion && c.isUnlocked)
            .ToArray();

        lionPrefabs = unlockedLions
            .Where(c => c.lionPrefab != null)
            .Select(c => c.lionPrefab)
            .ToList();

        noLionsMessage?.SetActive(lionPrefabs.Count == 0);
    }

    // Spawns buttons in the menu based on the requested menu type and assigned prefabs
    void SpawnButtons(DeploymentMenuType type)
    {
        //Do nothing if there is no button prefab assigned, as we can't spawn buttons without it
        if (buttonPrefab == null)
        {
            Debug.LogWarning("LionEnergyMenuLoader: No buttonPrefab assigned.");
            return;
        }

        if (type == DeploymentMenuType.Lion)
        {
            foreach (GameObject lion in lionPrefabs)
            {
                GameObject buttonObj = Instantiate(buttonPrefab, transform);
                DeployLionButton button = buttonObj.GetComponent<DeployLionButton>();
                button.lionPrefab = lion;
                button.GetComponentInChildren<TMPro.TMP_Text>().text = lion.name; // Set button text to the name of the lion prefab

            }
        }
        else if (type == DeploymentMenuType.Energy)
        {
            foreach (GameObject energy in energyPrefabs)
            {
                GameObject buttonObj = Instantiate(buttonPrefab, transform);
                DeployLionButton button = buttonObj.GetComponent<DeployLionButton>();
                button.lionPrefab = energy;
                button.GetComponentInChildren<TMPro.TMP_Text>().text = energy.name; // Set button text to the name of the energy prefab
            }
        }
    }

    // Call this function to switch the menu type and spawn the corresponding buttons
    public void SwitchMenuType(DeploymentMenuType menuType)
    {
        menuTypeRequested = menuType;
        // Clear existing buttons before spawning new ones
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        SpawnButtons(menuTypeRequested);
    }

}