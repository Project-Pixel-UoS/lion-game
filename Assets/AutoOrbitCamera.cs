using UnityEngine;
using System.Collections;

public class AutoOrbitCamera : MonoBehaviour
{
    [Header("Camera Settings")]
    public Transform pivotPoint;
    public Camera targetCamera;  // Assign the camera you want to rotate here
    public float rotationSpeed = 50f; // degrees per second


    void OnEnable()
    {
        Rotate180Tutorial();
    }
    // Public function to rotate automatically
    public void Rotate180Tutorial(float duration = 2f)
    {
        if (targetCamera == null)
        {
            Debug.LogWarning("Target camera not assigned!");
            return;
        }

        StartCoroutine(RotateAroundPivot(duration));
    }

    private IEnumerator RotateAroundPivot(float duration)
    {
        float targetAngle = 180f;
        float rotated = 0f;
        float step;

        while (rotated < targetAngle)
        {
            step = (targetAngle / duration) * Time.deltaTime;

            if (rotated + step > targetAngle)
                step = targetAngle - rotated;

            // Rotate the camera around the pivot
            targetCamera.transform.RotateAround(pivotPoint.position, Vector3.forward, step);
            rotated += step;
            yield return null;
        }

        TutorialManager tutorialManager = FindObjectOfType<TutorialManager>();
        if (tutorialManager != null)
        {
            tutorialManager.NextStep();
        }
        else
        {
            Debug.LogWarning("TutorialManager not found or not on the expected step!"); 
        }
    }
}