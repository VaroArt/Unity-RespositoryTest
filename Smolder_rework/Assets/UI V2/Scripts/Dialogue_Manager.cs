using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_Manager : MonoBehaviour
{
    public Dialogos S_Dialogos;
    public UI_ControlNaveSc controlNave;

    Queue<string> sentencias;

    public GameObject PanelDialogo;
    public Text Display;
    public Button playText;
    public GameObject nextbton;
    string sentenciaActiva;
    public float typingSpeed;
    public int currentSentence;
    public GameObject E;
    void Start()
    {
        sentencias = new Queue<string>();
        //playText.onClick.AddListener(LlamarTexto);
    }

    void Update()
    {
        conversacion();
    }

    void IniciarDialogo()
    {
        sentencias.Clear();

        foreach(string sentencia in S_Dialogos.listaDeSentencias)
        {
            sentencias.Enqueue(sentencia);
        }

        MostrarSigSentencia();
    }

    void MostrarSigSentencia()
    {
        if(sentencias.Count == 0)
        {
            //Display.text = sentenciaActiva;
            return;
        }

        sentenciaActiva = sentencias.Dequeue();
        Display.text = sentenciaActiva;

        StopAllCoroutines();
        StartCoroutine(TypeTheSentence(sentenciaActiva));
    }

    IEnumerator TypeTheSentence(string sentencia)
    {
        Display.text = "";

        foreach(char letter in sentencia.ToCharArray())
        {
            Display.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    /*void LlamarTexto()
    {
        controlNave.controlTextoNave.hablando = true;
        IniciarDialogo();
    }*/

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            controlNave.ControlPanelesNave.ActivarPanelTexto = true;
            IniciarDialogo();
            E.SetActive(true);
            //print(sentencias.Count);

        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(Display.text == sentenciaActiva)
            {  
                nextbton.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    controlNave.controlTextoNave.hablando = true;
                    controlNave.controlTextoNave.PanelPerrosActivo = true;

                    MostrarSigSentencia();
                    currentSentence++;
                   // print(sentencias.Count);
                }
            }
            else
            {
                nextbton.SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D obj)
    {
        controlNave.ControlPanelesNave.ActivarPanelTexto = false;
        controlNave.controlTextoNave.hablando = false;
        controlNave.controlTextoNave.PanelPerrosActivo = false;
        StopAllCoroutines();
        E.SetActive(false);
    }

    public void conversacion()
    {
        switch (currentSentence)
        {
            case 1:
               if(S_Dialogos.id == 1)
                {
                    
                    controlNave.controlTextoNave.AstroHablando = true;
                }
               if(S_Dialogos.id == 2)
                {
                    controlNave.controlTextoNave.EdgarHablando = true;
                }
                if (S_Dialogos.id == 3)
                {
                    controlNave.controlTextoNave.AstroHablando = true;
                }
                break;
            case 2:

                if(S_Dialogos.id == 1)
                {
                    controlNave.controlTextoNave.AstroHablando = false;
                    controlNave.controlTextoNave.EdgarHablando = true;
                }
                if (S_Dialogos.id == 2)
                {
                    controlNave.controlTextoNave.AstroHablando = true;
                    controlNave.controlTextoNave.EdgarHablando = false;
                }
                if (S_Dialogos.id == 3)
                {
                    controlNave.controlTextoNave.AstroHablando = false;
                    controlNave.controlTextoNave.EdgarHablando = true;
                }
                break;

            case 3:
                if (S_Dialogos.id == 1)
                {
                    controlNave.controlTextoNave.AstroHablando = false;
                    controlNave.controlTextoNave.EdgarHablando = true;
                }
                if (S_Dialogos.id == 2)
                {
                    controlNave.controlTextoNave.AstroHablando = false;
                    controlNave.controlTextoNave.EdgarHablando = true;
                }
                if (S_Dialogos.id == 3)
                {
                    controlNave.controlTextoNave.AstroHablando = true;
                    controlNave.controlTextoNave.EdgarHablando = false;
                }
                break;

            case 4:
                if (S_Dialogos.id == 1)
                {
                    controlNave.controlTextoNave.AstroHablando = false;
                    controlNave.controlTextoNave.EdgarHablando = true;
                }
                if (S_Dialogos.id == 2)
                {
                    controlNave.controlTextoNave.AstroHablando = true;
                    controlNave.controlTextoNave.EdgarHablando = false;
                }
                if (S_Dialogos.id == 3)
                {
                    controlNave.controlTextoNave.AstroHablando = false;
                    controlNave.controlTextoNave.EdgarHablando = true;
                }

                break;
            case 5:
                if (S_Dialogos.id == 1)
                {
                    controlNave.controlTextoNave.AstroHablando = true;
                    controlNave.controlTextoNave.EdgarHablando = false;
                }
                if (S_Dialogos.id == 2)
                {
                    controlNave.controlTextoNave.AstroHablando = false;
                    controlNave.controlTextoNave.EdgarHablando = true;
                }
                if (S_Dialogos.id == 3)
                {
                    controlNave.controlTextoNave.AstroHablando = false;
                    controlNave.controlTextoNave.EdgarHablando = true;
                }
                break;
            case 6:
                if (S_Dialogos.id == 1)
                {
                    controlNave.controlTextoNave.AstroHablando = false;
                    controlNave.controlTextoNave.EdgarHablando = false;
                    controlNave.ControlPanelesNave.ActivarPanelTexto = false;
                    controlNave.controlTextoNave.hablando = false;
                    controlNave.controlTextoNave.PanelPerrosActivo = false;
                    currentSentence = 0;
                    E.SetActive(false);
                }
                if (S_Dialogos.id == 2)
                {
                    controlNave.controlTextoNave.AstroHablando = true;
                    controlNave.controlTextoNave.EdgarHablando = false;
                }
                if (S_Dialogos.id == 3)
                {
                    controlNave.controlTextoNave.AstroHablando = true;
                    controlNave.controlTextoNave.EdgarHablando = false;
                }
                break;

            case 7:
                if(S_Dialogos.id == 2)
                {
                    controlNave.controlTextoNave.AstroHablando = false;
                    controlNave.controlTextoNave.EdgarHablando = false;
                    controlNave.ControlPanelesNave.ActivarPanelTexto = false;
                    controlNave.controlTextoNave.hablando = false;
                    controlNave.controlTextoNave.PanelPerrosActivo = false;
                    currentSentence = 0;
                    E.SetActive(false);
                    
                }

                if (S_Dialogos.id == 3)
                {
                    controlNave.controlTextoNave.AstroHablando = false;
                    controlNave.controlTextoNave.EdgarHablando = true;
                }
                break;

            case 8:
                controlNave.controlTextoNave.AstroHablando = false;
                controlNave.controlTextoNave.EdgarHablando = false;
                controlNave.ControlPanelesNave.ActivarPanelTexto = false;
                controlNave.controlTextoNave.hablando = false;
                controlNave.controlTextoNave.PanelPerrosActivo = false;
                currentSentence = 0;
                E.SetActive(false);
                break;


                /*  controlNave.controlTextoNave.AstroHablando = false;
                    controlNave.controlTextoNave.EdgarHablando = false;
                    controlNave.ControlPanelesNave.ActivarPanelTexto = false;
                    controlNave.controlTextoNave.hablando = false;
                    controlNave.controlTextoNave.PanelPerrosActivo = false;
                    currentSentence = 0;
                    E.SetActive(false);
                    break;*/
        }
    }
}
