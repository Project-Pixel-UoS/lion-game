using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehaviour : MonoBehaviour
{
    public Image healthBar; // Reference to the health bar image
    public float maxHealth = 5f;
    public float currentHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoseHealth(float damage)
    {
        // Decrease health bar by a certain amount
        currentHealth -= damage;
        healthBar.fillAmount = currentHealth / maxHealth;
    }
    
    void GainHealth(float amount)
    {
        // Increase health bar by a certain amount
        currentHealth += amount;
        healthBar.fillAmount = currentHealth / maxHealth;
        currentHealth = Mathf.Min(currentHealth, maxHealth); // Ensure health does not exceed max
    }
}
