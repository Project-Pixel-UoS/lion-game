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
        }
    }
}
