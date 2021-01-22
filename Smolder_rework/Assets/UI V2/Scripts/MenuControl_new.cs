using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl_new : MonoBehaviour
{
    public float TiempoFade;
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
        Botones.PantallaSelector();
    }

    /*public void BtonJugar()
    {
        Botones.JugarJuego();
        Invoke("CambiarEscena", TiempoFade);
    }*/

    public void BtonAbrirSelector()
    {
        Botones.FuncAbrirSelector();
    }

    public void PlayTutorial()
    {
        Botones.PlayFade();
        Invoke("CambiarEscenaTutorial", TiempoFade);
    }

    public void PlayPruebas()
    {
        Botones.PlayFade();
        Invoke("CambiarEscenaPrueba", TiempoFade);
    }

    public void CambiarEscenaTutorial()
    {
        SceneManager.LoadScene("UI_LoadScene");
    }

    public void CambiarEscenaPrueba()
    {
        SceneManager.LoadScene("LoadScenePruebas");
    }

    public void BtonConfig()
    {
        Botones.FuncAbrirConfiguracion();
    }

    public void BtonConfigCerrar()
    {
        Botones.FuncCerrarConfiguracion();
    }

    public void BtonCerrarSelector()
    {
        Botones.FuncCerrarSelector();
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

    public void BtonFeedback()
    {
        Botones.AbrirFeedback();
    }

    //para los creditos
    public void BtonBacktoMenu()
    {
        Botones.Gotomenu();
    }
}
