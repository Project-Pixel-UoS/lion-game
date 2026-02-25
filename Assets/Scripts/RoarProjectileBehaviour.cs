using UnityEngine;

public class RoarProjectileBehaviour : MonoBehaviour
{
    public float timeActive = 5f; // Time in seconds the projectile is active
    private float timeAlive = 0f;

    public Rigidbody2D rb; // Reference to the Rigidbody2D component
    public float speed = 3f; // Speed of the projectile

    public int damage = 1; // Damage dealt to enemies on impact

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.linearVelocity = transform.up * speed; // Adjust speed as needed
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

    public void SetDamage(int damageAmount)
    {
        damage = damageAmount; // Set the damage amount for the projectile
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Implement logic for when the projectile hits an enemy, e.g., apply damage
            if (collision.gameObject.TryGetComponent<EnemyHealth>(out EnemyHealth enemyHealth))
            {
                enemyHealth.LoseHealth(damage); // Apply damage to the enemy
            }
            Destroy(gameObject); // Destroy the projectile on impact
        }
    }
}
