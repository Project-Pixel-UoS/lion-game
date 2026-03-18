using UnityEngine;

/// <summary>
/// Attach to any lion prefab that should passively generate currency.
/// Calls CurrencyManager.AddCurrency() on a repeating timer.
/// Each lion type can have its own productionInterval and currencyPerTick.
/// </summary>
/// <remarks>
/// Maintained by: Dayini
/// </remarks>
public class CurrencyProducer : MonoBehaviour
{
    [Header("Production Settings")]
    [Tooltip("Seconds between each currency drop.")]
    [SerializeField] private float productionInterval = 5f; // set to every 5 seconds for now 

    [Tooltip("How much currency is produced each tick.")]
    [SerializeField] private int currencyPerTick = 25;  // set to 25 count for now for every currency produced

    private float timer;

    #region Unity Lifecycle

    /// <summary>
    /// Resets the timer when the lion is placed or re-enabled.
    /// </summary>
    private void OnEnable()
    {
        timer = productionInterval;
    }

    /// <summary>
    /// Counts down and produces currency when the timer hits zero.
    /// </summary>
    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            Produce();
            timer = productionInterval;
        }
    }

    #endregion

    #region Private Helpers

    /// <summary>
    /// Deposits currency into the CurrencyManager.
    /// </summary>
    private void Produce()
    {
        if (CurrencyManager.Instance == null)
        {
            Debug.LogWarning("CurrencyProducer: CurrencyManager not found.");
            return;
        }

        CurrencyManager.Instance.AddCurrency(currencyPerTick);
    }

    #endregion
}