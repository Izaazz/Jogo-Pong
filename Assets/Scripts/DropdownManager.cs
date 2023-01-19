using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Izabela Maria da Silva Fonseca
//Colegio Tecnico da UFMG

public class DropdownManager : MonoBehaviour
{
    public TMPro.TMP_Dropdown PointsToWinDropdown;
    public TMPro.TMP_Dropdown AIspeedDropdown;

    public static float AIspeed;
    public static int PointsToWin;



    private void Start()
    {
        if (!PlayerPrefs.HasKey("AIManager"))
        {
            PlayerPrefs.SetInt("AIManager", 1);
            AIspeed = 6.0f;
            AIspeedLoad();
        }
        else
        {
            AIspeedLoad();
        }

        if (!PlayerPrefs.HasKey("PointsToWin"))
        {
            PlayerPrefs.SetInt("PointsToWin", 1);
            PointsToWin = 5;
            PointsToWinLoad();
        }
        else
        {
            PointsToWinLoad();
        }
    }

    public void DropdownInputToAIspeed(int i)
    {
        if (i == 0)
        {
            AIspeed = 4.0f;
        }

        if (i == 1)
        {
            AIspeed = 6.0f;
        }

        if (i == 2)
        {
            AIspeed = 10.0f;
        }

        AIspeedSave();
    }
    private void AIspeedLoad()
    {
        AIspeedDropdown.value = PlayerPrefs.GetInt("AIManager");
    }
    private void AIspeedSave()
    {
        PlayerPrefs.SetInt("AIManager", AIspeedDropdown.value);
    }


    public void DropdownInputToPoints(int i)
    {
        if (i == 0)
        {
            PointsToWin = 3;
        }

        if (i == 1)
        {
            PointsToWin = 5;
        }

        if (i == 2)
        {
            PointsToWin = 10;
        }

        PointsToWinSave();
    }
    private void PointsToWinLoad()
    {
        PointsToWinDropdown.value = PlayerPrefs.GetInt("PointsToWin");
    }
    private void PointsToWinSave()
    {
        PlayerPrefs.SetInt("PointsToWin", PointsToWinDropdown.value);
    }

}
