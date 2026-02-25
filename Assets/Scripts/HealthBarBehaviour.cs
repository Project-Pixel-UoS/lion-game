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
        currentHealth = maxHealth; // Initialize current health to max health
    }

    void Update()
    {
        // For testing purposes, decrease health when the space key is pressed
        if (Input.GetMouseButtonDown(0)) // Left mouse button click
        {
            LoseHealth(1f); // Decrease health by 1
        }
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
