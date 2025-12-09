using UnityEngine;

public class ToggleGameobject : MonoBehaviour
{
    [SerializeField] private GameObject objectToToggle;

    public void ToggleObject()
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

