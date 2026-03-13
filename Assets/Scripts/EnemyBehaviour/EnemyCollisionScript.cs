using UnityEngine;
using System;
using System.Collections;

public class EnemyCollisionScript : MonoBehaviour
{
    private Rigidbody2D rb; // Rigidbody2D of the enemy object
    private Collider2D col; // Collider of the enemy object
    private EnemyMovementScript enemyMovementScript; // Movement script of enemy object
    private ZigZagEnemyMovementScript zigZagEnemyMovementScript; // Movement script if enemy is a zig zag enemy
    private float runningAwayTime = 5f; // Time for which enemy runs away
    private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Detects collision with enemy object
    /// </summary>
    /// <param name="other">collision object</param>
    /// <todo>
    /// Change from destruction of object to having the object run away after a few seconds
    /// </todo>
    /// <remarks>
    /// Maintained by: Rehan Fernando
    /// </remarks>
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Crown_Enemy") || other.gameObject.CompareTag("Helmet_Enemy") || other.gameObject.CompareTag("Boots_Enemy"))
        {
            col = other.gameObject.GetComponent<Collider2D>();
            rb = other.gameObject.GetComponent<Rigidbody2D>();
            enemyMovementScript = other.gameObject.GetComponent<EnemyMovementScript>();

            col.enabled = false;
            enemyMovementScript.enabled = false;

            StartCoroutine(MoveThenDisable(other.gameObject));
        }
        if (other.gameObject.CompareTag("Zig_Zag_Enemy"))
        {
            col = other.gameObject.GetComponent<Collider2D>();
            rb = other.gameObject.GetComponent<Rigidbody2D>();
            zigZagEnemyMovementScript = other.gameObject.GetComponent<ZigZagEnemyMovementScript>();

            col.enabled = false;
            zigZagEnemyMovementScript.enabled = false;

            StartCoroutine(MoveThenDisable(other.gameObject));
        }
    }

    IEnumerator MoveThenDisable(GameObject enemy)
    {
        timer = 0f;
        float speed = enemyMovementScript.speed;
        speed = speed * 4;

        rb.linearVelocity = new Vector2((enemy.transform.position.x - gameObject.transform.position.x) * speed, (enemy.transform.position.y - gameObject.transform.position.y) * speed);
        while (timer < runningAwayTime)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        enemy.SetActive(false);
    }
}
