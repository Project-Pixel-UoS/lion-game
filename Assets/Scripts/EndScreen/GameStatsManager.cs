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
    public static GameStatsManager Instance { get; private set; }
    public int EnemiesKilled { get; private set; }
    public int MoneySpent { get; private set; }
    public int WaveReached { get; private set; }

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
}
