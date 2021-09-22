using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    //variables
    [SerializeField] Slider _healthBarSlider;
    [SerializeField] GameObject _healthBar;
    [SerializeField] Health _playerHealth;

    private void Awake()
    {
        _healthBarSlider.maxValue = _playerHealth.MaxHealth;
        _healthBarSlider.value = _playerHealth.MaxHealth;
    }

    private void OnEnable()
    {
        if (_playerHealth != null)
        {
            _playerHealth.Damaged += OnTakeDamage;
            _playerHealth.Killed += OnKilled;
        }
    }

    private void OnDisable()
    {
        if (_playerHealth != null)
        {
            _playerHealth.Damaged -= OnTakeDamage;
            _playerHealth.Killed -= OnKilled;
        }
    }

    void OnTakeDamage(int amount)
    {
        _healthBarSlider.value = _playerHealth.CurrentHealth;
    }

    void OnKilled()
    {
        _healthBar.SetActive(false);
    }
}
