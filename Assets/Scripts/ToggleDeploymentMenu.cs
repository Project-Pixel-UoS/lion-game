using UnityEngine;

/// <summary>
/// Toggles the Deployment Menu
/// </summary>
/// <remarks>
/// Maintained by: Michael Edems-Eze
/// </remarks>

public class ToggleDeploymentMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;

    public void ToggleMenu()
    {
        if (menuPanel == null)
        {
            Debug.LogWarning("MenuToggle: No menuPanel assigned.");
            return;
        }

        // Switch active state
        menuPanel.SetActive(!menuPanel.activeSelf);
    }
}
