using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    public GameObject[] enemyTypes = new GameObject[5];
    private float minSpawnTime = 8f;
    private float maxSpawnTime = 12f;

    private float timer;
    private float nextSpawnTime;
    private GameObject[] spawnPoints = new GameObject[3];

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        spawnPoints[0] = gameObject.transform.GetChild(0).gameObject;
        spawnPoints[1] = gameObject.transform.GetChild(1).gameObject;
        spawnPoints[2] = gameObject.transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= nextSpawnTime)
        {
            Instantiate(enemyTypes[Random.Range(0, enemyTypes.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position, Quaternion.identity);

            timer = 0f;
            nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        }
    }
}
