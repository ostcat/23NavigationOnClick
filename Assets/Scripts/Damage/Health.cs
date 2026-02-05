using UnityEngine;

public class Health
{
    private float _maxHealth;
    private float _currentHealth;
    private float _percentageToDetermineIfInjured = 0.3f;
    
    public float CurrentHealth => _currentHealth;

    public Health(float maxHealth)
    {
        _maxHealth = maxHealth;
        _currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
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

            Debug.Log("You died");
            return;
        }

        Debug.Log("Current health: " + _currentHealth);
    }

    public void AddHealth(float healthToRestore)
    {
        if (healthToRestore < 0)
        {
            Debug.LogError("healthToRestore < 0");
            return;
        }

        _currentHealth += healthToRestore;

        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }

        Debug.Log("Current health: " + _currentHealth);
    }

    public bool IsInjured() => _currentHealth <= (_maxHealth * _percentageToDetermineIfInjured);

    public bool IsDead() => _currentHealth == 0;
}
