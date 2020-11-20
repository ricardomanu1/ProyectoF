using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Reiniciar : MonoBehaviour
{
    public Button reiniciar;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = reiniciar.GetComponent<Button>();
        btn.onClick.AddListener(Reset);
    }

    void Reset()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene("Escena");
    }
}
