using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TutorialManager : MonoBehaviour
{
    [System.Serializable]
    public class TutorialStep
    {
        public string message;
        public Transform highlightTarget;
        public GameObject[] includedObjects;
        public bool pauseGame;
    }

    public TutorialStep[] steps;

    public int step = 0;

    //public HighlightCircle highlight;
    //public TutorialUI ui;

    public Transform fruitTile;
    public Transform lionTile;

    [SerializeField] private GameObject Spotlight;
    [SerializeField] private GameObject BannerText;


    public void StartTutorial()
    {
        ActivateStep(0);
    }

    IEnumerator WaitAndAdvance(float waitTime = 5f)
    {
        yield return new WaitForSeconds(waitTime);
        NextStep();
    }

    void ActivateStep(int stepIndex)
    {
        TutorialStep previousStep = null;

        if (stepIndex != step && step >= 0 && step < steps.Length)
        {
            previousStep = steps[step];
        }

        step = stepIndex;
        TutorialStep currentStep = steps[step];

        // Disable objects from previous step that are NOT in the new step
        if (previousStep != null)
        {
            foreach (GameObject obj in previousStep.includedObjects)
            {
                if (System.Array.IndexOf(currentStep.includedObjects, obj) == -1)
                {
                    obj.SetActive(false);
                }
            }
        }

        // Enable objects for current step
        foreach (GameObject obj in currentStep.includedObjects)
        {
            obj.SetActive(true);
        }

        // Handle pause
        Time.timeScale = currentStep.pauseGame ? 0f : 1f;
    }

    public void NextStep()
    {
        if (step < steps.Length - 1)
        {
            ActivateStep(step + 1);
        }
        else
        {
            // EndTutorial();
        }

        if (step == 2 || step == 4 || step == 6)
        {
            StartCoroutine(WaitAndAdvance());
        }

        if (step == 8)
        {
            Camera.main.GetComponent<OrbitCamera>().enabled = true;
        }
    }
}
