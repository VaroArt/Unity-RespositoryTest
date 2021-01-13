using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//0, 1 y 2 es el panel de vida, 
//3 es la luzs de recarga
//4 y 5 son las luces del dron
[System.Serializable]
public class ObjControlDeColorNave
{
    public CanvasRenderer ObjetoARenderear;
    public Color ColorActivo;
    public Color ColorInactivo;
}

[System.Serializable]
public class ControlCanvasNave
{
    public Canvas PanelNaveTexto;
    public Canvas PanelNaveInteraccion;
    public Canvas PanelNaveRadar;
    public Canvas PanelNaveRecarga;
    public Canvas PanelNavePanelPerros;
    public Canvas PanelNaveDialogos;
    public Canvas PanelNaveInventario;
}

[System.Serializable]
public class BoolPanelesNave
{
    public bool ActivarPanelRadar;
    public bool ActivarPanelRecarga;
    public bool ActivarPanelInteraccion;
    public bool ActivarPanelTexto;
    public bool ActivarPanelInventario;
    
}

//0 es boton interactuar e interaccion activa
// 1, 2, 3 o mas son el resto de dialogos
[System.Serializable]
public class ControlDialogos
{
    public bool Dialogos;
    public int DialogoInteractive;
}

[System.Serializable]
public class VidayMunicionNave
{
    public bool VidaBaja;
    //public bool MunicionCargada;
    public bool EstadoDron;
}

[System.Serializable]
public class PerrosHablando
{
    public bool hablando;
    public bool PanelPerrosActivo;
    public bool AstroHablando;
    public bool EdgarHablando;
    [Space(10)]
    public List<ImagenTextoPerros> ImagenesPerros;
}

//0 es Atro, 1 es edgar
[System.Serializable]
public class ImagenTextoPerros
{
    public Image PerrosImg;
    public Text PerrosNombre;
}

[System.Serializable]
public class LlamarDialogos
{
    //public player_triggers player;
    public DialogueManager dialogoManager;
}

//Zona de Sistemas especificos

[System.Serializable]
public class DiarioyMisiones
{
    public Canvas PanelNaveDiario;
    public Canvas PanelNaveDiarioOff;
    public Canvas PanelNaveMisiones;
    [Space(10)]
    public bool ActivarPanelDiario;
    public bool ActivarPanelTextoMisiones;

    public void ActivadorDiario()
    {
        if (ActivarPanelDiario == false)
        {
            ActivarPanelDiario = true;
        }
        else
        {
            ActivarPanelDiario = false;
        }
    }
    public void OnOffPanelDiario()
    {
        if (ActivarPanelDiario == false)
        {
            PanelNaveDiario.enabled = false;
            PanelNaveDiarioOff.enabled = true;
        }
        if (ActivarPanelDiario == true)
        {
            PanelNaveDiario.enabled = true;
            PanelNaveDiarioOff.enabled = false;
        }
    }
    public void OnOffPanelMisiones()
    {
        if (ActivarPanelTextoMisiones == false)
        {
            PanelNaveMisiones.enabled = false;
        }
        if (ActivarPanelTextoMisiones == true)
        {
            PanelNaveMisiones.enabled = true;
        }
    }
}

[System.Serializable]
public class SystemaPausa
{
    public Canvas PanelNavePausa;
    [Space(10)]
    public bool ActivarPanelPausa;

    public void ControlPausa()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if(ActivarPanelPausa == false)
            {
                ActivarPanelPausa = true;
            }
            else
            {
                ActivarPanelPausa = false;
            }
        }
        else
        {
            return;
        }
    }
    public void ControlPausaBton()
    {
        if (ActivarPanelPausa == false)
        {
            ActivarPanelPausa = true;
        }
        else
        {
            ActivarPanelPausa = false;
        }
    }
    public void OnOffPanelPausa()
    {
        if (ActivarPanelPausa == false)
        {
            //Debug.Log("Play");
            PanelNavePausa.enabled = false;
            Time.timeScale = 1;
        }
        if (ActivarPanelPausa == true)
        {
            //Debug.Log("Stop");
            Time.timeScale = 0;
            PanelNavePausa.enabled = true;
        }
    }
}

