using UnityEngine;
using UnityEngine.UI;

public class UpdatePanelImage : MonoBehaviour
{
    public Image lionImage;

    void Start()
    {
        // Assuming the prefab has a SpriteRenderer
        var sr = PlacementManager.Instance.selectedLion.GetComponent<SpriteRenderer>();
        if (sr != null && lionImage != null) {
            lionImage.sprite = sr.sprite;
        } 
        else {
            Debug.LogWarning("UpdatePanelImage: SpriteRenderer or lionImage is null.");
        }    
    }
}