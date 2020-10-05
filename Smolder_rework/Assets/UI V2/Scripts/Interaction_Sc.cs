using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction_Sc : MonoBehaviour
{
    public UI_ControlNaveSc controlNave;
    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Evento Texto"))
        {

            controlNave.ControlPanelesNave.ActivarPanelTexto = true;
            print("allahu akbar");
        }

        if(other.gameObject.CompareTag("Evento Interaccion"))
        {
            controlNave.ControlPanelesNave.ActivarPanelInteraccion = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        controlNave.ControlPanelesNave.ActivarPanelTexto = false;
        print("rabka uhalla");
        controlNave.ControlPanelesNave.ActivarPanelInteraccion = false;
    }   
}
