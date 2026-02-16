using UnityEngine;

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

public class PlacementTile : MonoBehaviour
{
    // True if something is already placed on this tile
    public bool occupied;

    // Reference to the SpriteRenderer so we can change tile color
    public SpriteRenderer sr;

    // Default color when tile is not available
    public Color normal = Color.black;

    // Highlight color when tile is available for placement
    public Color highlight = Color.green;

    // Optional visual object used to preview placement
    public GameObject testVisual;

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
    }

    void Update()
    {
        // A tile can be used if it's not occupied
        bool canPlace = !occupied;

        // Change tile color depending on whether it can be used
        // Green = available
        // Black = occupied
        sr.color = canPlace ? highlight : normal;
    }

    void OnMouseDown()
    {
        // Do nothing if tile is already occupied
        if (occupied) return;

        // Do nothing if there is no object assigned to place
        if (testVisual == null) return;

        // Call the PlacementManager singleton to handle placement logic
        PlacementManager.Instance.Place(this);
    }
}
