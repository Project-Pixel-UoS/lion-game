using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 1; // Initial health of the enemy, can be adjusted in the Unity Inspector

    public void LoseHealth(int damage)
    {
        health -= damage; // Reduce health by the damage amount
        if (health <= 0)
        {
            Destroy(gameObject); // Destroy the enemy object if health is depleted and optionally add death effects here
        }
    }
}
