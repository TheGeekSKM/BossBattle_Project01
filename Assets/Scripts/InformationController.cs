using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InformationController : MonoBehaviour
{
    [SerializeField] GameObject enemiesScreen;
    [SerializeField] GameObject itemScreen;

    public void EnemiesButton()
    {
        enemiesScreen.SetActive(true);
        itemScreen.SetActive(false);
    }

    public void ItemButton()
    {
        itemScreen.SetActive(true);
        enemiesScreen.SetActive(false);
    }

    public void ReturnButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
