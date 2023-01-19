using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Izabela Maria da Silva Fonseca
//Colegio Tecnico da UFMG

public class Player2 : MonoBehaviour
{
    public float speed;
    private bool changeControlsIndex;
    public TrailRenderer ballTrail;

    private void Start()
    {

        changeControlsIndex = false;

        if (ToggleManager.drunkModeOn)
        {
            InvokeRepeating("ChangeControls", 0.5f, 5f);
        }
    }

    private void FixedUpdate()
    {
        PlayerMove(changeControlsIndex);
    }


    private void PlayerMove(bool changeControlsIndex)
    {
        if (!changeControlsIndex)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (transform.position.y <= 4.7)
                {
                    transform.position += Vector3.up * speed * Time.deltaTime;
                }
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                if (transform.position.y >= -4.7)
                {
                    transform.position += Vector3.down * speed * Time.deltaTime;
                }
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                if (transform.position.y <= 4.7)
                {
                    transform.position += Vector3.up * speed * Time.deltaTime;
                }
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (transform.position.y >= -4.7)
                {
                    transform.position += Vector3.down * speed * Time.deltaTime;
                }
            }
        }
    }

    private void ChangeControls()
    {
        if (changeControlsIndex == true)
        {
            changeControlsIndex = false;
        }
        else
        {
            changeControlsIndex = true;
        }

    }
}
