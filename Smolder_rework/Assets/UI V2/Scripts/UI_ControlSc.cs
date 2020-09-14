﻿using System.Collections;
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