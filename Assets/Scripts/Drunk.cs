using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Izabela Maria da Silva Fonseca
//Colegio Tecnico da UFMG


public class Drunk : MonoBehaviour
{
    public Animator CamAnim2;

    public void DrunkCam()
    {
        CamAnim2.SetTrigger("drunk");
    }
}
