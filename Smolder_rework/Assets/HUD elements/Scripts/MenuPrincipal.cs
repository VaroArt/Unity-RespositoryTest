using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPrincipal : MonoBehaviour
{
    public bool canvasAjustes;
    public Canvas panelAjustes;

    // Update is called once per frame
    void Update()
    {
        SistemaAjustes();
    }

    //botones

    public void BotonPlay()
    {
        SceneManager.LoadScene("Game_Scene_Test");
    }

    public void BotonSalir()
    {
        Application.Quit();
    }

    public void AjustesOn()
    {
        canvasAjustes = true;
    }
    public void AjustesOff()
    {
        canvasAjustes = false;
    }

    //control ajustes

    public void ControlAjustes()
    {
        if (canvasAjustes == false)
        {
            canvasAjustes = true;
        }
        else
        {
            canvasAjustes = false;
        }
    }

    public void SistemaAjustes()
    {
        if (canvasAjustes == false)
        {
            panelAjustes.enabled = false;
        }
        if (canvasAjustes == true)
        {
            panelAjustes.enabled = true;
        }
    }

}
