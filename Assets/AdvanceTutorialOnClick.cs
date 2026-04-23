using UnityEngine;

public class AdvanceTutorialOnClick : MonoBehaviour
{
    [SerializeField] private TutorialManager tutorialManager;
    
    void OnMouseDown()
    {
        if (tutorialManager != null)
        {
            Debug.Log("Advanced Tutorial");
            tutorialManager.NextStep();
            this.enabled = false; // Disable this script after advancing the tutorial to prevent multiple clicks
        }
    }
}
