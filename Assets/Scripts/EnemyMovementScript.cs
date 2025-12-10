using UnityEngine;

public class EnemyMovementScript : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float speed;
    public GameObject wateringHole;

    private GameObject enemy;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = 1f;
        enemy = Instantiate(enemyPrefab, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
        rb = enemy.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (wateringHole.transform.position.x > enemy.transform.position.x)
        {
            rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
        }
        else if (wateringHole.transform.position.x < enemy.transform.position.x)
        {
            rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y);
        }

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
