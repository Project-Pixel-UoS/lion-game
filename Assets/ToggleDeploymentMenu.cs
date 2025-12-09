using UnityEngine;

public class ToggleDeploymentMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject placementPromptPanel;

    public void ToggleMenu()
    {
        if (menuPanel == null || placementPromptPanel == null)
        {
            Debug.LogWarning("MenuToggle: No menuPanel assigned.");
            return;
        }

        // Switch active state
        menuPanel.SetActive(!menuPanel.activeSelf);
        placementPromptPanel.SetActive(!placementPromptPanel.activeSelf);
    }
}
