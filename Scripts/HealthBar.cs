using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	[SerializeField] private Slider _slider;
	[SerializeField] private Player _player;

	private Coroutine _changeHealth;
	private float _healthChangingSpeed = 20f;

	private void Start()
	{
		_slider.maxValue = _player.MaxHealth;
		_slider.value = _player.CurrentHealth;
	}

    private void OnEnable()
    {
		_player.HealthChanged += SetHealth;
    }

    private void OnDisable()
    {
		_player.HealthChanged -= SetHealth;
    }

    private void SetHealth()
	{
        if (_changeHealth != null)
            StopCoroutine(_changeHealth);

        _changeHealth = StartCoroutine(ChangeHealth(_player.CurrentHealth));
	}

	private IEnumerator ChangeHealth(float health)
    {
		while(_slider.value != health)
        {
			_slider.value = Mathf.MoveTowards(_slider.value, health, _healthChangingSpeed * Time.deltaTime);

			yield return null;
        }
    }
}
