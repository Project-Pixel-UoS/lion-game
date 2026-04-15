using UnityEngine;
using System.Collections.Generic;

public class RoarProjectileBehaviour : MonoBehaviour
{
    public float timeActive = 3.5f; // Time in seconds the projectile is active
    private float timeAlive = 0f;

    public Rigidbody2D rb; // Reference to the Rigidbody2D component
    public float speed = 3f; // Speed of the projectile

    public float damage = 1f; // Damage dealt to enemies on impact

    [SerializeField] private int maxDurability = 1;
    private int currentDurability;

    [SerializeField] private float aoeRadius = 1.5f;

    private float slowFactor = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.linearVelocity = transform.up * speed; // Adjust speed as needed
        currentDurability = maxDurability;
    }   

    // Update is called once per frame
    void Update()
    {
        timeAlive += Time.deltaTime;
        if (timeAlive >= timeActive)
        {
            Destroy(gameObject);
            // Optionally, you can add effects or logic here when the projectile expires
        }
    }

    public void SetDamage(float damageAmount)
    {
        damage = damageAmount; // Set the damage amount for the projectile
    }

    public void SetPiercing(int durability)
    {
        maxDurability = durability;
        currentDurability = durability;
    }

    public void SetAoeRadius(float radius)
    {
        aoeRadius = radius;
    }

    public void SetScale(float projectileScale)
    {
        transform.localScale = Vector3.one * projectileScale;
    }

    public void SetSlowFactor(float factor)
    {
        slowFactor = factor;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

            ApplyAoEDamage(collision.contacts[0].point);

            // Implement logic for when the projectile hits an enemy, e.g., apply damage
            if (collision.gameObject.TryGetComponent<EnemyHealth>(out EnemyHealth enemyHealth))
            {
                enemyHealth.LoseHealth(damage); // Apply damage to the enemy
            }

            if (collision.gameObject.TryGetComponent<EnemyMovementScript>(out EnemyMovementScript enemyMovement) && slowFactor != 0){
                    Debug.Log($"Set Speed Modifier to {1-slowFactor}");
                    enemyMovement.SetSpeedModifier(1-slowFactor);
            }

            currentDurability -= 1;
            if (currentDurability <= 0) {
                Destroy(gameObject); // Destroy the projectile on impact if it has run out of durability;
            }
        }
    }

    void ApplyAoEDamage(Vector2 impactPoint)
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(impactPoint, aoeRadius);
        HashSet<EnemyHealth> impactedEnemies = new HashSet<EnemyHealth>();

        foreach (Collider2D hit in hits)
        {
            if (!hit.CompareTag("Enemy"))
            {
                continue;
            }

            if (hit.TryGetComponent<EnemyHealth>(out EnemyHealth enemyHealth) &&
                !impactedEnemies.Contains(enemyHealth))
            {
                enemyHealth.LoseHealth(damage);
                impactedEnemies.Add(enemyHealth);
            }
        }
    }
}
