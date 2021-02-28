using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl_new : MonoBehaviour
{
    public float TiempoFade;
    public float TiempoFadeLoad;
    
    public AppFunciones Botones;

    

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Botones.PantallaSelector();
    }

    public void BtonAbrirSelector()
    {
        Botones.FuncAbrirSelector();
    }

    public void PlayTutorial()
    {
        Botones.PlayFade();
        Invoke("InicioCargaTutorial", TiempoFade);
    }

    public void InicioCargaTutorial()
    {
        Botones.PanelCarga.enabled = true;
        Invoke("CambiarEscenaTutorial", TiempoFadeLoad);
    }

    public void CambiarEscenaTutorial()
    {
        //SceneManager.LoadScene("UI_LoadScene");
        SceneManager.LoadScene("Tutorial");
    }

    public void PlayPruebas()
    {
        Botones.PlayFade();
        Invoke("InicioCargaMapaPruebas", TiempoFade);
    }
    public void PlayFinal()
    {
        Botones.PlayFade();
        Invoke("InicioCargaMapaFinal", TiempoFade);
    }

    public void InicioCargaMapaPruebas()
    {
        Botones.PanelCarga.enabled = true;
        Invoke("CambiarEscenaPrueba", TiempoFadeLoad);
    }

    public void CambiarEscenaPrueba()
    {
        //SceneManager.LoadScene("LoadScenePruebas");
        SceneManager.LoadScene("Testeo pipe");
    }
    public void InicioCargaMapaFinal()
    {
        Botones.PanelCarga.enabled = true;
        Invoke("CambiarEscenaFinal", TiempoFadeLoad);
    }
    public void CambiarEscenaFinal()
    {
        //SceneManager.LoadScene("UI_LoadScene");
        SceneManager.LoadScene("Final");
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
