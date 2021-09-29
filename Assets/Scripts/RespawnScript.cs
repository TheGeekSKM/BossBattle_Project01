using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    [SerializeField] Health playerHealth;
    [SerializeField] GameObject playerObject;
    [SerializeField] Transform respawnPoint;
    [SerializeField] GameObject healthBar;
    [SerializeField] float timeToRespawn = 3;
    [SerializeField] int numOfLives = 3;
    [SerializeField] bool gameOver = false;

    private void OnEnable()
    {
        playerHealth.Killed += Respawn;
    }

    private void OnDisable()
    {
        playerHealth.Killed -= Respawn;
    }

    private void Update()
    {
        if (gameOver)
        {
            
        }
    }

    void Respawn()
    {
        Invoke("RespawningMethod", timeToRespawn);
    }

    void RespawningMethod()
    {
        if (numOfLives > 0)
        {
            playerObject.transform.position = respawnPoint.position;
            playerObject.SetActive(true);
            healthBar.SetActive(true);
        }
        else if (numOfLives <= 0)
        {
            gameOver = true;
        }
        
    }
}
