using UnityEngine;

public class RoarProjectileBehaviour : MonoBehaviour
{
    public float timeActive = 5f; // Time in seconds the projectile is active
    private float timeAlive = 0f;

    public Rigidbody2D rb; // Reference to the Rigidbody2D component
    public float speed = 1f; // Speed of the projectile

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
}
