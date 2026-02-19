using UnityEngine;

/// <summary>
/// Allows any Gameobject to be toggled on/off with this function
/// </summary>
/// <remarks>
/// Maintained by: Michael Edems-Eze
/// </remarks>


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
