using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    public Action OnDeath;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        if (currentHealth < 0)
        {
            Die();
        }
    }

    public void Die()
    {
        OnDeath?.Invoke();

        Destroy(gameObject);
    }
}
