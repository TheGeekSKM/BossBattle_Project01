using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
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
        gameObject.SetActive(false);
    }
}
