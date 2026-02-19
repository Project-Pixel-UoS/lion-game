using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This will update the image of the Prompt Panel to be that of the currently selected lion,
///  which should be helfpul when deciding the tile on which to place one.
/// </summary>
/// <remarks>
/// Maintained by: Michael Edems-Eze
/// </remarks>

public class UpdatePanelImage : MonoBehaviour
{
    //The Image variable which will hold the sprite of the currently selected lion
    public Image lionImage;

    //Only update the image when the prompt panel is activated
    void Start()
    {
        // This code assumes the lion prefab has a SpriteRenderer (may have to be updated if this won't be the case)
        var sr = PlacementManager.Instance.selectedLion.GetComponent<SpriteRenderer>();
        if (sr != null && lionImage != null) {
            lionImage.sprite = sr.sprite; //Update Image variable to be that of the lion Gameobject
        } 
        else {
            Debug.LogWarning("UpdatePanelImage: SpriteRenderer or lionImage is null.");
        }    
    }
}