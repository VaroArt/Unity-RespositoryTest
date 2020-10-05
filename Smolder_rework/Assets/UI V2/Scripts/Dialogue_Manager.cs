using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_Manager : MonoBehaviour
{
    public Dialogos S_Dialogos;

    Queue<string> sentencias;

    public GameObject PanelDialogo;
    public Text Display;

    string sentenciaActiva;
    public float typingSpeed;

    void Start()
    {
        sentencias = new Queue<string>();
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

        MoratrarSigSentencia();
    }

    void MoratrarSigSentencia()
    {
        if(sentencias.Count <= 0)
        {
            Display.text = sentenciaActiva;
            return;
        }

        sentenciaActiva = sentencias.Dequeue();
        Display.text = sentenciaActiva;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            IniciarDialogo();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                MoratrarSigSentencia();
            }
        }
    }
}
