using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

/// <summary>
/// Manages the player's currency across all levels and sessions.
/// Self-instantiates from Resources when first accessed, no manual scene setup needed.
/// Persists across scene loads and saves to disk so currency survives closing the game.
/// Only displays the UI counter in gameplay scenes specified in the Inspector.
/// </summary>
/// <remarks>
/// Maintained by: Dayini
/// </remarks>
public class CurrencyManager : MonoBehaviour
{
    private static CurrencyManager instance;

    /// <summary>
    /// Returns the active instance, spawning it from Resources if it doesn't exist yet.
    /// </summary>
    public static CurrencyManager Instance
    {
        get
        {
            if (instance == null)
                SpawnFromResources();

            return instance;
        }
    }

    private const string CURRENCY_SAVE_KEY = "PlayerCurrency";

    [Header("Currency Settings")]
    [SerializeField] private int startingCurrency = 0;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI currencyCounterText;
    [SerializeField] private GameObject currencyUIRoot;

    [Header("Scene Visibility")]
    [Tooltip("Only show the currency counter in these scenes. Add each level scene name here.")]
    [SerializeField] private string[] gameplayScenes = { "Level1" };

    public int CurrentCurrency { get; private set; }

    #region Unity Lifecycle

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        CurrentCurrency = PlayerPrefs.GetInt(CURRENCY_SAVE_KEY, startingCurrency);
        RefreshUI();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    #endregion

    #region Scene Handling

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateUIVisibility(scene.name);
    }

    private void UpdateUIVisibility(string sceneName)
    {
        if (currencyUIRoot == null) return;
        bool shouldShow = System.Array.IndexOf(gameplayScenes, sceneName) >= 0;
        currencyUIRoot.SetActive(shouldShow);
    }

    #endregion

    #region Public API

    public void AddCurrency(int amount)
    {
        CurrentCurrency += amount;
        Save();
        RefreshUI();
    }

    public bool SpendCurrency(int amount)
    {
        if (CurrentCurrency < amount) return false;
        CurrentCurrency -= amount;
        Save();
        RefreshUI();
        return true;
    }

    public bool CanAfford(int amount) => CurrentCurrency >= amount;

    #endregion

    #region Private Helpers

    private void Save()
    {
        PlayerPrefs.SetInt(CURRENCY_SAVE_KEY, CurrentCurrency);
        PlayerPrefs.Save();
    }

    private static void SpawnFromResources()
    {
        GameObject prefab = Resources.Load<GameObject>("Prefabs/CurrencyManager");
        if (prefab == null)
        {
            Debug.LogError("CurrencyManager: Prefab not found at Resources/Prefabs/CurrencyManager.");
            return;
        }
        Instantiate(prefab);
    }

    private void RefreshUI()
    {
        if (currencyCounterText != null)
            currencyCounterText.text = $"Currency: {CurrentCurrency}";
    }

    #endregion
}