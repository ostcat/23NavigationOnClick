using UnityEngine;

public class Health
{
    private const string TakeDamageTriggerKey = "TakeDamage";
    private const string IsDeadKey = "IsDead";

    private float _maxHealth;
    private float _currentHealth;
    private float _percentageToDetermineIfInjured = 0.3f;
    private Animator _animator;
    
    public float CurrentHealth => _currentHealth;

    public Health(float maxHealth, Animator animator)
    {
        _maxHealth = maxHealth;
        _currentHealth = maxHealth;
        _animator = animator;
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
            _animator.SetBool(IsDeadKey, true);
            Debug.Log("You died");
            return;
        }

        _animator.SetTrigger(TakeDamageTriggerKey);
        Debug.Log("Current health: " + _currentHealth);
    }

    public bool IsInjured() => _currentHealth <= (_maxHealth * _percentageToDetermineIfInjured);

    public bool IsDead() => _currentHealth == 0;
}
