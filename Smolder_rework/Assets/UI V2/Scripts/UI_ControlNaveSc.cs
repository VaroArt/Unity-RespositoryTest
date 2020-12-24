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
    public DronFuncion SistemaDelDron;
    [Header("Dialogos")]
    public PerrosHablando controlTextoNave;
    public List<ControlDialogos> Dialogos;
    public LlamarDialogos ControlDialogos;
    [Header("Recarga")]
    public BengalSystem Municion;
    public AppFunciones extras;
    [Header("control Turbo y luz")]
    public OpcionesTurboYLinterna OpcionesMYL;
    public TurboSystem Turbo;
    public Linterna LinternaNave;
    [Header("Inventario")]
    public Invetario inventario;


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
        PanelInventario();
        EdgarHablando();
        AstroHablando();
        PanelDialogos();
        VidaBaja();
        MunicionCargada();
        Estadodeldron();
        ControlPausa.ControlPausa();
        SistemaDelDron.Errorupdate();
        BengalaInventario();
        ControlLuces();
        ControlMotores();
    }

    //Control De UI
    void PanelRadar()
    {
        if (ControlPanelesNave.ActivarPanelRadar == false)
        {
            CanvasNave.PanelNaveRadar.enabled = false;
        }
        if (ControlPanelesNave.ActivarPanelRadar == true)
        {
            CanvasNave.PanelNaveRadar.enabled = true;
        }
    }
    void PanelRecarga()
    {
        if (ControlPanelesNave.ActivarPanelRecarga == false)
        {
            CanvasNave.PanelNaveRecarga.enabled = false;
        }
        if (ControlPanelesNave.ActivarPanelRecarga == true)
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
        if (ControlPanelesNave.ActivarPanelTexto == false)
        {
            CanvasNave.PanelNaveTexto.enabled = false;
        }
        if (ControlPanelesNave.ActivarPanelTexto == true)
        {
            CanvasNave.PanelNaveTexto.enabled = true;
        }
    }
    void PanelBotonInteraccion()
    {
        if (ControlPanelesNave.ActivarPanelInteraccion == false)
        {
            CanvasNave.PanelNaveInteraccion.enabled = false;
        }
        if (ControlPanelesNave.ActivarPanelInteraccion == true)
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
        if (controlTextoNave.PanelPerrosActivo == true)
        {
            CanvasNave.PanelNavePanelPerros.enabled = true;
        }
        if (controlTextoNave.PanelPerrosActivo == false)
        {
            CanvasNave.PanelNavePanelPerros.enabled = false;
        }
    }
    void PanelInventario()
    {
        if(ControlPanelesNave.ActivarPanelInventario == false)
        {
            CanvasNave.PanelNaveInventario.enabled = false;
        }

        if (ControlPanelesNave.ActivarPanelInventario == true)
        {
            CanvasNave.PanelNaveInventario.enabled = true;
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
        if (controlTextoNave.hablando == false)
        {
            CanvasNave.PanelNaveDialogos.enabled = false;
        }
        if (controlTextoNave.hablando == true)
        {
            CanvasNave.PanelNaveDialogos.enabled = true;
        }
    }

    void ControlLuces()
    {
        if(OpcionesMYL.InfoLuzActiva == true)
        {
            OpcionesMYL.IndicadorLuz.enabled = true;
            OpcionesMYL.BotonLuz.enabled = true;
            OpcionesMYL.FlechaFuncionLuz[0].enabled = false;
            OpcionesMYL.FlechaFuncionLuz[1].enabled = true;
        }
        if(OpcionesMYL.InfoLuzActiva == false)
        {
            OpcionesMYL.IndicadorLuz.enabled = false;
            OpcionesMYL.BotonLuz.enabled = false;
            OpcionesMYL.FlechaFuncionLuz[0].enabled = true;
            OpcionesMYL.FlechaFuncionLuz[1].enabled = false;
        }
    }

    void ControlMotores()
    {
        if(OpcionesMYL.InfoMotorActiva == true)
        {
            OpcionesMYL.IndicadorMotor.enabled = true;
            OpcionesMYL.FlechaFuncionMotor[0].enabled = false;
            OpcionesMYL.FlechaFuncionMotor[1].enabled = true;
        }
        if(OpcionesMYL.InfoMotorActiva == false)
        {
            OpcionesMYL.IndicadorMotor.enabled = false;
            OpcionesMYL.FlechaFuncionMotor[0].enabled = true;
            OpcionesMYL.FlechaFuncionMotor[1].enabled = false;
        }
    }

    //funciones
    void VidaBaja()
    {
        if (ControlEstadoNave.VidaBaja == true)
        {
            ObjsColorNave[0].ObjetoARenderear.SetColor(ObjsColorNave[0].ColorActivo);
            ObjsColorNave[1].ObjetoARenderear.SetColor(ObjsColorNave[1].ColorActivo);
            ObjsColorNave[2].ObjetoARenderear.SetColor(ObjsColorNave[2].ColorActivo);
        }
        if (ControlEstadoNave.VidaBaja == false)
        {
            ObjsColorNave[0].ObjetoARenderear.SetColor(ObjsColorNave[0].ColorInactivo);
            ObjsColorNave[1].ObjetoARenderear.SetColor(ObjsColorNave[1].ColorInactivo);
            ObjsColorNave[2].ObjetoARenderear.SetColor(ObjsColorNave[2].ColorInactivo);
        }
    }
    void MunicionCargada()
    {
        if (municionCargada == true)
        {
            ObjsColorNave[3].ObjetoARenderear.SetColor(ObjsColorNave[3].ColorActivo);
        }
        if (municionCargada == false)
        {
            ObjsColorNave[3].ObjetoARenderear.SetColor(ObjsColorNave[3].ColorInactivo);
        }
    }
    void Estadodeldron()
    {
        if (ControlEstadoNave.EstadoDron == true)
        {
            ObjsColorNave[4].ObjetoARenderear.SetColor(ObjsColorNave[4].ColorActivo);
            ObjsColorNave[5].ObjetoARenderear.SetColor(ObjsColorNave[5].ColorActivo);
        }
        if (ControlEstadoNave.EstadoDron == false)
        {
            ObjsColorNave[4].ObjetoARenderear.SetColor(ObjsColorNave[4].ColorInactivo);
            ObjsColorNave[5].ObjetoARenderear.SetColor(ObjsColorNave[5].ColorInactivo);
        }
    }

    //Botones
    public void BotonDeRadar()
    {
        if (ControlPanelesNave.ActivarPanelRadar == false)
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
        if (ControlPanelesNave.ActivarPanelRecarga == false)
        {
            ControlPanelesNave.ActivarPanelRecarga = true;
            if (Municion.canShoot == 1)
            {
                Municion.Ran();
                Municion.Fire = Municion.RandomN;     
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
        if (Municion.CantBengalas == 0)
        {
            //  print("no bullet");
            Municion.Error.SetActive(true);
            Municion.RandomN = 0;
        }
        else 
        {
            Municion.Error.SetActive(false);
        } 
    }
    public void BotonRecargaCentro()
    {
        if (municionCargada)
        {         
            Municion.Shoot();
            Municion.AmmoCount = 0;
            Municion.canShoot = 0;
            Municion.CantBengalas--;
            ControlPanelesNave.ActivarPanelRecarga = false;
            Municion.canShoot = 1;
            Municion.buttonRecarga1 = 0;
            Municion.buttonRecarga2 = 0;
            Municion.buttonRecarga3 = 0;
            Municion.buttonRecarga4 = 0;
            //delete here
            Municion.luces[0].SetColor(Municion.colorInactivo);
            Municion.luces[1].SetColor(Municion.colorInactivo);
            Municion.luces[2].SetColor(Municion.colorInactivo);
            Municion.luces[3].SetColor(Municion.colorInactivo);
            municionCargada = false;
        }
        else
        {
            print("No ammo");
        }
    }
    public void BotonDeDisparo()
    {
        if (municionCargada == true)
        {
            Municion.Shoot();
            Municion.AmmoCount = 0;
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
    public void BotonInventario()
    {
        if (ControlPanelesNave.ActivarPanelInventario == false)
        {
            ControlPanelesNave.ActivarPanelInventario = true;
        }
        else
        {
            ControlPanelesNave.ActivarPanelInventario = false;
        }
    }
    public void BotonInfoLuz()
    {
        if(OpcionesMYL.InfoLuzActiva == false)
        {
            OpcionesMYL.InfoLuzActiva = true;
        }
        else
        {
            OpcionesMYL.InfoLuzActiva = false;
        }
    }

    public void BotonInfoMotor()
    {
        if(OpcionesMYL.InfoMotorActiva == false)
        {
            OpcionesMYL.InfoMotorActiva = true;
        }
        else
        {
            OpcionesMYL.InfoMotorActiva = false;
        }
    }

    public void BengalaInventario()
    {
        inventario.BengalaText.text = "X " + Municion.CantBengalas.ToString();
    }
    public void BtonDron()
    {
        SistemaDelDron.FuncionError();
    }

    public void btonsalir()
    {
        extras.Exitgame();
    }

    public void btonmenu()
    {
        extras.Gotomenu();
    }
}
