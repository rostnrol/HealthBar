using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private HealthBar _healthBar;

	private float _maxHealth = 100;
	private float _currentHealth;
	private float _damage = 10;
	private float _healthChanginSpeed = 0.2f;

    public float MaxHealth => _maxHealth; 
    public float CurrentHealth => _currentHealth; 

    private void Start()
	{
		_currentHealth = _maxHealth;
	}

	public void Hit()
	{
		if (_currentHealth > 0)
		{
			_currentHealth -= _damage;
			_healthBar.SetHealth(_currentHealth);
		}
	}

	public void Heal()
	{
		if (_currentHealth < _maxHealth)
		{
			_currentHealth += _damage;
			_healthBar.SetHealth(_currentHealth);
		}
	}
}
