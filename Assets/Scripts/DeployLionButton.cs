using UnityEngine;

public class DeployLionButton : MonoBehaviour
{
    public GameObject lionPrefab;

    public void SelectLion() {

        if (lionPrefab == null)
        {
            Debug.LogWarning("DeployLionButton: No lionPrefab assigned.");
            return;
        }

        PlacementManager.Instance.SelectLion(lionPrefab);
    }
}
