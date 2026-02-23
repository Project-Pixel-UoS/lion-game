using UnityEngine;

public class LionAttackBehaviour : MonoBehaviour 
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float maxDistance = 1f;
    public float coneAngle = 60f;   // total angle
    public int rayCount = 20;

    void Update()
    {
        CastCone();
    }

    void CastCone()
    {
        float startAngle = -coneAngle / 2f;
        float angleStep = coneAngle / (rayCount - 1);

        for (int i = 0; i < rayCount; i++)
        {
            float currentAngle = startAngle + (angleStep * i);
            Debug.Log("Current Angle: " + currentAngle);

            // Rotate forward direction
            Vector3 direction = Quaternion.Euler(0, 0, currentAngle) * transform.up;

            Ray ray = new Ray(transform.position, direction);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, maxDistance))
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    Debug.Log("Enemy detected!");
                    Debug.DrawRay(transform.position, direction * hit.distance, Color.green);
                }                
            }
            else {
                Debug.DrawRay(transform.position, direction * maxDistance, Color.red);
            }

            
        }
    }

    private void OnDrawGizmos()
    {
        float startAngle = -coneAngle / 2f;
        float angleStep = coneAngle / (rayCount - 1);

        for (int i = 0; i < rayCount; i++)
        {
            float currentAngle = startAngle + (angleStep * i);

            // Rotate forward direction
            Vector3 direction = Quaternion.Euler(0, 0, currentAngle) * transform.up;
            
            Gizmos.color = new Color(1f, 1f, 0f);

            // Draw the line
            Gizmos.DrawLine(transform.position, transform.position + direction * maxDistance);
        }
    }
}