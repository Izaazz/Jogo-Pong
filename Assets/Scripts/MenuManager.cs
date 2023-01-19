using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Izabela Maria da Silva Fonseca
//Colegio Tecnico da UFMG

public class MenuManager : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject StartMenu;
    public GameObject ConfigMenu;
    private bool startOn = false;
    private bool configOn = false;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (startOn)
            {
                CloseStartMenu();
            }
            if (configOn)
            {
                CloseConfigMenu();
            }
        }
    }

    public void Singleplayer()
    {
        SceneManager.LoadScene("PongIA");
    }

    public void Multiplayer()
    {
        SceneManager.LoadScene("Pong");
    }

    public void OpenStartMenu()
    {
        MainMenu.SetActive(false);
        StartMenu.SetActive(true);
        startOn = true;
    }

    public void CloseStartMenu()
    {
        MainMenu.SetActive(true);
        StartMenu.SetActive(false);
        startOn = false;
    }

    public void OpenConfigMenu()
    {
        MainMenu.SetActive(false);
        ConfigMenu.SetActive(true);
        configOn = true;
    }
    public void CloseConfigMenu()
    {
        MainMenu.SetActive(true);
        ConfigMenu.SetActive(false);
        configOn = false;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
