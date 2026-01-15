using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
    private int _maxHealth;
    private int _currentHealth;

    public int CurrentHealth => _currentHealth;

    public Health(int maxHealth)
    {
        _maxHealth = maxHealth;
        _currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if(damage < 0)
        {
            Debug.LogError("damage < 0");
            return;
        }

        _currentHealth -= damage;

        if (_currentHealth < 0)
        {
            _currentHealth = 0;
            return;
        }
    }
}
