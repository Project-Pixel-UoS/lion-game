using UnityEngine;
using TMPro;

/// <summary>
/// Manages permanent currency, earned between runs and
/// persistent across sessions via PlayerPrefs. Never resets during gameplay.
/// Used by the shop to unlock stronger lions before a run.
/// </summary>
/// <remarks>
/// Maintained by: Dayini
/// </remarks>
public class PermanentCurrencyManager : MonoBehaviour
{
    private static PermanentCurrencyManager instance;
    public static PermanentCurrencyManager Instance
    {
        get
        {
            if (instance == null)
                SpawnFromResources();

            return instance;
        }
    }

    private const string SAVE_KEY = "PermanentCurrency";

    [Header("UI (optional — assign when shop/menu UI exists)")]
    [Tooltip("Leave unassigned until the shop UI is built.")]
    [SerializeField] private TextMeshProUGUI permanentCurrencyText;

    public int CurrentPermanentCurrency { get; private set; }

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
        LoadCurrency();
        RefreshUI();

    }

    #endregion

    #region Public API

    public void AddPermanentCurrency(int amount)
    {
        if (amount <= 0) return;

        CurrentPermanentCurrency += amount;
        Save();
        RefreshUI();

        Debug.Log($"[PermanentCurrencyManager] +{amount} permanent currency. Total: {CurrentPermanentCurrency}");
    }

    public bool SpendPermanentCurrency(int amount)
    {
        if (amount <= 0) return false;

        if (CurrentPermanentCurrency < amount)
        {
            Debug.Log($"[PermanentCurrencyManager] Cannot afford {amount}. Have: {CurrentPermanentCurrency}");
            return false;
        }

        CurrentPermanentCurrency -= amount;
        Save();
        RefreshUI();

        Debug.Log($"[PermanentCurrencyManager] Spent {amount}. Remaining: {CurrentPermanentCurrency}");
        return true;
    }

    #endregion

    #region Private Helpers

    private static void SpawnFromResources()
    {
        GameObject prefab = Resources.Load<GameObject>("Prefabs/PermanentCurrencyManager");
        if (prefab == null)
        {
            Debug.LogError("PermanentCurrencyManager: Prefab not found at Resources/Prefabs/PermanentCurrencyManager.");
            return;
        }
        Instantiate(prefab);
    }

    private void LoadCurrency()
    {
        CurrentPermanentCurrency = PlayerPrefs.GetInt(SAVE_KEY, 0);
        Debug.Log($"[PermanentCurrencyManager] Loaded permanent currency: {CurrentPermanentCurrency}");
    }

    private void Save()
    {
        PlayerPrefs.SetInt(SAVE_KEY, CurrentPermanentCurrency);
        PlayerPrefs.Save();
    }

    private void RefreshUI()
    {
        if (permanentCurrencyText != null)
            permanentCurrencyText.text = $"Stars: {CurrentPermanentCurrency}";
    }

    #endregion
}