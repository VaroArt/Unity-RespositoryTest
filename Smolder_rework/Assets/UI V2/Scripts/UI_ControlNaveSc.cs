using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ControlNaveSc : MonoBehaviour
{
    public ControlCanvasNave CanvasNave;
    public BoolPanelesNave ControlPanelesNave;
    public VidayMunicionNave ControlEstadoNave;
    public PerrosHablando controlTextoNave;
    public List<ImagenTextoPerros> ImagenesPerros;
    public List<ObjControlDeColorNave> ObjsColorNave;
    public List<ControlDialogos> Dialogos;
    public LlamarDialogos ControlDialogos;

    public SistemaBengala Municion;
    public Throw_Flare_Manager manager;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        PanelRadar();
        PanelRecarga();
        PanelDiario();
        PanelBotonTexto();
        PanelBotonInteraccion();
        PanelMisiones();
        PanelPausa();
        PanelPerros();
        EdgarHablando();
        AstroHablando();
        PanelDialogos();
        VidaBaja();
        MunicionCargada();
    }

    //Control De UI
    void PanelRadar()
    {
        if(ControlPanelesNave.ActivarPanelRadar == false)
        {
            CanvasNave.PanelNaveRadar.enabled = false;
        }
        if(ControlPanelesNave.ActivarPanelRadar == true)
        {
            CanvasNave.PanelNaveRadar.enabled = true;
        }
    }

    void PanelRecarga()
    {
        if(ControlPanelesNave.ActivarPanelRecarga == false)
        {
            CanvasNave.PanelNaveRecarga.enabled = false;
        }
        if(ControlPanelesNave.ActivarPanelRecarga == true)
        {
            CanvasNave.PanelNaveRecarga.enabled = true;
        }
    }

    void PanelDiario()
    {
        if(ControlPanelesNave.ActivarPanelDiario == false)
        {
            CanvasNave.PanelNaveDiario.enabled = false;
            CanvasNave.PanelNaveDiarioOff.enabled = true;
        }
        if(ControlPanelesNave.ActivarPanelDiario == true)
        {
            CanvasNave.PanelNaveDiario.enabled = true;
            CanvasNave.PanelNaveDiarioOff.enabled = false;
        }
    }

    void PanelBotonTexto()
    {
        if(ControlPanelesNave.ActivarPanelTexto == false)
        {
            CanvasNave.PanelNaveTexto.enabled = false;
        }
        if(ControlPanelesNave.ActivarPanelTexto == true)
        {
            CanvasNave.PanelNaveTexto.enabled = true;
        }
    }

    void PanelBotonInteraccion()
    {
        if(ControlPanelesNave.ActivarPanelInteraccion == false)
        {
            CanvasNave.PanelNaveInteraccion.enabled = false;
        }
        if(ControlPanelesNave.ActivarPanelInteraccion == true)
        {
            CanvasNave.PanelNaveInteraccion.enabled = true;
        }
    }

    void PanelMisiones()
    {
        if(ControlPanelesNave.ActivarPanelTextoMisiones == false)
        {
            CanvasNave.PanelNaveMisiones.enabled = false;
        }
        if(ControlPanelesNave.ActivarPanelTextoMisiones == true)
        {
            CanvasNave.PanelNaveMisiones.enabled = true;
        }
    }

    void PanelPausa()
    {
        if(ControlPanelesNave.ActivarPanelPausa == false)
        {
            CanvasNave.PanelNavePausa.enabled = false;
        }
        if(ControlPanelesNave.ActivarPanelPausa == true)
        {
            CanvasNave.PanelNavePausa.enabled = true;
        }
    }

    void PanelPerros()
    {
        if(controlTextoNave.PanelPerrosActivo == true)
        {
            CanvasNave.PanelNavePanelPerros.enabled = true;
        }
        if(controlTextoNave.PanelPerrosActivo == false)
        {
            CanvasNave.PanelNavePanelPerros.enabled = false;
        }
    }

    void AstroHablando()
    {
        if (controlTextoNave.AstroHablando == true)
        {
            ImagenesPerros[0].PerrosNombre.enabled = true;
            ImagenesPerros[0].PerrosImg.enabled = true;
        }
        if (controlTextoNave.AstroHablando == false)
        {
            ImagenesPerros[0].PerrosNombre.enabled = false;
            ImagenesPerros[0].PerrosImg.enabled = false;
        }
    }

    void EdgarHablando()
    {
        if (controlTextoNave.EdgarHablando == true)
        {
            ImagenesPerros[1].PerrosNombre.enabled = true;
            ImagenesPerros[1].PerrosImg.enabled = true;
        }
        if (controlTextoNave.EdgarHablando == false)
        {
            ImagenesPerros[1].PerrosNombre.enabled = false;
            ImagenesPerros[1].PerrosImg.enabled = false;
        }
    }

    void PanelDialogos()
    {
        if(controlTextoNave.hablando == false)
        {
            CanvasNave.PanelNaveDialogos.enabled = false;
        }
        if(controlTextoNave.hablando == true)
        {
            CanvasNave.PanelNaveDialogos.enabled = true;
        }
    }

    //funciones
    void VidaBaja()
    {
        if(ControlEstadoNave.VidaBaja == true)
        {
            ObjsColorNave[0].ObjetoARenderear.SetColor(ObjsColorNave[0].ColorActivo);
            ObjsColorNave[1].ObjetoARenderear.SetColor(ObjsColorNave[1].ColorActivo);
        }
        if(ControlEstadoNave.VidaBaja == false)
        {
            ObjsColorNave[0].ObjetoARenderear.SetColor(ObjsColorNave[0].ColorInactivo);
            ObjsColorNave[1].ObjetoARenderear.SetColor(ObjsColorNave[1].ColorInactivo);
        }
    }

    void MunicionCargada()
    {
        if(ControlEstadoNave.MunicionCargada == true)
        {
            ObjsColorNave[2].ObjetoARenderear.SetColor(ObjsColorNave[2].ColorActivo);
            ObjsColorNave[3].ObjetoARenderear.SetColor(ObjsColorNave[3].ColorActivo);
        }
        if(ControlEstadoNave.MunicionCargada == false)
        {
            ObjsColorNave[2].ObjetoARenderear.SetColor(ObjsColorNave[2].ColorInactivo);
            ObjsColorNave[3].ObjetoARenderear.SetColor(ObjsColorNave[3].ColorInactivo);
        }
    }

    //Botones
    public void BotonDeRadar()
    {
        if(ControlPanelesNave.ActivarPanelRadar == false)
        {
            ControlPanelesNave.ActivarPanelRadar = true;
        }
        else
        {
            ControlPanelesNave.ActivarPanelRadar = false;
        }
    }

    public void BotonDeRecarga()
    {
        if(ControlPanelesNave.ActivarPanelRecarga == false)
        {
            ControlPanelesNave.ActivarPanelRecarga = true;
        }
        else
        {
            ControlPanelesNave.ActivarPanelRecarga = false;
        }

    }

    public void BotonDeDiario()
    {
        if(ControlPanelesNave.ActivarPanelDiario == false)
        {
            ControlPanelesNave.ActivarPanelDiario = true;
        }
        else
        {
            ControlPanelesNave.ActivarPanelDiario = false;
        }
    }
}
