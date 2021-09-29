using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    [SerializeField] Health playerHealth;
    [SerializeField] Health bossHealth;
    [SerializeField] GameObject playerObject;
    [SerializeField] Transform respawnPoint;
    [SerializeField] GameObject healthBar;
    [SerializeField] float timeToRespawn = 3;
    [SerializeField] int numOfLives = 3;
    [SerializeField] bool gameOver = false;
    [SerializeField] AudioClip _deathSound;


    public int NumOfLives
    {
        get
        {
            return numOfLives;
        }
        set
        {
            numOfLives = value;
        }
    }

    private void OnEnable()
    {
        playerHealth.Killed += Respawn;
        bossHealth.Killed += Win;
    }

    private void OnDisable()
    {
        playerHealth.Killed -= Respawn;
        bossHealth.Killed -= Win;
    }

    private void Update()
    {
        if (gameOver)
        {
            SceneManager.LoadScene(3);
        }
    }

    void Respawn()
    {
        AudioHelper.PlayClip2D(_deathSound, 1f);
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

    void Win()
    {
        Invoke("WinningMethod", 0.5f);
    }

    void WinningMethod()
    {
        SceneManager.LoadScene(4);
    }
}
