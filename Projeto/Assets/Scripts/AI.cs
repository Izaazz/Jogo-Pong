using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Izabela Maria da Silva Fonseca
//Colegio Tecnico da UFMG

public class AI : MonoBehaviour
{

    GameObject bolinha;
    private float AIspeed = 7f;

    private void Start()
    {
        if (DropdownManager.AIspeed != 0) {
            AIspeed = DropdownManager.AIspeed;
        }

        bolinha = GameObject.FindGameObjectWithTag("Ball");
    }

    // Update is called once per frame
    private void Update()
    {
        AIPlay();
    }


    private void AIPlay()
    {
        if (bolinha.transform.position.y > transform.position.y + 0.5f)
        {
            if (transform.position.y <= 4.7)
            {
                transform.position += Vector3.up * AIspeed * Time.deltaTime;
            }
        }

        if (bolinha.transform.position.y < transform.position.y - 0.5f)
        {
            if (transform.position.y >= -4.7)
            {
                transform.position += Vector3.down * AIspeed * Time.deltaTime;
            }
        }

    }

}
