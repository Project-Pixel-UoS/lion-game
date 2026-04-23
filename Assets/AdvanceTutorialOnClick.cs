using UnityEngine;

public class AdvanceTutorialOnClick : MonoBehaviour
{
    [SerializeField] private TutorialManager tutorialManager;
    [SerializeField] private int[] tutorialAdvanceSteps; // The tutorial step to advance to when this object is clicked

    void OnMouseDown()
    {
        if (tutorialManager != null && System.Array.IndexOf(tutorialAdvanceSteps, tutorialManager.step) != -1)
        {
            Debug.Log("Advanced Tutorial");
            tutorialManager.NextStep();
        }
    }
}
