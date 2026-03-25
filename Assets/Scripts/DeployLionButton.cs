using UnityEngine;
using TMPro;

/// <summary>
/// This program stores the lion that is to be placed, and passes it to the Placement Manager when the SelectLion() function is called
/// </summary>
/// <remarks>
/// Maintained by: Michael Edems-Eze
/// </remarks>

public class DeployLionButton : MonoBehaviour
{
    public GameObject lionPrefab; //This stores the lion to be selected as a Gameobject
    public TextMeshProUGUI fruitCostWarningText; // Warning text if player doesn't have enough fruit
    private float timer;
    private float displayTime = 2.5f; // The time to display the warning text for

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > displayTime)
        {
            fruitCostWarningText.enabled = false;
        }
    }

    public void SelectLion() {
        timer = 0f;

        if (lionPrefab == null) //Do nothing if there is no stored Lion
        {
            Debug.LogWarning("DeployLionButton: No lionPrefab assigned.");
            return;
        }

        if (PlacementManager.Instance.fruit < lionPrefab.GetComponent<PlacementCost>().fruitCost)
        {
            Debug.Log("Not enough fruit!");
            fruitCostWarningText.enabled = true;
        }
        else
        {
            PlacementManager.Instance.SelectLion(lionPrefab); //Pass the stored lion into the Placement Manager
        }
    }
}
