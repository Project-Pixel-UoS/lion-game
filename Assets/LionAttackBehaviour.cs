using UnityEngine;

public class LionAttackBehaviour : MonoBehaviour 
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float maxDistance = 1f;
    public float coneAngle = 60f;   // total angle
    public int rayCount = 20;

    //Lion Attack Parameters
    public float attackDamage = 1f;
    public float rechargeTime = 1f;
    private float lastAttackTime = 0f;


    void Update()
    {
        CastCone();
        lastAttackTime += Time.deltaTime;
    }

    void CastCone()
    {
        float startAngle = -coneAngle / 2f;
        float angleStep = coneAngle / (rayCount - 1);

        for (int i = 0; i < rayCount; i++)
        {
            float currentAngle = startAngle + (angleStep * i);

            // Rotate forward direction
            Vector3 direction = Quaternion.Euler(0, 0, currentAngle) * transform.up;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, maxDistance);

            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    DoRoarAttack();
                    Debug.DrawRay(transform.position, hit.point, Color.green);
                }                
            }
            else {
                Debug.DrawRay(transform.position, direction * maxDistance, Color.red);
            }

        }
    }

    void DoRoarAttack()
    {
        if (lastAttackTime >= rechargeTime)
        {
            // Implement attack logic here, e.g., apply damage to enemies in the cone
            Debug.Log("Attacking with damage: " + attackDamage);
            lastAttackTime = 0f; // Reset attack timer
        }
    }

    private void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            return; // Only draw gizmos in edit mode
        }

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