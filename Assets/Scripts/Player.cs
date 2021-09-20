using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(TankController))]
public class Player : MonoBehaviour
{
    
    
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] GameObject _invinviblePanel;
    [SerializeField] Material playerMat;
    [SerializeField] Health playerHealth;
    [SerializeField] ProjectileGunBase playerGun;

    public Health PlayerHealth
    {
        get
        {
            return playerHealth;
        }
        set 
        {
            playerHealth = value;
        }
    }

    public ProjectileGunBase PlayerGun
    {
        get
        {
            return playerGun;
        }
        set
        {
            playerGun = value;
        }
    }

    

    private Color _playerOriginalColor;
    public Color OriginalColor => _playerOriginalColor;

   

    

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

        if (playerHealth.IsInvincible)
        {
            _invinviblePanel.SetActive(true);
        }
        else
        {
            _invinviblePanel.SetActive(false);
        }
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
