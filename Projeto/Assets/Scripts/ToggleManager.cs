using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Izabela Maria da Silva Fonseca
//Colegio Tecnico da UFMG

public class ToggleManager : MonoBehaviour
{
    public static bool drunkModeOn;
    public static bool increaseSpeedOn;

    public Toggle drunkModeToggle;
    public Toggle increaseSpeedToggle;

    public void Start()
    {
        if (!PlayerPrefs.HasKey("DrunkMode"))
        {
            PlayerPrefs.SetInt("DrunkMode", 0);
            drunkModeOn = false;
            DrunkModeLoad();
        }
        else
        {
            DrunkModeLoad();
            
        }

        if (!PlayerPrefs.HasKey("IncreaseSpeed"))
        {
            PlayerPrefs.SetInt("IncreaseSpeed", 1);
            increaseSpeedOn = true;
            IncreaseSpeedLoad();
        }
        else
        {
            IncreaseSpeedLoad();
        }

    }

    public void DrunkMode(bool toggleOn)
    {
        if (toggleOn)
        {
            drunkModeOn = true;
        }
        else
        {
            drunkModeOn = false;
        }

        DrunkModeSave();
    }

    private void DrunkModeLoad()
    {
        drunkModeToggle.isOn = PlayerPrefs.GetInt("DrunkMode") != 0;
    }
    private void DrunkModeSave()
    {
        PlayerPrefs.SetInt("DrunkMode", (drunkModeToggle.isOn ? 1 : 0));
    }

    public void IncreaseSpeed(bool toggleOn)
    {
        if (toggleOn)
        {
            increaseSpeedOn = true;
        }
        else
        {
            increaseSpeedOn = false;
        }

        IncreaseSpeedSave();

    }

    private void IncreaseSpeedLoad()
    {
        increaseSpeedToggle.isOn = PlayerPrefs.GetInt("IncreaseSpeed") != 0;
    }
    private void IncreaseSpeedSave()
    {
        PlayerPrefs.SetInt("IncreaseSpeed", (increaseSpeedToggle.isOn ? 1 : 0));
    }


}
