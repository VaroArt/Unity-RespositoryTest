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
}
