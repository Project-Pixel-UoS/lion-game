using UnityEngine;
using System.Collections;

public class IntroCutscene : MonoBehaviour
{
    public Transform cameraTransform;
    public Vector3 cutsceneCameraPosition;
    public Vector3 homeCameraPosition;

    public Transform[] enemies;

    void Start()
    {
        cameraTransform.position = cutsceneCameraPosition; // start at cutscene position
        StartCoroutine(TriggerCutscene());
    }
    IEnumerator TriggerCutscene()
    {
        // Move enemies forward
        foreach (Transform enemy in enemies)
        {
            Vector3 forwardPos = enemy.position + enemy.forward * 3f;

            LeanTween.move(enemy.gameObject, forwardPos, 2f)
                .setEaseInOutSine();
        }

        // Wait 5 seconds (IMPORTANT: use real time)
        yield return new WaitForSeconds(5f);

        // Move camera to second position
        LeanTween.move(cameraTransform.gameObject, homeCameraPosition, 2f)
            .setEaseInOutSine();

        yield return new WaitForSeconds(2f);

        // Start tutorial after cutscene
        StartTutorial();
    }

    void StartTutorial()
    {
        // Assuming you have a reference to the TutorialManager
        TutorialManager tutorialManager = FindObjectOfType<TutorialManager>();
        if (tutorialManager != null)
        {
            tutorialManager.StartTutorial();
        }
    }
}
