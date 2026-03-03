using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 1; // Initial health of the enemy, can be adjusted in the Unity Inspector

    public Action OnDeath;
    
    public void LoseHealth(int damage)
    {
        health -= damage; // Reduce health by the damage amount
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die() {
        OnDeath?.Invoke();
        Destroy(gameObject);
    }
}
