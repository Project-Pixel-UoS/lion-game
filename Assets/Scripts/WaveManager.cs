using UnityEngine;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System;
/// <summary>
/// Holds the main logic for spawning new waves
/// </summary>
public class WaveManager : MonoBehaviour
{
    public static WaveManager Instance;
    public List<WaveData> allWaves;
    
    public GameObject wateringHoleObject;

    private Dictionary<Direction, List<EnemySpawnScript>> spawnGroups = new();
    private int currentWaveIndex = 0;
    private int activeEnemies = 0;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
    async void Start()
    {
        await Awaitable.NextFrameAsync();
        await GameLoop();
    }

    async Task GameLoop()
    {
        while (currentWaveIndex < allWaves.Count)
        {
            await SpawnWave(allWaves[currentWaveIndex]);

            while (activeEnemies > 0)
            {
                await Awaitable.NextFrameAsync();
            }

            await Awaitable.WaitForSecondsAsync(allWaves[currentWaveIndex].timeBeforeNextWave);

            currentWaveIndex++;
        }
        Debug.Log("Level Complete");
    }

    async Task SpawnWave(WaveData wave)
    {
        List<Task> tasks = wave.enemiesInWave.Select(info => SpawnEnemy(info)).ToList();
        await Task.WhenAll(tasks);
    }
    
    async Task SpawnEnemy(EnemySpawnInfo info)
    {
        for (int i = 0; i < info.count; i++)
        {
            EnemySpawnScript spawnPoint = GetRandomSpawnPoint(info.direction);
            GameObject enemy = Instantiate(info.enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
            //EnemyMovementScript movementStats = enemy.GetComponent<EnemyMovementScript>();
            //movementStats.wateringHole = wateringHoleObject;
            activeEnemies++;

            enemy.GetComponent<EnemyHealth>().OnDeath += () => activeEnemies--;

            await Awaitable.WaitForSecondsAsync(info.spawnRate);
        }
    }

    public void RegisterSpawnPoint(EnemySpawnScript point)
    {
        if (!spawnGroups.ContainsKey(point.group))
        {
            spawnGroups[point.group] = new List<EnemySpawnScript>();
        }

        spawnGroups[point.group].Add(point);
    }

    EnemySpawnScript GetRandomSpawnPoint(Direction direction)
    {
        EnemySpawnScript selected = spawnGroups[direction][UnityEngine.Random.Range(0, spawnGroups[direction].Count)];
        return selected;
    }
}
