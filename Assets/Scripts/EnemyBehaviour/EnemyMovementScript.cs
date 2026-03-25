using UnityEngine;
using System;

public class EnemyMovementScript : MonoBehaviour
{
    public float speed = 1f;
    private GameObject wateringHole;
    private Rigidbody2D rb; // Rigidbody2D of the enemy object
    public int health = 1;
    public float smoothingRegion; // This is the range within the enemy does not change direction
    public int lionKnockbackForce; // This is the knockback that the enemy briefly takes after colliding with a lion
    public string[] TagList = {"Zig_Zag_Enemy", "Helmet_Enemy", "Boots_Enemy","Enemy"};
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
        if (wateringHole.transform.position.x > gameObject.transform.position.x)
        {
            rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
        }
        else if (wateringHole.transform.position.x < gameObject.transform.position.x)
        {
            rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y);
        }
        if (wateringHole.transform.position.x - smoothingRegion < gameObject.transform.position.x && wateringHole.transform.position.x + smoothingRegion > gameObject.transform.position.x)
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }

        // Velocity moves towards watering hole on y-axis
        if (wateringHole.transform.position.y > gameObject.transform.position.y)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, speed);
        }
        else if (wateringHole.transform.position.y < gameObject.transform.position.y)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, -speed);
        }
        if (wateringHole.transform.position.y - smoothingRegion < gameObject.transform.position.y && wateringHole.transform.position.y + smoothingRegion > gameObject.transform.position.y)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        }

        Debug.Log("Script enabled.");
    }

    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.CompareTag("Lion"))
        {
            rb.linearVelocity = new Vector2(0, 0);
            rb.AddForce(new Vector2(Convert.ToSingle((gameObject.transform.position.x - wateringHole.transform.position.x) * lionKnockbackForce), Convert.ToSingle((gameObject.transform.position.y - wateringHole.transform.position.y) * lionKnockbackForce)));
            health--;
        }
        foreach (string TagToTest in TagList)
        {
            if (other.gameObject.tag == TagToTest )
            {
                Physics2D.IgnoreCollision(other.collider, GetComponent<Collider2D>());
                return;
            }
        }
    }
}
