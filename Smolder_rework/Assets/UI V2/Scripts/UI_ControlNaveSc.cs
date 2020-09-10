using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ControlNaveSc : MonoBehaviour
{
    [Header("Opciones de nave")]
    public bool municionCargada;

    [Header("Controles Exclusivos Nave")]
    public ControlCanvasNave CanvasNave;
    public BoolPanelesNave ControlPanelesNave;
    public VidayMunicionNave ControlEstadoNave;
    public List<ObjControlDeColorNave> ObjsColorNave;
    [Header("Controles generales")]
    public DiarioyMisiones ControlMisiones;
    public SystemaPausa ControlPausa;
    [Header("Dialogos")]
    public PerrosHablando controlTextoNave;
    public List<ControlDialogos> Dialogos;
    public LlamarDialogos ControlDialogos;
    [Header("Recarga")]
    public SistemaBengala Municion;
    public Throw_Flare_Manager manager;
    [Header("Control Nueva Bengala")]
    public SystemaDeBengalas nuevasBengalas;

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
        Estadodeldron();
        ControlPausa.ControlPausa();
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
        ControlMisiones.OnOffPanelDiario();
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
        ControlMisiones.OnOffPanelMisiones();
    }
    void PanelPausa()
    {
        ControlPausa.OnOffPanelPausa();
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
            controlTextoNave.ImagenesPerros[0].PerrosNombre.enabled = true;
            controlTextoNave.ImagenesPerros[0].PerrosImg.enabled = true;
        }
        if (controlTextoNave.AstroHablando == false)
        {
            controlTextoNave.ImagenesPerros[0].PerrosNombre.enabled = false;
            controlTextoNave.ImagenesPerros[0].PerrosImg.enabled = false;
        }
    }
    void EdgarHablando()
    {
        if (controlTextoNave.EdgarHablando == true)
        {
            controlTextoNave.ImagenesPerros[1].PerrosNombre.enabled = true;
            controlTextoNave.ImagenesPerros[1].PerrosImg.enabled = true;
        }
        if (controlTextoNave.EdgarHablando == false)
        {
            controlTextoNave.ImagenesPerros[1].PerrosNombre.enabled = false;
            controlTextoNave.ImagenesPerros[1].PerrosImg.enabled = false;
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
        if(municionCargada == true)
        {
            ObjsColorNave[2].ObjetoARenderear.SetColor(ObjsColorNave[2].ColorActivo);
            ObjsColorNave[3].ObjetoARenderear.SetColor(ObjsColorNave[3].ColorActivo);
        }
        if(municionCargada == false)
        {
            ObjsColorNave[2].ObjetoARenderear.SetColor(ObjsColorNave[2].ColorInactivo);
            ObjsColorNave[3].ObjetoARenderear.SetColor(ObjsColorNave[3].ColorInactivo);
        }
    }
    void Estadodeldron()
    {
        if(ControlEstadoNave.EstadoDron == true)
        {
            ObjsColorNave[4].ObjetoARenderear.SetColor(ObjsColorNave[4].ColorActivo);
        }
        if (ControlEstadoNave.EstadoDron == false)
        {
            ObjsColorNave[4].ObjetoARenderear.SetColor(ObjsColorNave[4].ColorInactivo);
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
            if(manager.canShoot == 1)
            {
                Municion.ran();
                Municion.Fire = Municion.rand;
            }
        }
        else
        {
            ControlPanelesNave.ActivarPanelRecarga = false;
            Municion.buttonRecarga1 = 0;
            Municion.buttonRecarga2 = 0;
            Municion.buttonRecarga3 = 0;
            Municion.buttonRecarga4 = 0;
        }
    }
    public void BotonRecargaCentro()
    {
        if(Municion.buttonRecarga1 + Municion.buttonRecarga2 + Municion.buttonRecarga3 + Municion.buttonRecarga4 == Municion.Fire)
        {
            print("Fire");
            manager.AmmoCount++;
            manager.canShoot = 0;
        }
        else
        {
            print("No ammo");
        }
    }
    public void BotonDeDisparo()
    {
        if(municionCargada == true)
        {
            manager.Shoot();
            manager.AmmoCount = -1;
            municionCargada = false;
        }
        else
        {
            return;
        }
    }
    public void BotonDiario()
    {
        ControlMisiones.ActivadorDiario();
    }
    public void BotonPausaReaunudar()
    {
        ControlPausa.ControlPausaBton();
    }
}
