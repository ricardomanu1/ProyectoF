using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public Text scoreText;
    public float score;
    public GameObject trofeo;
    public GameObject bola;
    //
    public Transform pivot;
    public Transform pivotTrofeo;

    // Start is called before the first frame update
    void Start()
    {
        score = 0f;
        scoreText.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void JugadorScored(string nombre)
    {
        if (nombre.Equals("Diana100"))
        {
            score+=100f;
            print(score);
        }
        if (nombre.Equals("Diana50"))
        {
            score+=50f;
            print(score);
        }

        if (nombre.Equals("Diana20"))
        {
            score+=20f;
            print(score);
        }
        scoreText.GetComponent<Text>().text = "Puntuación: " + score;
        if (score >= 400f)
        {
            GameObject trofeoNuevo = Instantiate(trofeo, pivotTrofeo.position, pivotTrofeo.rotation);
            trofeoNuevo.GetComponent<Rigidbody>();
        }else if (score <= -850)
        {
            scoreText.GetComponent<Text>().text = "Game Over";
            Reset();
        }
    }

    public void AnadirBola()
    {         
        GameObject bolaNueva = Instantiate(bola, pivot.position, pivot.rotation);
        bolaNueva.GetComponent<Rigidbody>();
        score -= 50f;
        scoreText.GetComponent<Text>().text = "Puntuación: " + score;
    }

    public void Reset()
    {
        SceneManager.LoadScene("Escena");
    }


}
