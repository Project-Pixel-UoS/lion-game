using UnityEngine;

public class LionAttackBehaviour : MonoBehaviour 
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float maxDistance = 1f;
    public float coneAngle = 60f;   // total angle
    public int rayCount = 20;

    //Lion Attack Parameters
    public int attackDamage = 1; // Base damage of the lion's attack, can be adjusted in the Unity Inspector
    public float rechargeTime = 1f;
    private float lastAttackTime = 0f;

    public GameObject roarProjectilePrefab; // Reference to the projectile prefab
    public Vector2 projectileSpawnOffset; // Offset from where the projectile will be spawned

    public int ammunition = 10; // Amount of ammunition the lion has for its attack, can be adjusted in the Unity Inspector

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
                    DoRoarAttack(Vector2.SignedAngle(Vector2.up, hit.point - (Vector2)transform.position));
                    Debug.DrawRay(transform.position, hit.point, Color.green);
                }                
            }
            else {
                Debug.DrawRay(transform.position, direction * maxDistance, Color.red);
            }

        }
    }

    void DoRoarAttack(float attackAngle)
    {
        if (lastAttackTime >= rechargeTime && ammunition > 0)
        {
            // Implement attack logic here, e.g., apply damage to enemies in the cone
            Debug.Log("Attacking with damage: " + attackDamage);
            lastAttackTime = 0f; // Reset attack timer
            ammunition--; // Decrease ammunition count

            GameObject projectile = Instantiate(roarProjectilePrefab, (Vector2)transform.position + projectileSpawnOffset, Quaternion.Euler(0, 0, attackAngle));
            RoarProjectileBehaviour projectileBehaviour = projectile.GetComponent<RoarProjectileBehaviour>();
            if (projectileBehaviour != null)
            {
                projectileBehaviour.SetDamage(attackDamage); // Set the damage for the projectile using Lion Data
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            return; // Only draw gizmos in edit mode
        }

        Gizmos.DrawSphere(transform.position + (Vector3)projectileSpawnOffset, 0.2f); // Draw a small sphere at the position of the GameObject

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