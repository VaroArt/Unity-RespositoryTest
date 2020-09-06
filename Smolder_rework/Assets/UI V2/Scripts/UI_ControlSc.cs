using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

[System.Serializable]
public class ControlDialogos
{
    public bool Dialogos;
    public int DialogoInteractive;
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
