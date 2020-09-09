using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//0 y 1 es el panel de vida, 
//2 y 3 son las luces de recarga
//4 es la luz del dron
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
}

[System.Serializable]
public class BoolPanelesNave
{
    public bool ActivarPanelRadar;
    public bool ActivarPanelRecarga;
    public bool ActivarPanelInteraccion;
    public bool ActivarPanelTexto;
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
    public player_triggers player;
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

//Sistema nuevo de bengala
[System.Serializable]
public class SystemaDeBengalas
{
    public int[] BotonesDeRecarga;
    public CanvasRenderer[] luces;
    public Color colorVerde;
    public Color colorRojo;
    public Color colorInactivo;
    int FinalNum;
    public int RandomN;
    public int fuego;
    
    int FuncGetRandom(int min, int max)
    {
        RandomN = Random.Range(min, max);
        while (RandomN == FinalNum)
            RandomN = Random.Range(min, max);
        FinalNum = RandomN;
        return RandomN;
    }

    public void FuncRan()
    {
        FuncGetRandom(1, 5);
        switch (RandomN)
        {
            case 1:
                luces[0].SetColor(colorRojo);
                luces[1].SetColor(colorInactivo);
                luces[2].SetColor(colorInactivo);
                luces[3].SetColor(colorInactivo);
                break;
            case 2:
                luces[0].SetColor(colorRojo);
                luces[1].SetColor(colorRojo);
                luces[2].SetColor(colorInactivo);
                luces[3].SetColor(colorInactivo);
                break;
            case 3:
                luces[0].SetColor(colorRojo);
                luces[1].SetColor(colorRojo);
                luces[2].SetColor(colorRojo);
                luces[3].SetColor(colorInactivo);
                break;
            case 4:
                luces[0].SetColor(colorRojo);
                luces[1].SetColor(colorRojo);
                luces[2].SetColor(colorRojo);
                luces[3].SetColor(colorRojo);
                break;
        }
    }

    public void Btn1Press()
    {
        if(RandomN == 1||RandomN == 2||RandomN == 3||RandomN == 4)
        {
            BotonesDeRecarga[0]++;
            luces[0].SetColor(colorVerde);
            if(BotonesDeRecarga[0] > 1)
            {
                BotonesDeRecarga[0] = 1;
            }
        }
    }
    public void Btn2Press()
    {
        if (RandomN == 2 || RandomN == 3 || RandomN == 4)
        {
            BotonesDeRecarga[1]++;
            luces[1].SetColor(colorVerde);
            if (BotonesDeRecarga[1] > 1)
            {
                BotonesDeRecarga[1] = 1;
            }
        }
    }
    public void Btn3Press()
    {
        if (RandomN == 3 || RandomN == 4)
        {
            BotonesDeRecarga[2]++;
            luces[2].SetColor(colorVerde);
            if (BotonesDeRecarga[2] > 1)
            {
                BotonesDeRecarga[2] = 1;
            }
        }
    }
    public void Btn4Press()
    {
        if (RandomN == 4)
        {
            BotonesDeRecarga[3]++;
            luces[3].SetColor(colorVerde);
            if (BotonesDeRecarga[3] > 1)
            {
                BotonesDeRecarga[3] = 1;
            }
        }
    }
}

//Zona de Funciones de Aplicacion

[System.Serializable]
public class AppFunciones
{
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
