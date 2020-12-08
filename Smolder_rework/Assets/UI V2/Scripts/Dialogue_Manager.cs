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
        sentencias = new Queue<string>();
        //playText.onClick.AddListener(LlamarTexto);
        Used = 0;
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
            if(Used != 1)
            {
                if (S_Dialogos.id == 1 || S_Dialogos.id == 3 || S_Dialogos.id == 4)
                {
                    controlNave.ControlPanelesNave.ActivarPanelTexto = true;
                    IniciarDialogo();
                    E.SetActive(true);
                   
                }
                if (S_Dialogos.id == 2)
                {
                    if(inventorySystem.ItemList[0] ==("Llave") || inventorySystem.ItemList[1] ==("Llave") || inventorySystem.ItemList[2] == ("Llave"))
                    {
                        controlNave.ControlPanelesNave.ActivarPanelTexto = true;
                        IniciarDialogo();
                        E.SetActive(true);
                    }
                    else
                    {
                        controlNave.ControlPanelesNave.ActivarPanelTexto = false;
                        E.SetActive(false);
                        Display.text = "Parece que esta nave necesita una llave maestra para poder abrirla.".ToString();
                        StartCoroutine(TypeTheSentence("Parece que esta nave necesita una llave maestra para poder abrirla."));
                        controlNave.controlTextoNave.hablando = true;
                        controlNave.controlTextoNave.PanelPerrosActivo = true;
                        controlNave.controlTextoNave.EdgarHablando = true;
                       
                    }
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(Display.text == sentenciaActiva)
            {
                if (Used != 1)
                {
                    nextbton.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (S_Dialogos.id == 1 || S_Dialogos.id == 3 || S_Dialogos.id == 4)
                        {
                            controlNave.controlTextoNave.hablando = true;
                            controlNave.controlTextoNave.PanelPerrosActivo = true;
                            MostrarSigSentencia();
                            currentSentence++;
                        }
                        if (S_Dialogos.id == 2)
                        {
      
                            if (inventorySystem.ItemList[0] == ("Llave") || inventorySystem.ItemList[1] == ("Llave") || inventorySystem.ItemList[2] == ("Llave"))
                            {
                                controlNave.controlTextoNave.hablando = true;
                                controlNave.controlTextoNave.PanelPerrosActivo = true;
                                MostrarSigSentencia();
                                currentSentence++;
                            }
                        }
                       
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
                if(S_Dialogos.id == 4)
                {
                    controlNave.controlTextoNave.EdgarHablando = true;
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
                if (S_Dialogos.id == 4)
                {
                    controlNave.controlTextoNave.AstroHablando = true;
                    controlNave.controlTextoNave.EdgarHablando = false;
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
                if (S_Dialogos.id == 4)
                {
                    controlNave.controlTextoNave.AstroHablando = false;
                    controlNave.controlTextoNave.EdgarHablando = true;
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
                if (S_Dialogos.id == 4)
                {
                    controlNave.controlTextoNave.AstroHablando = true;
                    controlNave.controlTextoNave.EdgarHablando = false;
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
                if (S_Dialogos.id == 4)
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
                    if (inventorySystem.slot1Active != true)
                    {
                        inventorySystem.slot1.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                        inventorySystem.slot1Active = true;
                        inventorySystem.ItemList[0] = "Coordenada 1";
                        inventorySystem.coordenadaCount++;
                    }
                    else if (inventorySystem.slot1Active && inventorySystem.slot2Active!=true && inventorySystem.slot3Active != true)
                    {
                        inventorySystem.slot2.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                        inventorySystem.slot2Active = true;
                        inventorySystem.ItemList[1] = "Coordenada 1";
                        inventorySystem.coordenadaCount++;
                    }
                    else if(inventorySystem.slot1Active && inventorySystem.slot2Active && inventorySystem.slot3Active != true)
                    {
                        inventorySystem.slot3.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                        inventorySystem.slot3Active = true;
                        inventorySystem.ItemList[2] = "Coordenada 1";
                        inventorySystem.coordenadaCount++;
                    }
                    Used = 1;
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
                if (S_Dialogos.id == 4)
                {
                    controlNave.controlTextoNave.AstroHablando = false;
                    controlNave.controlTextoNave.EdgarHablando = false;
                    controlNave.ControlPanelesNave.ActivarPanelTexto = false;
                    controlNave.controlTextoNave.hablando = false;
                    controlNave.controlTextoNave.PanelPerrosActivo = false;
                    currentSentence = 0;
                    E.SetActive(false);
                    Used = 1;
                    if (inventorySystem.slot1Active != true)
                    {
                        inventorySystem.slot1.gameObject.transform.GetChild(2).gameObject.SetActive(true);
                        inventorySystem.slot1Active = true;
                        inventorySystem.ItemList[0] = "Llave";
                    }
                    else if (inventorySystem.slot1Active && inventorySystem.slot2Active != true && inventorySystem.slot3Active != true)
                    {
                        inventorySystem.slot2.gameObject.transform.GetChild(2).gameObject.SetActive(true);
                        inventorySystem.slot2Active = true;
                        inventorySystem.ItemList[1] = "Llave";
                    }
                    else if (inventorySystem.slot1Active && inventorySystem.slot2Active && inventorySystem.slot3Active != true)
                    {
                        inventorySystem.slot3.gameObject.transform.GetChild(2).gameObject.SetActive(true);
                        inventorySystem.slot3Active = true;
                        inventorySystem.ItemList[2] = "Llave";
                    }

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
                    Used = 1;
                    E.SetActive(false);
                    if (inventorySystem.slot1Active != true)
                    {
                        inventorySystem.slot1.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                        inventorySystem.slot1Active = true;
                        inventorySystem.ItemList[0] = "Coordenada 2";
                        inventorySystem.coordenadaCount++;
                    }
                    else if (inventorySystem.slot1Active && inventorySystem.slot2Active != true && inventorySystem.slot3Active != true)
                    {
                        inventorySystem.slot2.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                        inventorySystem.slot2Active = true;
                        inventorySystem.ItemList[1] = "Coordenada 2";
                        inventorySystem.coordenadaCount++;
                    }
                    else if (inventorySystem.slot1Active && inventorySystem.slot2Active && inventorySystem.slot3Active != true)
                    {
                        inventorySystem.slot3.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                        inventorySystem.slot3Active = true;
                        inventorySystem.ItemList[2] = "Coordenada 2";
                        inventorySystem.coordenadaCount++;
                    }

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
        }
    }
}
