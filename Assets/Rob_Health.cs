using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rob_Health : MonoBehaviour
{
    [SerializeField]
    private int StartHealth = 5;

    private int currentHealth;

    private void OnEnable()
    {
        currentHealth = StartHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        
    }
    public int GetCurrentHealth()
    {
        return this.currentHealth;

    }
}
