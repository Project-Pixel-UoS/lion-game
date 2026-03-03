using UnityEngine;
using System;

public class EnemyCollisionScript : MonoBehaviour
{
    private Rigidbody2D rb; // Rigidbody2D of the enemy object
    public float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Detects collision with enemy object
    /// </summary>
    /// <param name="other">collision object</param>
    /// <todo>
    /// Change from destruction of object to having the object run away after a few seconds
    /// </todo>
    /// <remarks>
    /// Maintained by: Rehan Fernando
    /// Updated By: Michael Edems-Eze
    /// </remarks>
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            // Instead of destroying the enemy, make it run away
        }
    }

    /// <summary>
    /// Returns 1 if watering hole position is less than enemy position and -1 if greater than
    /// </summary>
    /// <param name="wateringHolePosition">position of the watering hole on one axis</param>
    /// <param name="enemyPosition">position of the enemy object on one axis</param>
    /// <returns>-1 or 1 depending on where enemy is compared to watering hole</returns>
    /// <remarks>
    /// Maintained by: Rehan Fernando
    /// </remarks>
    public int Signum(float wateringHolePosition, float enemyPosition)
    {
        int result = 0;

        if (wateringHolePosition < enemyPosition)
        {
            result = 1;
        }
        else if (wateringHolePosition > enemyPosition)
        {
            result = -1;
        }

        return result;
    }
}
