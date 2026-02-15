using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{

    public GameObject enemyPrefab;
    public float minSpawnTime;
    public float maxSpawnTime;

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
        timer += Time.deltaTime;

        if (timer >= nextSpawnTime)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);

            timer = 0f;
            nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        }
    }
}
