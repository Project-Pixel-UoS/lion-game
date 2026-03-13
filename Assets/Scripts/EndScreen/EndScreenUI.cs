using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

/// <summary>
/// Controls the end screen UI. Call ShowEndScreen() from game-over logic.
/// Pulls all values from GameStatsManager.
/// </summary>
/// <remarks>
/// Maintained by: Dayini
/// </remarks>
public class EndScreenUI : MonoBehaviour
{
    [Header("Stat Text Fields")]
    [SerializeField] private TextMeshProUGUI enemiesKilledText;
    [SerializeField] private TextMeshProUGUI moneySpentText;
    [SerializeField] private TextMeshProUGUI waveReachedText;

    [Header("Buttons")]
    [SerializeField] private Button restartButton;
    [SerializeField] private Button mainMenuButton;

    [Header("Scene Names")]
    [SerializeField] private string gameSceneName = "Level1";
    [SerializeField] private string menuSceneName = "MainMenu";


    #region Unity Lifecycle

    /// <summary>
    /// Wires up button listeners and populates stats on scene load.
    /// </summary>
    private void Start()
    {
        restartButton.onClick.AddListener(OnRestartClicked);
        mainMenuButton.onClick.AddListener(OnMainMenuClicked);

        // Populate stats as soon as this scene loads
        PopulateStats();
    }

    #endregion


    #region Private Helpers

    /// <summary>
    /// Reads from GameStatsManager and writes to each text field.
    /// Falls back to zeros if manager is not present (e.g. testing in isolation).
    /// </summary>
    private void PopulateStats()
    {
        bool hasManager = GameStatsManager.Instance != null;

        int enemiesKilled = hasManager ? GameStatsManager.Instance.EnemiesKilled : 0;
        int moneySpent = hasManager ? GameStatsManager.Instance.MoneySpent : 0;
        int waveReached = hasManager ? GameStatsManager.Instance.WaveReached : 0;

        enemiesKilledText.text = $"Enemies Defeated: {enemiesKilled}";
        moneySpentText.text = $"Money Spent: {moneySpent}";
        waveReachedText.text = $"Wave Reached: {waveReached}";
    }

    #endregion


    #region Button Handlers

    /// <summary>
    /// Resets stats and reloads Level1 for a fresh run.
    /// </summary>
    private void OnRestartClicked()
    {
        GameStatsManager.Instance?.ResetStats();
        SceneManager.LoadScene(gameSceneName);
    }

    /// <summary>
    /// Returns to the main menu.
    /// </summary>
    private void OnMainMenuClicked()
    {
        SceneManager.LoadScene(menuSceneName);
    }

    #endregion
}