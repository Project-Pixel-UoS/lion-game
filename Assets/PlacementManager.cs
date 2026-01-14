using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    public static PlacementManager Instance;

    public GameObject selectedLion;
    public bool isPlacing;

    void Awake()
    {
        Instance = this;
    }

    public void SelectLion(GameObject lion)
    {
        selectedLion = lion;
        isPlacing = true;
    }

    public void Cancel()
    {
        selectedLion = null;
        isPlacing = false;
    }

    public void Place(PlacementTile tile)
    {
        if (!isPlacing || tile.occupied) return;

        Instantiate(selectedLion, tile.transform.position, Quaternion.identity);
        tile.occupied = true;

        Cancel();
    }
}
