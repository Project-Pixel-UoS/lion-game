using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class LionEnergyMenuLoader : MonoBehaviour
{
    public DeploymentMenuType menuTypeRequested; // The type of menu this loader should create (Lion or Energy)
    public GameObject buttonPrefab; // Prefab for the buttons to spawn in the menu
    public List<GameObject> lionPrefabs;
    public List<GameObject> energyPrefabs;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void SpawnButtons(DeploymentMenuType type)
    {
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
            }
        }
        else if (type == DeploymentMenuType.Energy)
        {
            foreach (GameObject energy in energyPrefabs)
            {
                GameObject buttonObj = Instantiate(buttonPrefab, transform);
                DeployLionButton button = buttonObj.GetComponent<DeployLionButton>();
                button.lionPrefab = energy;
            }
        }
    }
    
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