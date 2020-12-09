using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialDialogue_Manager : MonoBehaviour
{
    public Dialogos S_TDialogos;
    public UI_ControlNaveSc C_Nave;
    public TutorialController elementosTutorial;

    Queue<string> Sentencias;
    [Space(20)]
    public GameObject PanelDialogo;
    public Text Display;
    public GameObject nextbton;
    string sentenciaActiva;
    public float typingSpeed;
    public int currentSentence;
    public GameObject E;
    public player_interactions player;
    public InventarioSystem inventorySystem;
    public int Used;

    void Start()
    {
        Sentencias = new Queue<string>();
        Used = 0;
    }

    // Update is called once per frame
    void Update()
    {
        conversacion();
    }

    void IniciarDialogo()
    {
        Sentencias.Clear();

        foreach (string sentencia in S_TDialogos.listaDeSentencias)
        {
            Sentencias.Enqueue(sentencia);
        }

        MostrarSigSentencia();
    }

    void MostrarSigSentencia()
    {
        if (Sentencias.Count == 0)
        {
            //Display.text = sentenciaActiva;
            return;
        }

        sentenciaActiva = Sentencias.Dequeue();
        Display.text = sentenciaActiva;

        StopAllCoroutines();
        StartCoroutine(TypeTheSentence(sentenciaActiva));
    }

    IEnumerator TypeTheSentence(string sentencia)
    {
        Display.text = "";

        foreach (char letter in sentencia.ToCharArray())
        {
            Display.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (Used != 1)
            {
                if (S_TDialogos.id == 1000 || S_TDialogos.id == 1001 || S_TDialogos.id == 1002 || S_TDialogos.id == 1003 || S_TDialogos.id == 1004 || S_TDialogos.id == 1005 || S_TDialogos.id == 1006 || S_TDialogos.id == 1007 || S_TDialogos.id == 1008)
                {
                    C_Nave.ControlPanelesNave.ActivarPanelTexto = true;
                    IniciarDialogo();
                    E.SetActive(true);

                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Display.text == sentenciaActiva)
            {
                if (Used != 1)
                {
                    nextbton.SetActive(true);
                 
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (S_TDialogos.id == 1000 || S_TDialogos.id == 1001)
                        {
                            MostrarSigSentencia();
                            currentSentence++;
                        }
                        if (S_TDialogos.id == 1002)
                        {
                            elementosTutorial.tutotial_elements.Texto1Activo = true;
                            elementosTutorial.tutotial_elements.TutoPanelCentral = true;
                            MostrarSigSentencia();
                            currentSentence++;
                        }
                        if (S_TDialogos.id == 1003)
                        {
                            elementosTutorial.tutotial_elements.Texto1Activo = true;
                            elementosTutorial.tutotial_elements.TutoPanelCentral = true;
                            MostrarSigSentencia();
                            currentSentence++;
                        }
                        if (S_TDialogos.id == 1004)
                        {
                            elementosTutorial.tutotial_elements.Texto1Activo = true;
                            elementosTutorial.tutotial_elements.TutoPanelCentral = true;
                            MostrarSigSentencia();
                            currentSentence++;
                        }
                        if (S_TDialogos.id == 1005)
                        {
                            elementosTutorial.tutotial_elements.Texto1Activo = true;
                            elementosTutorial.tutotial_elements.TutoPanelCentral = true;
                            MostrarSigSentencia();
                            currentSentence++;
                        }
                        if (S_TDialogos.id == 1006)
                        {
                            elementosTutorial.tutotial_elements.Texto1Activo = true;
                            elementosTutorial.tutotial_elements.TutoPanelCentral = true;
                            MostrarSigSentencia();
                            currentSentence++;
                        }
                        if (S_TDialogos.id == 1007)
                        {
                            elementosTutorial.tutotial_elements.Texto1Activo = true;
                            elementosTutorial.tutotial_elements.TutoPanelCentral = true;
                            MostrarSigSentencia();
                            currentSentence++;
                        }
                        if (S_TDialogos.id == 1008)
                        {
                            elementosTutorial.tutotial_elements.Texto1Activo = true;
                            elementosTutorial.tutotial_elements.TutoPanelCentral = true;
                            MostrarSigSentencia();
                            currentSentence++;
                        }
                    }
                    if (S_TDialogos.id == 1000)
                    {
                        elementosTutorial.tutotial_elements.Texto1Activo = true;
                        elementosTutorial.tutotial_elements.TutoPanelCentral = true;
                        elementosTutorial.tutotial_elements.IsAstro1Act = false;
                        elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                    }
                    if (S_TDialogos.id == 1001)
                    {
                        elementosTutorial.tutotial_elements.Texto1Activo = true;
                        elementosTutorial.tutotial_elements.TutoPanelCentral = true;
                    }
                }
                else
                {
                    nextbton.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D obj)
    {
        elementosTutorial.tutotial_elements.Texto1Activo = false;
        elementosTutorial.tutotial_elements.TutoPanelCentral = false;
        C_Nave.ControlPanelesNave.ActivarPanelTexto = false;
        currentSentence = 0;
        StopAllCoroutines();
        E.SetActive(false);
    }

    public void conversacion()
    {
        switch (currentSentence)
        {
            case 1:
                if (S_TDialogos.id == 1000)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                }
                if (S_TDialogos.id == 1001)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                }
                if (S_TDialogos.id == 1002)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                }
                if (S_TDialogos.id == 1003)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                }
                if (S_TDialogos.id == 1004)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                }
                if (S_TDialogos.id == 1005)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                }
                if (S_TDialogos.id == 1006)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                }
                if (S_TDialogos.id == 1007)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                }
                if (S_TDialogos.id == 1008)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                }
                break;
            case 2:
                if (S_TDialogos.id == 1000)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                }
                if (S_TDialogos.id == 1001)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                }
                if (S_TDialogos.id == 1002)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                }
                if (S_TDialogos.id == 1003)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                }
                if (S_TDialogos.id == 1004)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                }
                if (S_TDialogos.id == 1005)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                }
                if (S_TDialogos.id == 1006)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                }
                if (S_TDialogos.id == 1007)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                }
                if (S_TDialogos.id == 1008)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                }
                break;

            case 3:
                if (S_TDialogos.id == 1000)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                }
                if (S_TDialogos.id == 1001)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                }
                if (S_TDialogos.id == 1002)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                }
                if (S_TDialogos.id == 1003)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                }
                if (S_TDialogos.id == 1004)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                }
                if (S_TDialogos.id == 1005)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                }
                if (S_TDialogos.id == 1006)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                }
                if (S_TDialogos.id == 1007)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                }
                if (S_TDialogos.id == 1008)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                }
                break;

            case 4:
                if (S_TDialogos.id == 1000)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                }
                if (S_TDialogos.id == 1001)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                }
                if (S_TDialogos.id == 1002)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                }
                if (S_TDialogos.id == 1003)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                }
                if (S_TDialogos.id == 1004)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                }
                if (S_TDialogos.id == 1005)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                }
                if (S_TDialogos.id == 1006)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                }
                if (S_TDialogos.id == 1007)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                }
                if (S_TDialogos.id == 1008)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                }
                break;
            case 5:
                if (S_TDialogos.id == 1000)
                {
                    elementosTutorial.tutotial_elements.nextBtonact = true;
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                }
                if (S_TDialogos.id == 1001)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                }
                if (S_TDialogos.id == 1002)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                }
                if (S_TDialogos.id == 1003)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                }
                if (S_TDialogos.id == 1004)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                }
                if (S_TDialogos.id == 1005)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                }
                if (S_TDialogos.id == 1006)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                }
                if (S_TDialogos.id == 1007)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                }
                if (S_TDialogos.id == 1008)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                }
                break;
            case 6:
                if (S_TDialogos.id == 1000)
                {
                    elementosTutorial.tutotial_elements.nextBtonact = true;
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                }
                if (S_TDialogos.id == 1001)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                    currentSentence = 0;
                    E.SetActive(false);
                    this.gameObject.SetActive(false);
                }
                if (S_TDialogos.id == 1002)
                {
                    currentSentence = 0;
                    E.SetActive(false);
                    this.gameObject.SetActive(false);
                }
                if (S_TDialogos.id == 1003)
                {
                    currentSentence = 0;
                    E.SetActive(false);
                    this.gameObject.SetActive(false);
                }
                if (S_TDialogos.id == 1004)
                {
                    currentSentence = 0;
                    E.SetActive(false);
                    this.gameObject.SetActive(false);
                }
                if (S_TDialogos.id == 1005)
                {
                    currentSentence = 0;
                    E.SetActive(false);
                    this.gameObject.SetActive(false);
                }
                if (S_TDialogos.id == 1006)
                {
                    currentSentence = 0;
                    E.SetActive(false);
                    this.gameObject.SetActive(false);
                }
                if (S_TDialogos.id == 1007)
                {
                    currentSentence = 0;
                    E.SetActive(false);
                    this.gameObject.SetActive(false);
                }
                if (S_TDialogos.id == 1008)
                {
                    currentSentence = 0;
                    E.SetActive(false);
                    this.gameObject.SetActive(false);
                }
                break;
            case 7:
                if (S_TDialogos.id == 1000)
                {
                    elementosTutorial.tutotial_elements.nextBtonact = true;
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                }
                if (S_TDialogos.id == 1001)
                {
                    currentSentence = 0;
                    E.SetActive(false);
                    this.gameObject.SetActive(false);
                }
                if (S_TDialogos.id == 1002)
                {
                    currentSentence = 0;
                    E.SetActive(false);
                    this.gameObject.SetActive(false);
                }
                if (S_TDialogos.id == 1003)
                {
                    currentSentence = 0;
                    E.SetActive(false);
                    this.gameObject.SetActive(false);
                }
                if (S_TDialogos.id == 1004)
                {
                    currentSentence = 0;
                    E.SetActive(false);
                    this.gameObject.SetActive(false);
                }
                if (S_TDialogos.id == 1005)
                {
                    currentSentence = 0;
                    E.SetActive(false);
                    this.gameObject.SetActive(false);
                }
                if (S_TDialogos.id == 1006)
                {
                    currentSentence = 0;
                    E.SetActive(false);
                    this.gameObject.SetActive(false);
                }
                if (S_TDialogos.id == 1007)
                {
                    currentSentence = 0;
                    E.SetActive(false);
                    this.gameObject.SetActive(false);
                }
                if (S_TDialogos.id == 1008)
                {
                    currentSentence = 0;
                    E.SetActive(false);
                    this.gameObject.SetActive(false);
                }
                break;
            case 8:
                if (S_TDialogos.id == 1000)
                {
                    elementosTutorial.tutotial_elements.nextBtonact = true;
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                    currentSentence = 0;
                }
                if(S_TDialogos.id == 1001)
                {
                    currentSentence = 0;
                    E.SetActive(false);
                    this.gameObject.SetActive(false);
                }
                if (S_TDialogos.id == 1002)
                {
                    currentSentence = 0;
                    E.SetActive(false);
                    this.gameObject.SetActive(false);
                }
                if (S_TDialogos.id == 1003)
                {
                    currentSentence = 0;
                    E.SetActive(false);
                    this.gameObject.SetActive(false);
                }
                if (S_TDialogos.id == 1004)
                {
                    currentSentence = 0;
                    E.SetActive(false);
                    this.gameObject.SetActive(false);
                }
                if (S_TDialogos.id == 1005)
                {
                    currentSentence = 0;
                    E.SetActive(false);
                    this.gameObject.SetActive(false);
                }
                if (S_TDialogos.id == 1006)
                {
                    currentSentence = 0;
                    E.SetActive(false);
                    this.gameObject.SetActive(false);
                }
                if (S_TDialogos.id == 1007)
                {
                    currentSentence = 0;
                    E.SetActive(false);
                    this.gameObject.SetActive(false);
                }
                if (S_TDialogos.id == 1008)
                {
                    currentSentence = 0;
                    E.SetActive(false);
                    this.gameObject.SetActive(false);
                }
                //E.SetActive(false);
                break;

        }
    }

    public void BtonNext()
    {
        if(S_TDialogos.id == 1000)
        {
            elementosTutorial.tutotial_elements.IsAstro1Act = false;
            elementosTutorial.tutotial_elements.IsEdgar1Act = false;
            elementosTutorial.tutotial_elements.Texto1Activo = false;
            elementosTutorial.tutotial_elements.TutoPanelCentral = false;
            elementosTutorial.tutotial_elements.nextBtonact = false;
            currentSentence = 0;
            E.SetActive(false);
        }

    }
}
