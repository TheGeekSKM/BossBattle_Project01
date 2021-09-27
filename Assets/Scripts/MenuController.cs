using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject _menuScreen;
    [SerializeField] GameObject _creditsScreen;
    public void OpenMenu()
    {
        _menuScreen.SetActive(true);
        _creditsScreen.SetActive(false);
    }

    public void OpenCredits()
    {
        _menuScreen.SetActive(false);
        _creditsScreen.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
