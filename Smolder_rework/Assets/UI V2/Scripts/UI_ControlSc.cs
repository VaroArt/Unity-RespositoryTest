using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//0 y 1 es el panel de vida, 2 y 3 son las luces de recarga
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
    //public Canvas PanelesNave;
    public Canvas PanelNaveTexto;
    public Canvas PanelNaveInteraccion;
    public Canvas PanelNaveRadar;
    public Canvas PanelNaveRecarga;
    public Canvas PanelNavePausa;
    public Canvas PanelNaveDiario;
    public Canvas PanelNaveDiarioOff;
    public Canvas PanelNaveMisiones;
    public Canvas PanelNavePanelPerros;
    public Canvas PanelNaveDialogos;
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
public class BoolPanelesNave
{
    public bool ActivarPanelRadar;
    public bool ActivarPanelRecarga;
    public bool ActivarPanelDiario;
    public bool ActivarPanelInteraccion;
    public bool ActivarPanelTexto;
    public bool ActivarPanelPausa;
    public bool ActivarPanelTextoMisiones;
}

[System.Serializable]
public class VidayMunicionNave
{
    public bool VidaBaja;
    public bool MunicionCargada;
}

[System.Serializable]
public class PerrosHablando
{
    public bool hablando;
    public bool PanelPerrosActivo;
    public bool AstroHablando;
    public bool EdgarHablando;
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
