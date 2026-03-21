using UnityEngine;

///<summary>
/// File that tracks game statistics throughout a run
/// Call the public methods to update stats
/// Reset on a new run by calling ResetStats().
/// </summary>
/// <remarks>
/// Maintained by: Dayini
/// </remarks>


public class GameStatsManager : MonoBehaviour
{
    public static GameStatsManager Instance;
    public int EnemiesKilled;
    public int MoneySpent;
    public int WaveReached;

    #region Unity Lifecycle

    /// <summary>
    /// Ensures only one instance exists and persists across scenes.
    /// </summary>
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    #endregion

    void Start()
    {
        SaveSystem.Load(); // Load at game start
    }

    // Optional auto-save
    void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            SaveSystem.Save();
        }
    }

    void OnApplicationQuit()
    {
        SaveSystem.Save();
    }
    
    #region Public API

    /// <summary>
    /// Call this everytime an enemy is defeated
    /// </summary>
    /// </param name="count">Number of enemies killed (default 0).</param>
    public void AddEnemyKilled(int count = 0)
    {
        EnemiesKilled += count;
    }

    /// <summary>
    /// Call this whenever player spends in-run currency.
    /// </summary>
    /// </param name="amount">Amount spent.</param>
    public void AddMoneySpent(int amount)
    {
        MoneySpent += amount;
    }

    /// <summary>
    /// Call this at the start of each new wave
    /// </summary>
    public void SetWave(int wave)
    {
        WaveReached = wave;
    }

    /// <summary>
    /// Resets all stats. Call this at the start of fresh run.
    /// </summary>
    public void ResetStats()
    {
        EnemiesKilled = 0;
        MoneySpent = 0;
        WaveReached = 0;
    }

    #endregion

    #region Save/Load Functionality
    public void SaveStats(ref GameStatsSaveData saveData)
    {
        saveData.EnemiesKilled = EnemiesKilled;
        saveData.MoneySpent = MoneySpent;
        saveData.WaveReached = WaveReached;
    }

    public void LoadStats(GameStatsSaveData saveData)
    {
        EnemiesKilled = saveData.EnemiesKilled;
        MoneySpent = saveData.MoneySpent;
        WaveReached = saveData.WaveReached;
    }

    #endregion
}

[System.Serializable]
public struct GameStatsSaveData
{
    public int EnemiesKilled;
    public int MoneySpent;
    public int WaveReached;
}
