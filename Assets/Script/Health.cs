using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour
{
    [SerializeField]
    private int StartHealth = 5;
    public ParticleSystem Death_Effect;

    private int currentHealth;

    private void OnEnable()
    {
        currentHealth = StartHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
            Die();
    }

    private void Die()
    {
        Instantiate(Death_Effect, transform.position, Quaternion.identity);
        Destroy(transform.parent.gameObject);
    }
    public int GetCurrentHealth()
    {
        return this.currentHealth;

    }
}
