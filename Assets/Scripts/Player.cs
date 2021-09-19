using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TankController))]
public class Player : MonoBehaviour
{
    
    
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] Material playerMat;
    [SerializeField] Health playerHealth;

    private Color _playerOriginalColor;
    public Color OriginalColor => _playerOriginalColor;

    private bool _invincible;
    public bool isInvincible
    {
        get { return _invincible;  }
        set { _invincible = value;  }
    }

    

    public Inventory playerInventory;
    

    


    TankController _tankController;

    private void Awake()
    {
        _tankController = GetComponent<TankController>();
        _playerOriginalColor = playerMat.color;
        playerHealth.MaxHealth = 5;
    }

    private void Start()
    {
        //null
    }

    private void Update()
    {
        healthText.text = "" + playerHealth.CurrentHealth;
    }

    public void IncreaseHealth(int amount)
    {

        //null

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
        //null
    }

    //public void Kill()
    //{
    //    gameObject.SetActive(false);

    //    //play some particles
    //    //play some sounds
    //}
}
