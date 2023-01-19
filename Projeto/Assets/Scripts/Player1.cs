using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Izabela Maria da Silva Fonseca
//Colegio Tecnico da UFMG

public class Player1 : MonoBehaviour
{
    public float speed;
    private bool changeControlsIndex;
    public TrailRenderer ballTrail;
    public Gradient gradient1;
    public Gradient gradient2;
    private Drunk drunk;

    private void Start()
    {
        drunk = GameObject.FindGameObjectWithTag("DrunkScreen").GetComponent<Drunk>();

        changeControlsIndex = false;

        if (ToggleManager.drunkModeOn)
        {
            InvokeRepeating("ChangeControls", 0.5f, 7f);
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
            if (Input.GetKey(KeyCode.W))
            {
                if (transform.position.y <= 4.7)
                {
                    transform.position += Vector3.up * speed * Time.deltaTime;
                }
            }

            if (Input.GetKey(KeyCode.S))
            {
                if (transform.position.y >= -4.7)
                {
                    transform.position += Vector3.down * speed * Time.deltaTime;
                }
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.S))
            {
                if (transform.position.y <= 4.7)
                {
                    transform.position += Vector3.up * speed * Time.deltaTime;
                }
            }

            if (Input.GetKey(KeyCode.W))
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
            ballTrail.colorGradient = gradient1;
            ballTrail.time = 0.2f;
            drunk.DrunkCam();
        }
        else
        {
            changeControlsIndex = true;
            ballTrail.colorGradient = gradient2;
            ballTrail.time = 0.6f;
            drunk.DrunkCam();
        }

    }

}
