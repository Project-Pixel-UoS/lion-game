using UnityEngine;

public class EnemyMovementScript : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float speed = 20f;
    public GameObject wateringHole;

    private GameObject enemy;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemy = Instantiate(enemyPrefab, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
        rb = enemy.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
