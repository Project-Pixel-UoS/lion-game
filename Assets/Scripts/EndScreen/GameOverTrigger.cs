using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Temporary trigger for testing the end screen.
/// Replace this with real game-over logic later.
/// </summary>
/// <remarks>
/// Maintained by: Dayini
/// </remarks>
public class GameOverTrigger : MonoBehaviour
{
    /// <summary>
    /// Call this to end the run and load the EndScreen scene.
    /// </summary>
    public void TriggerGameOver()
    {
        SceneManager.LoadScene("EndScreen");
    }
}