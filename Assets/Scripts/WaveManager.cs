using UnityEngine;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

public class WaveManager : MonoBehaviour
{
    public List<WaveData> allWaves;
    public Transform spawnPoint;

    private int currentWaveIndex = 0;
    private int activeEnemies = 0;

    async void Start()
    {
        await GameLoop();
    }

    async Task GameLoop()
    {
        while (currentWaveIndex < allWaves.Count)
        {
            await SpawnWave(allWaves[currentWaveIndex]);

            while (activeEnemies > 0)
            {
                continue;
            }

            await Awaitable.WaitForSecondsAsync(allWaves[currentWaveIndex].timeBeforeNextWave);

            currentWaveIndex++;
        }
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
            GameObject enemy = Instantiate(info.enemyPrefab, spawnPoint.position, Quaternion.identity);
            activeEnemies++;

            enemy.GetComponent<EnemyHealth>().OnDeath += () => activeEnemies--;

            await Awaitable.WaitForSecondsAsync(info.spawnRate);
        }
    }
}
