using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TankController))]
public class Player : MonoBehaviour
{
    
    [SerializeField] int _maxHealth = 3;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] Material playerMat;

    private Color _playerOriginalColor;
    public Color OriginalColor => _playerOriginalColor;

    private bool _invincible;
    public bool isInvincible
    {
        get { return _invincible;  }
        set { _invincible = value;  }
    }

    public int MaxHealth
    {
        get { return _maxHealth;  }
    }

    public Inventory playerInventory;
    

    int _currentHealth;
    public int CurrentHealth
    {
        get { return _currentHealth; }
        private set 
        {
            if (value > _maxHealth)
            {
                value = _maxHealth;
            }
            _currentHealth = value;
        }
    }


    TankController _tankController;

    private void Awake()
    {
        _tankController = GetComponent<TankController>();
        _playerOriginalColor = playerMat.color;
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        if (_invincible)
        {
            _currentHealth = _maxHealth;
        }

        healthText.text = "" + _currentHealth;
    }

    public void IncreaseHealth(int amount)
    {
        if (_currentHealth < _maxHealth)
        {
            _currentHealth += amount;
            Debug.Log("Player's Health: " + _currentHealth);
        }

        
    }

    public void ChangeColor(Color color)
    {
        playerMat.color = color;
    }

    public void RevertColor()
    {
        playerMat.color = _playerOriginalColor;
    }

    public void DecreaseHealth(int amount)
    {
        _currentHealth -= amount;
        Debug.Log("Player Health: " + _currentHealth);
        if (_currentHealth <= 0f)
        {
            Kill();
        }
    }

    public void Kill()
    {
        gameObject.SetActive(false);

        //play some particles
        //play some sounds
    }
}
