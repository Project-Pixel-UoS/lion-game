using UnityEngine;

public class ToggleGameobject : MonoBehaviour
{
    public void ToggleObject(GameObject objectToToggle)
    {
        if (objectToToggle == null)
        {
            Debug.LogWarning("No object assigned.");
            return;
        }

        // Switch active state
        objectToToggle.SetActive(!objectToToggle.activeSelf);
    }
}
