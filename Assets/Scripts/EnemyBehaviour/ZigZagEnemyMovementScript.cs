using UnityEngine;
using System;

public class ZigZagEnemyMovementScript : MonoBehaviour
{
    public float speed = 1f;
    private GameObject wateringHole;
    private Rigidbody2D rb; // Rigidbody2D of the enemy object
    public int health = 1;
    public float smoothingRegion; // This is the range within the enemy does not change direction
    public int lionKnockbackForce; // This is the knockback that the enemy takes after colliding with a lion
    public double zigZagSpeed; // This switches direction of zig zag when enemy hits lane border
    private double previousZigZagSpeed;
    public float correctionTime; // Time before enemy movement is corrected if stuck
    private float timer;
    private bool isVerticalEnemy;
    public string[] TagList = {"Zig_Zag_Enemy", "Helmet_Enemy", "Boots_Enemy","Enemy"};

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

        timer += Time.deltaTime;
        if (timer > correctionTime)
        {
            if (previousZigZagSpeed == zigZagSpeed)
            {
                zigZagSpeed = -zigZagSpeed;
            }
            
            previousZigZagSpeed = zigZagSpeed;
            timer = 0;
        }
    }

    void OnCollisionEnter2D (Collision2D other)
    {
        Debug.Log(other.gameObject.tag);
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
