using UnityEngine;

public class AdvanceTutorialOnClose : MonoBehaviour
{
    [SerializeField] private TutorialManager tutorialManager;

    // Call this from your close button
    public void OnDisable()
    {
        // Advance tutorial
        if (tutorialManager != null)
        {
            tutorialManager.NextStep();
        }
    }
}
