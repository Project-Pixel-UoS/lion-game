using UnityEngine;

public class EnemyMovementScript : MonoBehaviour
{
    public float speed = 1f;
    GameObject wateringHole;
    private Rigidbody2D rb; // Rigidbody2D of the enemy object
    public int health = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        wateringHole = GameObject.FindWithTag("Watering_Hole");
    }

    // Update is called once per frame
    void Update()
    {
        // Velocity moves towards watering hole on x-axis
        if (wateringHole.transform.position.x > transform.position.x)
        {
            rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
        }
        else if (wateringHole.transform.position.x < transform.position.x)
        {
            rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y);
        }

        // Velocity moves towards watering hole on y-axis
        if (wateringHole.transform.position.y > transform.position.y)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, speed);
        }
        else if (wateringHole.transform.position.y < transform.position.y)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, -speed);
        }
    }
}
