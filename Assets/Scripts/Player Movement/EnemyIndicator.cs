using UnityEngine;

public class EnemyIndicator : MonoBehaviour
{
    public LaneTrigger[] lanes;
    public GameObject globalLeftArrow;
    public GameObject globalRightArrow;
    
    public Transform cameraTransform;

    void Update()
    {
        bool enemiesToLeft = false;
        bool enemiesToRight = false;

        Vector3 camForward = cameraTransform.up;
        camForward.z = 0; 
        camForward.Normalize();

        foreach (LaneTrigger lane in lanes)
        {
            if (lane.enemyCount > 0)
            {
                Vector3 dirToLane = lane.laneDirection.normalized;
                dirToLane.z = 0;

                float relativeAngle = Vector2.SignedAngle(camForward, dirToLane);
                if (relativeAngle < -30) 
                {
                    enemiesToRight = true;
                }
                else if (relativeAngle > 30) 
                {
                    enemiesToLeft = true;
                }
            }
        }
        globalLeftArrow.SetActive(enemiesToLeft);
        globalRightArrow.SetActive(enemiesToRight);
    }
}