//Zona de Funciones de Aplicacion

[System.Serializable]
public class AppFunciones
{
    public Canvas PantallaConfig;
    public bool ConfiguracionAbierta;

    public void JugarJuego()
    {
        SceneManager.LoadScene("UI_LoadScene");
    }

    public void PantallaCreditos()
    {
        SceneManager.LoadScene("UI_Credits");
    }

    public void FuncAbrirConfiguracion()
    {
        ConfiguracionAbierta = true;
    }

    public void Pantallaconfiguraciones()
    {
        if (ConfiguracionAbierta == true)
        {
            PantallaConfig.enabled = true;
        }

        if(ConfiguracionAbierta == false)
        {
            PantallaConfig.enabled = false;
        }
    }

    public void FuncCerrarConfiguracion()
    {
        ConfiguracionAbierta = false;
    }

    public void Exitgame()
    {
        Application.Quit();
    }

    public void AbrirIG()
    {
        Application.OpenURL("https://www.instagram.com/dimensions.games/");
    }

    public void AbrirFace()
    {
        Application.OpenURL("https://www.facebook.com/Dimensions-Games-101686981606579");
    }

    public void Gotomenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("UI_Menu");
    }
}

[System.Serializable]
public class Dialogos
{
    public int id;

    [TextArea(10, 10)]
    public string[] listaDeSentencias;
}

[System.Serializable]
public class DronFuncion
{
    public GameObject sistemadron;
    public bool erroractivo;
    public float timer;
    public float count;

    public void FuncionError()
    { 
        erroractivo = true;
    }

    public void Errorupdate()
    {
        if(erroractivo == true)
        {
            sistemadron.SetActive(true);
            timer += 1 * Time.deltaTime;
        }

        if(timer >= count)
        {
            erroractivo = false;
            sistemadron.SetActive(false);
            timer = 0f;
        }
    }
}

[System.Serializable]
public class OpcionesTurboYLinterna
{
    public Canvas IndicadorLuz;
    public Image BotonLuz;
    public Canvas IndicadorMotor;
    [Space(10)]
    public Image[] FlechaFuncionLuz;
    [Space(10)]
    public Image[] FlechaFuncionMotor;
    [Space(10)]
    public bool InfoLuzActiva;
    public bool InfoMotorActiva;
}

[System.Serializable]
public class TurboSystem
{
    public Image TurboBar;
}
[System.Serializable]
public class Linterna
{
    public Image LinternaBar;   
}
[System.Serializable]
public class Invetario
{
    public Text TurboText;
    public Text BengalaText; 
}

[System.Serializable]
public class TutorialElements
{
    public Image[] Paneles;
    [Space(10)]
    public Canvas CanvasTexto1;
    public Canvas CanvasTexto2;
    public Image Mision;
    public GameObject nextbton;
    [Space(10)]
    [Header("control de Paneles")]
    public Text[] TextosPaneles1;
    public Text[] TextosPaneles2;
    [Space(10)]
    public Image[] ImgPaneles1;
    public Image[] ImgPaneles2;
    [Space(10)]
    [Header("Activadores de Pantallas")]
    public bool TutoBtonRecarga;
    public bool TutopanelRegarga;
    public bool TutoBtonRadar;
    public bool TutoPanelRadar;
    public bool TutoBtonInventario;
    public bool TutoPanelInventario;
    public bool TutoBtonDron;
    public bool TutoPanelVida;
    public bool TutoPanelCentral;
    [Space(5)]
    public bool TutoBtonLuz;
    public bool TutoFuncionLuz;
    public bool TutoBtonMotor;
    public bool TutoFuncionMotor;
    [Space(10)]
    public bool Texto1Activo;
    public bool Texto2Activo;
    public bool nextBtonact;
    public bool MisionAct;
    [Space(10)]
    public bool IsEdgar1Act;
    public bool IsAstro1Act;
    public bool IsEdgar2Act;
    public bool IsAstro2Act;
}



public class UI_ControlSc : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


