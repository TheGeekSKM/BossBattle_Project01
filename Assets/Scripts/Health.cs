using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    //Events
    public event Action<int> Damaged = delegate { };
    public event Action<int> Healed = delegate { };
    public event Action Killed = delegate { };
    
    [SerializeField] int _maxHealth = 10;
    public int MaxHealth
    {
        get
        {
            return _maxHealth;
        }
        set
        {
            _maxHealth = value;
        }
    }

    private int _currentHealth;
    public int CurrentHealth
    {
        get
        {
            return _currentHealth;
        }
        set
        {
            _currentHealth = value;
        }
    }

    [SerializeField] bool _isInvincible;

    public bool IsInvincible
    {
        get
        {
            return _isInvincible;
        }
        set
        {
            _isInvincible = value;
        }
    }
   

    private void Awake()
    {
        _currentHealth = _maxHealth;
        _isInvincible = false;
        
    }


    public void TakeDamage(int amount)
    {
        if (!_isInvincible)
        {
            _currentHealth -= amount;
            Damaged?.Invoke(amount);
        }

    }

    public void Healing(int amount)
    {
        if (_currentHealth < _maxHealth)
        {
            _currentHealth += amount;
            Healed?.Invoke(amount);
        }
       
        //tests to see if the healing might have over done it.
        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
    }

    private void Update()
    {
        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
        if (_currentHealth <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        if (!_isInvincible)
        {
            Killed?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
