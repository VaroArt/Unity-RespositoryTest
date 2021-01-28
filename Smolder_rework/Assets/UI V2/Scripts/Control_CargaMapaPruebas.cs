using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Control_CargaMapaPruebas : MonoBehaviour
{
    public bool cargaActiva;
    public float TiempoCarga;

    // Start is called before the first frame update
    void Start()
    {
        cargaActiva = true;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (cargaActiva == true)
        {
            TiempoCarga += 1 * Time.deltaTime;

            if (TiempoCarga >= 5)
            {
                TiempoCarga = 0f;
                SceneManager.LoadScene("Testeo pipe");
            }
        }
    }
}
