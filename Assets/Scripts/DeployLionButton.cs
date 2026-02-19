using UnityEngine;

/// <summary>
/// This program stores the lion that is to be placed, and passes it to the Placement Manager when the SelectLion() function is called
/// </summary>
/// <remarks>
/// Maintained by: Michael Edems-Eze
/// </remarks>

public class DeployLionButton : MonoBehaviour
{
    public GameObject lionPrefab; //This stores the lion to be selected as a Gameobject

    public void SelectLion() {

        if (lionPrefab == null) //Do nothing if there is no stored Lion
        {
            Debug.LogWarning("DeployLionButton: No lionPrefab assigned.");
            return;
        }

        PlacementManager.Instance.SelectLion(lionPrefab); //Pass the stored lion into the Placement Manager
    }
}
