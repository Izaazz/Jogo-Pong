using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

//Izabela Maria da Silva Fonseca
//Colegio Tecnico da UFMG

public class bulinha : MonoBehaviour
{
    public Rigidbody2D bolinha;
    public TextMeshProUGUI scoreText1;
    public TextMeshProUGUI scoreText2;
    public Vector2 direction;
    public float speed;
    public float increaseSpeedIndex;
    public AudioSource HitSound1;
    public AudioSource HitSound2;
    public AudioSource ScoreSound;
    public GameObject P1WinScreen;
    public GameObject P2WinScreen;
    public GameObject AIWinScreen;

    private Shake shake;
    private float Y;
    private int scoreP1;
    private int scoreP2;
    private int pointsToWin;

    private void Start()
    {

        if(pointsToWin == 0)
        {
            pointsToWin = 5;
        }

        P1WinScreen.SetActive(false);
        P2WinScreen.SetActive(false);
        AIWinScreen.SetActive(false);

        shake = GameObject.FindGameObjectWithTag("Shake").GetComponent<Shake>();

        scoreP1 = 0;
        scoreP2 = 0;
        increaseSpeedIndex = 1;

        Invoke("Direction", 1);
    }

    private void Update()
    {
        Score();
    }
        
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("P1Score"))
        {
            //Faz a câmera tremer, caso o modo bêbado esteja desativado
            if (!ToggleManager.drunkModeOn) {
                shake.CamShake();
            }

            ScoreSound.Play();

            scoreP1 += 1;

            if (scoreP1 == pointsToWin)
            {
                Player1win(true);
            }
            else
            {
                Restart(true);
                Inic(Vector2.right);
            }
        }

        if(collision.CompareTag("P2Score"))
        {
            if (!ToggleManager.drunkModeOn)
            {
                shake.CamShake();
            }
            ScoreSound.Play();

            scoreP2 += 1;

            if (scoreP2 == pointsToWin)
            {
                Player1win(false);
            }
            else
            {
                Restart(false);
                Inic(Vector2.left);
            }
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player1"))
        {
            HitSound1.Play();

            //Calcula o ângulo para onde a bolinha será rebatida
            float Y = Boost(transform.position.y, collision.transform.position.y, collision.collider.bounds.size.y);
            bolinha.velocity = (new Vector2(1, Y).normalized) * speed * increaseSpeedIndex;

            //Aumenta a velocidade da bolinha
            increaseSpeedIndex = IncreaseSpeed(increaseSpeedIndex);
        }

        if (collision.collider.CompareTag("Player2"))
        {
            HitSound1.Play();
            float Y = Boost(transform.position.y, collision.transform.position.y, collision.collider.bounds.size.y);
            bolinha.velocity = (new Vector2(-1, Y).normalized) * speed * increaseSpeedIndex;
            increaseSpeedIndex = IncreaseSpeed(increaseSpeedIndex);
        }

        if (collision.collider.CompareTag("Walls"))
        {
            HitSound2.Play();
        }
    }

    private void Direction()
    {
        //Direção para onde a bola irá começar
        direction = Vector2.left;
        Inic(direction);
    }

    private float Boost(float ballPositionY, float playerPositionY, float playerHeight)
    {
        return ((ballPositionY - playerPositionY)/playerHeight);
    }

    private void Inic(Vector2 direction)
    {
        bolinha.velocity = Vector2.zero;
        direction.y = Random.Range(-0.5f, 0.5f);
        bolinha.velocity = direction * speed;
    }

    private void Restart(bool P1Score)
    {
        Y = Random.Range(-3, 3);
        increaseSpeedIndex = 1;

        if (P1Score) {
            transform.position = new Vector2(-3, Y);
        }
        else
        {
            transform.position = new Vector2(3, Y);
        }
    }

    private void Score()
    {
        if (scoreP1 < 10) scoreText1.text = "0" + scoreP1.ToString();
        else scoreText1.text = scoreP1.ToString();

        if (scoreP2 < 10) scoreText2.text = "0" + scoreP2.ToString();
        else scoreText2.text = scoreP2.ToString();
    }

    private float IncreaseSpeed(float increaseSpeedIndex)
    {
        //Se a opção "Increase Speed" estiver ativada,
        //atualiza o valor do float "increaseSpeedIndex"
        if (ToggleManager.increaseSpeedOn)
        {
            if (increaseSpeedIndex < 1.15f)
            {
                return increaseSpeedIndex *= 1.02f;
            }
            else
            {
                return increaseSpeedIndex += 0.02f;
            }
        }
        else
        {
            return 1;
        }
    }
    private void Player1win(bool P1win)
    {

        if (P1win)
        {
            P1WinScreen.SetActive(true);
        }
        if (!P1win)
        {
            if (SceneManager.GetActiveScene().name.Equals("PongIA"))
            {
                AIWinScreen.SetActive(true);
            }
            else
            {
                P2WinScreen.SetActive(true);
            }
        }
    }
}