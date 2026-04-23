using UnityEngine;

public class AdvanceTutorialOnClose : MonoBehaviour
{
    [SerializeField] private TutorialManager tutorialManager;

    [SerializeField] private int[] tutorialAdvanceSteps; // The tutorial step to advance to when this object is clicked
    public void OnDisable()
    {
        // Advance tutorial
        if (tutorialManager != null && System.Array.IndexOf(tutorialAdvanceSteps, tutorialManager.step) != -1)
        {
            tutorialManager.NextStep();
        }
    }
}
