
using System;
using UnityEngine;

public class EnemyIndicator : MonoBehaviour
{
    public LaneTrigger[] lanes;
    public GameObject[] arrows;
    public Transform cameraTransform;
    public float lookThreshold = 0.8f;

    void Update()
    {
        Vector3 camForward = cameraTransform.up;
        camForward.z = 0;
        camForward.Normalize();

        for (int i = 0; i < lanes.Length; i++)
        {
            float dot = Vector3.Dot(camForward, lanes[i].laneDirection.normalized);


            bool isLookingAtLane = dot > lookThreshold;

            bool shouldShowArrow = (lanes[i].enemyCount > 0) && !isLookingAtLane;
            
            arrows[i].SetActive(shouldShowArrow);
        }
    }
}
