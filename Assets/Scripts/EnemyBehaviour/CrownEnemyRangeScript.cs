// This script is to detect when a crown crocodile is in range, 
// in which case the enemy this script is attached to will accelerate

using UnityEngine;

public class CrownEnemyRangeScript : MonoBehaviour
{
    EnemyMovementScript enemyMovement; // Reference to movement script
    GameObject crownEnemy; // Reference to crown enemy object
    public float minRange; // The minimum range for the boost to take effect
    public int speedBoost; // The strength of the speed boost

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyMovement = GetComponent<EnemyMovementScript>();
    }

    // Update is called once per frame
    void Update()
    {
        crownEnemy = GameObject.FindWithTag("Crown_Enemy");

        if (crownEnemy != null) {
            float distance = Vector2.Distance(gameObject.transform.position, crownEnemy.transform.position); // Get distance between this object and crown enemy
            if (distance < minRange)
            {
                enemyMovement.speed += 2;
            }
        }
    }
}
