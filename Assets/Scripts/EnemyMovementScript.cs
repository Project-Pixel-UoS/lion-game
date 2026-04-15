using UnityEngine;

public class EnemyMovementScript : MonoBehaviour
{
    public float speed = 1f;
    private float speedModifier = 1f;
    public GameObject wateringHole;
    private Rigidbody2D rb; // Rigidbody2D of the enemy object

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetSpeedModifier(float modifier){
        speedModifier = modifier;
    }

    // Update is called once per frame
    void Update()
    {
        // Velocity moves towards watering hole on x-axis
        if (wateringHole.transform.position.x > transform.position.x)
        {
            rb.linearVelocity = new Vector2(speed*speedModifier, rb.linearVelocity.y);
        }
        else if (wateringHole.transform.position.x < transform.position.x)
        {
            rb.linearVelocity = new Vector2(-speed*speedModifier, rb.linearVelocity.y);
        }

        // Velocity moves towards watering hole on y-axis
        if (wateringHole.transform.position.y > transform.position.y)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, speed*speedModifier);
        }
        else if (wateringHole.transform.position.y < transform.position.y)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, -speed*speedModifier);
        }
        
        if (speedModifier!=1f) {
            Debug.Log($"Velocity: {rb.linearVelocity}, Modifier: {speedModifier}");
        }
        
    }
}
