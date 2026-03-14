using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Handles the logic of a placement tile. A Tile waits for itself to be clicked, then changes colour (and maybe sprite for later?) to visualise the change.
/// It also stores information on if it is occupied or not, so that it can't hold more than one lion at a time.
/// </summary>
/// <remarks>
/// Maintained by: Michael Edems-Eze
/// </remarks>

/// <todo>
/// The logic for visualising a lion on a tile needs to be updated, because right now it is quite ugly
/// </todo>
// This script represents a single tile that can hold/place an object.
// It handles visual feedback (color change) and click interaction.

public class PlacementTile : MonoBehaviour, IPointerClickHandler
{
    // True if something is already placed on this tile
    public bool occupied;
    public DeploymentMenuType tileType; // The type of deployment this tile accepts (Lion or Energy)

    // Reference to the SpriteRenderer so we can change tile color
    public SpriteRenderer sr;

    // Default color when tile is not available
    public Color normal = Color.black;

    // Highlight color when tile is available for placement
    public Color highlight = Color.green;

    // Optional visual object used to preview placement
    public GameObject testVisual;

    [SerializeField] private Collider2D tileCollider; // Collider for detecting clicks
    
    void Start()
    {
        // If no SpriteRenderer is assigned in the Inspector,
        // try to automatically grab it from this GameObject.
        if (sr == null)
        {
            sr = GetComponent<SpriteRenderer>();
        }

        // Set the initial color of the tile
        sr.color = normal; 

        tileCollider = GetComponent<Collider2D>();
        if (tileCollider == null) {
            Debug.LogWarning("PlacementTile: No Collider2D found on the tile. Click detection will not work.");
        }
        tileCollider.enabled = true; // Ensure the collider is enabled at the start
    }

    void Update()
    {
        // A tile can be used if it's not occupied
        bool canPlace = !occupied;

        // Change tile color depending on whether it can be used
        // Green = available
        // Black = occupied
        sr.color = canPlace ? highlight : normal;

        if (!occupied) {
            tileCollider.enabled = true; // Enable collider if tile is available
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Tile clicked!");

        if (occupied) return;
        if (testVisual == null) return;

        tileCollider.enabled = false;

        PlacementManager.Instance.SetCurrentMenuType(tileType); //Set the type of deployment menu to open based on the tile type    
        PlacementManager.Instance.OpenDeploymentMenu();
        PlacementManager.Instance.SetCurrentTile(this);        
    }
}
