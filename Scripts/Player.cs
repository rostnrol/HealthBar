using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _maxHealth;

    public UnityAction HealthChanged;

    public float CurrentHealth => _currentHealth;
    public float MaxHealth => _maxHealth;

    private float _damage = 10;

    public void Hit()
    {
        _currentHealth = Mathf.Clamp(_currentHealth -=_damage, 0f, _maxHealth);
        HealthChanged?.Invoke();
    }

    public void Heal()
    {
        _currentHealth = Mathf.Clamp(_currentHealth +=_damage, 0f, _maxHealth);
        HealthChanged?.Invoke();
    }
}

