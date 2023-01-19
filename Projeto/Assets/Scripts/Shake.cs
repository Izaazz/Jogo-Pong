using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Izabela Maria da Silva Fonseca
//Colegio Tecnico da UFMG

public class Shake : MonoBehaviour
{
    public Animator CamAnim;

    public void CamShake()
    {
        CamAnim.SetTrigger("shake");
    }
}
