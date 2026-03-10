using UnityEngine;

/// <summary>
/// Bootstraps persistent game systems at the start of each level.
/// Attach this to any GameObject in each level scene.
/// </summary>
/// <remarks>
/// Maintained by: Dayini
/// </remarks>
public class GameBootstrap : MonoBehaviour
{
    /// <summary>
    /// Triggers CurrencyManager to spawn from Resources if not already active.
    /// </summary>
    private void Awake()
    {
        _ = CurrencyManager.Instance;
    }
}








