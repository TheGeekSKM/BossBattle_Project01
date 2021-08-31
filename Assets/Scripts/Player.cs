using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TankController))]
public class Player : MonoBehaviour
{
    [SerializeField] int _maxHealth = 3;
    int _currentHealth;

    TankController _tankController;

    private void Awake()
    {
        _tankController = GetComponent<TankController>();
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void IncreaseHealth(int amount)
    {
        if (_currentHealth < _maxHealth)
        {
            _currentHealth += amount;
            Debug.Log("Player's Health: " + _currentHealth);
        }

        
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
