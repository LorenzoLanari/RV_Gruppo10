using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rob_Health : MonoBehaviour
{
    [SerializeField]
    private int StartHealth = 5;
    public Slider slider;
    private int currentHealth;

    private void OnEnable()
    {
        currentHealth = StartHealth;
        slider.maxValue = StartHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        slider.value = currentHealth;
        
    }
    public int GetCurrentHealth()
    {
        return this.currentHealth;

    }
    
}
