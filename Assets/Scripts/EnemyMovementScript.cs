using UnityEngine;

public class EnemyMovementScript : MonoBehaviour
{
    public GameObject enemyPrefab; // Asset to be duplicated for the enemy
    public float speed;
    public GameObject wateringHole;

    private GameObject enemy; // Duplicated enemy object that belongs to the entry point
    private Rigidbody2D rb; // Rigidbody2D of the enemy object

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = 1f;
        enemy = Instantiate(enemyPrefab, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity); // Spawn in enemy at the position of the entry point
        rb = enemy.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if enemy object exists
        if (enemy != null)
        {
            // Velocity moves towards watering hole on x-axis
            if (wateringHole.transform.position.x > enemy.transform.position.x)
            {
                rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
            }
            else if (wateringHole.transform.position.x < enemy.transform.position.x)
            {
                rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y);
            }

            // Velocity moves towards watering hole on y-axis
            if (wateringHole.transform.position.y > enemy.transform.position.y)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, speed);
            }
            else if (wateringHole.transform.position.y < enemy.transform.position.y)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, -speed);
            }
        }
    }
}
