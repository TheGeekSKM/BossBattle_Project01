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
    [SerializeField] TextMeshProUGUI lifeText;
    [SerializeField] RespawnScript respawnObject; 
    [SerializeField] GameObject _invinviblePanel;
    [SerializeField] Material playerMat;
    [SerializeField] Material playerOriginalMat;
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

    

    

   

    

    public Inventory playerInventory;
    

    


    TankController _tankController;

    private void Awake()
    {
        _tankController = GetComponent<TankController>();
        playerMat.SetColor("_Color", playerOriginalMat.color);
        playerHealth.MaxHealth = 5;
    }

    private void Start()
    {
        //null
    }

    private void Update()
    {
        healthText.text = "" + playerHealth.CurrentHealth;
        lifeText.text = "" + respawnObject.NumOfLives;

        if (playerHealth.IsInvincible)
        {
            _invinviblePanel.SetActive(true);
        }
        else
        {
            _invinviblePanel.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            playerMat.SetColor("_Color", playerOriginalMat.color);
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
        playerMat.SetColor("_Color", playerOriginalMat.color);
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
