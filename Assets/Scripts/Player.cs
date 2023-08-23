using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
	[SerializeField] private HealthBar _healthBar;
	[SerializeField] private UnityEvent _hitPlayer;
	[SerializeField] private UnityEvent _healPlayer;

	public float MaxHealth => _maxHealth; 
    public float CurrentHealth => _currentHealth;

	private float _maxHealth;
	private float _currentHealth = 100;
	private float _damage = 10;

	public void Hit()
	{
		if (_currentHealth > 0)
		{
			_currentHealth -= _damage;
			_hitPlayer.Invoke();
		}
	}

	public void Heal()
	{
		if (_currentHealth < _maxHealth)
		{
			_currentHealth += _damage;
			_healPlayer.Invoke();

		}
	}
}
