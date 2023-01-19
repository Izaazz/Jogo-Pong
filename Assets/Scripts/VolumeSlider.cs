using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Izabela Maria da Silva Fonseca
//Colegio Tecnico da UFMG

public class VolumeSlider : MonoBehaviour
{
    public Slider volumeSlider;


    private void Start()
    {
        if (!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("volume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("volume", volumeSlider.value);
    }
}