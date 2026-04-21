using UnityEngine;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
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
    private int eliminatedEnemiesCount = 0;
    public Image progressBar;

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
            WaveData currentWave = allWaves[currentWaveIndex];

            int numEnemiesInWave = currentWave.enemiesInWave.Sum(item => item.count);
            eliminatedEnemiesCount = 0;
            await SpawnWave(currentWave);

            while (activeEnemies > 0)
            {
                progressBar.fillAmount = 1 - (numEnemiesInWave - eliminatedEnemiesCount) / numEnemiesInWave;
                await Awaitable.NextFrameAsync();
            }

            AwardPermanentCurrency(currentWave);
            await Awaitable.WaitForSecondsAsync(currentWave.timeBeforeNextWave);

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
            enemy.GetComponent<EnemyHealth>().OnDeath += () => eliminatedEnemiesCount++;

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

    void AwardPermanentCurrency(WaveData wave)
    {
        if (wave == null || wave.permanentCurrencyReward <= 0)
        {
            return;
        }

        PermanentCurrencyManager.Instance.AddPermanentCurrency(wave.permanentCurrencyReward);
    }
}
