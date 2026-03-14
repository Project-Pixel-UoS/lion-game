using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class LionEnergyMenuLoader : MonoBehaviour
{
    public GameObject buttonPrefab; // Prefab for the buttons to spawn in the menu
    public List<GameObject> lionPrefabs;
    public List<GameObject> energyPrefabs;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnButtons();
    }

    void SpawnButtons()
    {
        foreach (GameObject lion in lionPrefabs)
        {
            GameObject buttonObj = Instantiate(buttonPrefab, transform);
            DeployLionButton button = buttonObj.GetComponent<DeployLionButton>();
            button.lionPrefab = lion;
        }
    }
}
