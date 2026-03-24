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
        Rigidbody2D enemyRb = other.gameObject.GetComponent<Rigidbody2D>();
        Collider2D enemyCol = other.gameObject.GetComponent<Collider2D>();

        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Crown_Enemy") || other.gameObject.CompareTag("Helmet_Enemy") || other.gameObject.CompareTag("Boots_Enemy"))
        {
            var movement = other.gameObject.GetComponent<EnemyMovementScript>();

            enemyCol.enabled = false;
            movement.enabled = false;

            StartCoroutine(MoveThenDisable(other.gameObject, enemyRb, movement.speed * 4));
        }
        else if (other.gameObject.CompareTag("Zig_Zag_Enemy"))
        {
            var movement = other.gameObject.GetComponent<ZigZagEnemyMovementScript>();

            enemyCol.enabled = false;
            movement.enabled = false;

            StartCoroutine(MoveThenDisable(other.gameObject, enemyRb, movement.speed * 4));
        }
    }

    IEnumerator MoveThenDisable(GameObject enemy, Rigidbody2D enemyRb, float speed)
    {
        float timer = 0f;

        Vector2 direction = (enemy.transform.position - transform.position).normalized;
        enemyRb.linearVelocity = direction * speed;

        while (timer < runningAwayTime)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        enemy.SetActive(false);
    }
}
