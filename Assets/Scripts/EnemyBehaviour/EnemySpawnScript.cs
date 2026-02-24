using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{

    public GameObject enemyPrefab;
    private float minSpawnTime = 4f;
    private float maxSpawnTime = 12f;

    private float timer;
    private float nextSpawnTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyPrefab == null)
        {
            return;
        }

        timer += Time.deltaTime;

        if (timer >= nextSpawnTime)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);

            timer = 0f;
            nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        }
    }
}
