using UnityEngine;
using UnityEngine.SceneManagement;

public class OasisHealth : MonoBehaviour
{
    public int maxLives = 5;
    public int currentLives;
    public string[] enemyTags;

    void Start()
    {
        currentLives = maxLives;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        foreach (string tag in enemyTags)
        {
            if (other.gameObject.CompareTag(tag))
            {
                currentLives--;
                if (currentLives <= 0)
                {
                    SceneManager.LoadScene("EndScreen");
                }
                return;
            }
        }
    }
}
