using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

[System.Serializable]
public class ControlColor
{
    public Image obj;
    public CanvasRenderer rend;
    public Color Color1;
    public Color Color2;

}
public class PanelControl : MonoBehaviour
{
    public Canvas ventanaDeRadar;
    public Canvas ventanaRecarga;
    public Canvas ventanaPausa;
    public Canvas retratoEdgar;
    public Canvas retratoAstro;
    public Canvas Dialogo;

    public bool activarRadar;
    public bool activarRecarga;
    public bool botonPausa;
   
    public bool isEdgarTalking;
    public bool isAstroTalking;
    public bool areTalking;

    public bool lowEnergy;
    public bool AmmoCharged;

    public Throw_Flare_Manager manager;
   
    public SistemaBengala bengala;
    public bool botonInteractuar;
    public bool dialogue1;
    public bool dialogue2;
    public bool dialogue3;
    public int InteraccionActiva;
    public int dialogueinteract1;
    public int dialogueinteract2;
    public int dialogueinteract3;
    public DialogueManager dialogoManager;
    public Animator buttonDialogueAnim;
    public List<ControlColor> controlStats;


    private void Start()
    {
    }

    void Update()
    {
        //Controlactivacion();
        LEDVida();
        ChargedAmmo();
        FuncionRadar();
        FuncionRecarga();
        SistemaDetenido();
       // MecanismoDeRecarga();
        MecanismoDeRadar();
        IsAstroHablando();
        IsEdgarHablando();
        AreTalking();
        ActivarPausa();
    }

    //Controles de panel

    void LEDVida()
    {
        if (lowEnergy == false)
        {
            //Debug.Log("HPHigh");
            controlStats[0].rend.SetColor(controlStats[0].Color1);
            controlStats[3].rend.SetColor(controlStats[3].Color1);
        }
        if (lowEnergy == true)
        {
            //Debug.Log("HPLow");
            controlStats[0].rend.SetColor(controlStats[0].Color2);
            controlStats[3].rend.SetColor(controlStats[3].Color2);
        }
    }

    void ChargedAmmo()
    {
        if (AmmoCharged == false)
        {
            controlStats[1].rend.SetColor(controlStats[1].Color1);
            controlStats[2].rend.SetColor(controlStats[2].Color1);
        }
        if (AmmoCharged == true)
        {
            controlStats[1].rend.SetColor(controlStats[1].Color2);
            controlStats[2].rend.SetColor(controlStats[2].Color2);
        }
    }

    //Funciones

    void FuncionRadar()
    {
        if (botonPausa == false)
        {
            if (activarRadar == false)
            {
                ventanaDeRadar.enabled = false;
            }
            if (activarRadar == true)
            {
                ventanaDeRadar.enabled = true;
            }
        }
        else
        {
            return;
        }
    }

    void FuncionRecarga()
    {
       
        if (botonPausa == false)
        {
            if (activarRecarga == false)
            {
                ventanaRecarga.enabled = false;
            }
            if (activarRecarga == true)
            {
                ventanaRecarga.enabled = true;
            }
        }
        else
        {
            return;
        }
    }

    void ActivarPausa()
    {
        if (Input.GetButton("Cancel"))
        {
            botonPausa = true;
        }
    }
    void SistemaDetenido()
    {
        if(botonPausa == false)
        {
            PausaOff();
        }
        if(botonPausa == true)
        {
            PausaOn();
        }
    }
    void PausaOn()
    {
        ventanaPausa.enabled = true;
        Time.timeScale = 0;
    }
    void PausaOff()
    {
        ventanaPausa.enabled = false;
        Time.timeScale = 1;
    }

    public void MecanismoDeRecarga()
    {
       if(bengala.buttonRecarga1 + bengala.buttonRecarga2 + bengala.buttonRecarga3 + bengala.buttonRecarga4 == bengala.Fire)
        {
            print("FIRE!");
            manager.AmmoCount++;
            manager.canShoot = 0;

        }
        else
        {
            print("NO AMMOM");
        }
    }
     void MecanismoDeRadar()
    {
        //Ponga su radar funcional aqui
    }

    public void IsAstroHablando()
    {
        if (botonPausa == false)
        {
            if (isAstroTalking == true)
            {
                retratoAstro.enabled = true;
            }
            if (isAstroTalking == false)
            {
                retratoAstro.enabled = false;
            }
        }
        else
        {
            return;
        }
    }
   public void IsEdgarHablando()
    {
        if (botonPausa == false)
        {
            if (areTalking == true)
            {

                Dialogo.enabled = true;
            }
            if (areTalking == false)
            {
                Dialogo.enabled = false;
            }
        }
        else
        {
            return;
        }
    }
    public void AreTalking()
    {
        if (botonPausa == false)
        {
            if (isEdgarTalking == true)
            {
                retratoEdgar.enabled = true;
            }
            if (isEdgarTalking == false)
            {
                retratoEdgar.enabled = false;
            }
        }
        else
        {
            return;
        }
    }

    //botones

    public void BotonRadar()
    {

        if (botonPausa == false)
        {
            if (activarRadar == false)
            {
                activarRadar = true;  
            }
            else
            {
                activarRadar = false;
            }
        }
        else
        {
            return;
        }
    }

    public void BotonRecarga()
    {
        if(botonPausa == false)
        {
            if (activarRecarga == false && manager.canShoot == 1)
            {
                activarRecarga = true;
                bengala.ran();
                bengala.Fire = bengala.rand;

            }
            else
            {
                activarRecarga = false;
                bengala.buttonRecarga1 = 0;
                bengala.buttonRecarga2 = 0;
                bengala.buttonRecarga3 = 0;
                bengala.buttonRecarga4 = 0;
            }
        }
        else
        {
            return;
        }
    }

    public void FuncionDisparar()
    {
        if(botonPausa == false)
        {
            if (AmmoCharged == true)
            {
                manager.Shoot();
                Debug.Log("Shooting");
                manager.AmmoCount -= 1;
                AmmoCharged = false;
            }

            else
            {
                Debug.Log("No Ammo");
            }
        }
        else
        {
            return;
        }
    }

   
}
