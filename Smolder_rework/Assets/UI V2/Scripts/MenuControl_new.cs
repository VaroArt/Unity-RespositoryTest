using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControl_new : MonoBehaviour
{
    public AppFunciones Botones;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Botones.Pantallaconfiguraciones();
    }

    public void BtonJugar()
    {
        Botones.JugarJuego();
    }

    public void BtonConfig()
    {
        Botones.FuncAbrirConfiguracion();
    }

    public void BtonConfigCerrar()
    {
        Botones.FuncCerrarConfiguracion();
    }

    public void BtonCreditos()
    {
        Botones.PantallaCreditos();
    }

    public void BtonSalir()
    {
        Botones.Exitgame();
    }

    public void BtonIG()
    {
        Botones.AbrirIG();
    }

    public void BtonFace()
    {
        Botones.AbrirFace();
    }

    //para los creditos
    public void BtonBacktoMenu()
    {
        Botones.Gotomenu();
    }
}
