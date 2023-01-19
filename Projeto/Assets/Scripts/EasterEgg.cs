using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Izabela Maria da Silva Fonseca
//Colegio Tecnico da UFMG

public class EasterEgg : MonoBehaviour
{
    public ParticleSystem glitter;

    public void GlitterEffect()
    {
        glitter.Play();
    }
}
