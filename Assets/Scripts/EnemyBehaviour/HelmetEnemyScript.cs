//This script is to handle enemies with a helmet.
//The helmet is disabled when health is less than 0
//Damage will then be dealt direct to enemy
using UnityEngine;

public class HelmetEnemyScript : MonoBehaviour
{
    EnemyMovementScript enemyMovement; // Reference to movement script
    GameObject helmetEnemy; // Reference to helmet enemy object
    public int helmetHealth; // Stores the current helmet health
    private bool enabled; // Stores whether the helmet is enabled

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyMovement = GetComponent<EnemyMovementScript>();
        enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        // doesn't need checking per frame just on impact
    }

    //Stops helmet from taking damage
    void onHelmetBreaks()
    {
        enabled = false;
    }

    // returns a boolean value to represent whether 
    // the damage was taken successfully from the helmet
    public bool damageHelmet(int damage)
    {
        if (enabled == false) {
            return false;
        }
        helmetHealth -= damage;
        if (helmetHealth <= 0) {
            this.onHelmetBreaks();
        }
        return true;
    }
}
