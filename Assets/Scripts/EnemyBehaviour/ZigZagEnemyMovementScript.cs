using UnityEngine;
using System;

public class ZigZagEnemyMovementScript : MonoBehaviour
{
    public float speed = 1f;
    GameObject wateringHole;
    private Rigidbody2D rb; // Rigidbody2D of the enemy object
    public int health = 1;
    public float smoothingRegion; // This is the range within the enemy does not change direction
    public int lionKnockbackForce; // This is the knockback that the enemy takes after colliding with a lion
    public double zigZagSpeed; // This switches direction of zig zag when enemy hits lane border
    private bool isVerticalEnemy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        wateringHole = GameObject.FindWithTag("Watering_Hole");
        if (Math.Abs(wateringHole.transform.position.x - gameObject.transform.position.x) > Math.Abs(wateringHole.transform.position.y - gameObject.transform.position.y))
        {
            isVerticalEnemy = false;
        }
        else
        {
            isVerticalEnemy = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }

        if (isVerticalEnemy)
        {
            if (wateringHole.transform.position.y < transform.position.y)
            {
                rb.linearVelocity = new Vector2(Convert.ToSingle(zigZagSpeed * speed), -speed);
            }
            else
            {
                rb.linearVelocity = new Vector2(Convert.ToSingle(zigZagSpeed * speed), speed);
            }
        }
        else
        {
            if (wateringHole.transform.position.x < transform.position.x)
            {
                rb.linearVelocity = new Vector2(-speed, Convert.ToSingle(zigZagSpeed * speed));
            }
            else
            {
                rb.linearVelocity = new Vector2(speed, Convert.ToSingle(zigZagSpeed * speed));
            }
        }
    }

    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.CompareTag("Lion"))
        {
            rb.linearVelocity = new Vector2(0, 0);
            rb.AddForce(new Vector2(Convert.ToSingle((gameObject.transform.position.x - wateringHole.transform.position.x) * lionKnockbackForce), Convert.ToSingle((gameObject.transform.position.y - wateringHole.transform.position.y) * lionKnockbackForce)));
            health--;
        }
        if (other.gameObject.CompareTag("Lane_Border"))
        {
            zigZagSpeed = -zigZagSpeed;
        }
    }
}
