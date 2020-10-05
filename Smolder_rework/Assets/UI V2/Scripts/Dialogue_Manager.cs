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

    void Start()
    {
        sentencias = new Queue<string>();
        //playText.onClick.AddListener(LlamarTexto);
    }

    void Update()
    {  
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
        if(sentencias.Count <= 0)
        {
            Display.text = sentenciaActiva;
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
            controlNave.controlTextoNave.hablando = true;
            controlNave.controlTextoNave.PanelPerrosActivo = true;
            IniciarDialogo();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(Display.text == sentenciaActiva)
            {
                nextbton.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    MostrarSigSentencia();
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
    }
}
