using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    public TutorialElements tutotial_elements;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TutorialFunc();
        TutorialInstruccions();
        PerrosTutorial();
    }

    public void TutorialFunc()
    {
        if (tutotial_elements.TutopanelRegarga == true)
        {
            tutotial_elements.Paneles[3].enabled = true;
        }
        else
        {
            tutotial_elements.Paneles[3].enabled = false;
        }

        if (tutotial_elements.TutoBtonRecarga == true)
        {
            tutotial_elements.Paneles[4].enabled = true;
        }
        else
        {
            tutotial_elements.Paneles[4].enabled = false;
        }

        if(tutotial_elements.TutoPanelRadar == true)
        {
            tutotial_elements.Paneles[5].enabled = true;
        }
        else
        {
            tutotial_elements.Paneles[5].enabled = false;
        }

        if (tutotial_elements.TutoBtonRadar == true)
        {
            tutotial_elements.Paneles[6].enabled = true;
        }
        else
        {
            tutotial_elements.Paneles[6].enabled = false;
        }

        if(tutotial_elements.TutoPanelInventario == true)
        {
            tutotial_elements.Paneles[7].enabled = true;
        }
        else
        {
            tutotial_elements.Paneles[7].enabled = false;
        }

        if(tutotial_elements.TutoBtonInventario == true)
        {
            tutotial_elements.Paneles[8].enabled = true;
        }
        else
        {
            tutotial_elements.Paneles[8].enabled = false;
        }

        if(tutotial_elements.TutoBtonDron == true)
        {
            tutotial_elements.Paneles[2].enabled = true;
        }
        else
        {
            tutotial_elements.Paneles[2].enabled = false;
        }

        if(tutotial_elements.TutoPanelVida == true)
        {
            tutotial_elements.Paneles[1].enabled = true;
        }
        else
        {
            tutotial_elements.Paneles[1].enabled = false;
        }

        if(tutotial_elements.TutoPanelCentral == true)
        {
            tutotial_elements.Paneles[0].enabled = true;
        }
        else
        {
            tutotial_elements.Paneles[0].enabled = false;
        }

        if(tutotial_elements.TutoBtonLuz == true)
        {
            tutotial_elements.Paneles[10].enabled = true;
        }
        else
        {
            tutotial_elements.Paneles[10].enabled = false;
        }

        if(tutotial_elements.TutoFuncionLuz == true)
        {
            tutotial_elements.Paneles[9].enabled = true;
        }
        else
        {
            tutotial_elements.Paneles[9].enabled = false;
        }

        if(tutotial_elements.TutoBtonMotor == true)
        {
            tutotial_elements.Paneles[12].enabled = true;
        }
        else
        {
            tutotial_elements.Paneles[12].enabled = false;
        }

        if(tutotial_elements.TutoFuncionMotor == true)
        {
            tutotial_elements.Paneles[11].enabled = true;
        }
        else
        {
            tutotial_elements.Paneles[11].enabled = false;
        }
    }

    public void TutorialInstruccions()
    {
        if (tutotial_elements.Texto1Activo == true)
        {
            tutotial_elements.CanvasTexto1.enabled = true;           
        }
        else
        {
            tutotial_elements.CanvasTexto1.enabled = false;          
        }

        if(tutotial_elements.Texto2Activo == true)
        {
            tutotial_elements.CanvasTexto2.enabled = true;
        }
        else
        {
            tutotial_elements.CanvasTexto2.enabled = false;
        }

        if(tutotial_elements.nextBtonact == true)
        {
            tutotial_elements.nextbton.SetActive(true);
        }
        else
        {
            tutotial_elements.nextbton.SetActive(false);
        }

        if(tutotial_elements.MisionAct == true)
        {
            tutotial_elements.Mision.enabled = true;
        }
        else
        {
            tutotial_elements.Mision.enabled = false;
        }
    }

    public void PerrosTutorial()
    {
        if (tutotial_elements.IsAstro1Act)
        {
            tutotial_elements.TextosPaneles1[0].enabled = true;
            tutotial_elements.ImgPaneles1[0].enabled = true;
        }
        else
        {
            tutotial_elements.TextosPaneles1[0].enabled = false;
            tutotial_elements.ImgPaneles1[0].enabled = false;
        }

        if (tutotial_elements.IsEdgar1Act)
        {
            tutotial_elements.TextosPaneles1[1].enabled = true;
            tutotial_elements.ImgPaneles1[1].enabled = true;
        }
        else
        {
            tutotial_elements.TextosPaneles1[1].enabled = false;
            tutotial_elements.ImgPaneles1[1].enabled = false;
        }

        if (tutotial_elements.IsAstro2Act)
        {
            tutotial_elements.TextosPaneles2[0].enabled = true;
            tutotial_elements.ImgPaneles2[0].enabled = true;
        }
        else
        {
            tutotial_elements.TextosPaneles2[0].enabled = false;
            tutotial_elements.ImgPaneles2[0].enabled = false;
        }

        if (tutotial_elements.IsEdgar2Act)
        {
            tutotial_elements.TextosPaneles2[1].enabled = true;
            tutotial_elements.ImgPaneles2[1].enabled = true;
        }
        else
        {
            tutotial_elements.TextosPaneles2[1].enabled = false;
            tutotial_elements.ImgPaneles2[1].enabled = false;
        }
    }
}
