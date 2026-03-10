using UnityEngine;

public class ZigZagEnemyMovementScript : MonoBehaviour
{
    public float speed = 1f;
    GameObject wateringHole;
    private Rigidbody2D rb; // Rigidbody2D of the enemy object
    public int health = 1;
    public float zigZagSpace; // This is the distance within the enemy keeps moving before zigging (or zagging!)

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        wateringHole = GameObject.FindWithTag("Watering_Hole");
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }

        // Velocity moves towards watering hole on x-axis
        if (wateringHole.transform.position.x + zigZagSpace > transform.position.x)
        {
            rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
        }
        else if (wateringHole.transform.position.x - zigZagSpace < transform.position.x)
        {
            rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y);
        }

        // Velocity moves towards watering hole on y-axis
        if (wateringHole.transform.position.y + zigZagSpace > transform.position.y)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, speed);
        }
        else if (wateringHole.transform.position.y - zigZagSpace < transform.position.y)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, -speed);
        }
    }

    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.CompareTag("Lion"))
        {
            health--;
        }
    }
}
