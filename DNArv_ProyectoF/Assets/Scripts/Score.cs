using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{
    private void Start()
    {

    }
    private void OnCollisionEnter(Collision c)
    {
        if (c.collider.tag == "Ball")
        {
            GameObject.Find("GameController").GetComponent<GameControl>().JugadorScored(this.name);
        }
    }
}
