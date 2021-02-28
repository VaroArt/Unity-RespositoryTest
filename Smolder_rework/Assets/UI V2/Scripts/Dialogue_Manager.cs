using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
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
    public player_script player;
    public BengalSystem bengala;
    public InventarioSystem inventorySystem;
    public int Used;
    [Header("Sonidos")]
    private AudioSource AudioDialogos;
    public AudioClip DialogoClip;
    public int count;
    void Start()
    {
        AudioDialogos = GetComponent<AudioSource>();
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

        foreach (char letter in sentencia.ToCharArray())
        {
            count++;
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
                if (S_Dialogos.id == 1 || S_Dialogos.id == 3 || S_Dialogos.id == 2 || S_Dialogos.id == 5)
                {
                    controlNave.ControlPanelesNave.ActivarPanelTexto = true;
                    IniciarDialogo();
                    E.SetActive(true);
                   
                }
                if (S_Dialogos.id == 4)
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
                        if (S_Dialogos.id == 1 && currentSentence < 8)
                        {
                            controlNave.controlTextoNave.hablando = true;
                            controlNave.controlTextoNave.PanelPerrosActivo = true;
                            MostrarSigSentencia();
                            currentSentence++;
                            AudioDialogos.clip = DialogoClip; // reproducir el audio cuando inicia el dialogo
                            AudioDialogos.Play();

                        }
                        // S_Dialogos.id == 3 || S_Dialogos.id == 2 || S_Dialogos.id == 5
                        if (S_Dialogos.id == 3 && currentSentence < 10)
                        {
                            controlNave.controlTextoNave.hablando = true;
                            controlNave.controlTextoNave.PanelPerrosActivo = true;
                            MostrarSigSentencia();
                            currentSentence++;
                            AudioDialogos.clip = DialogoClip; // reproducir el audio cuando inicia el dialogo
                            AudioDialogos.Play();
                        }
                        if (S_Dialogos.id == 2 && currentSentence < 8)
                        {
                            controlNave.controlTextoNave.hablando = true;
                            controlNave.controlTextoNave.PanelPerrosActivo = true;
                            MostrarSigSentencia();
                            currentSentence++;
                            AudioDialogos.clip = DialogoClip; // reproducir el audio cuando inicia el dialogo
                            AudioDialogos.Play();
                        }
                        if (S_Dialogos.id == 5 && currentSentence < 12 )
                        {
                            controlNave.controlTextoNave.hablando = true;
                            controlNave.controlTextoNave.PanelPerrosActivo = true;
                            MostrarSigSentencia();
                            currentSentence++;
                            AudioDialogos.clip = DialogoClip; // reproducir el audio cuando inicia el dialogo
                            AudioDialogos.Play();
                        }
                        if (S_Dialogos.id == 4)
                        {
      
                            if (inventorySystem.ItemList[0] == ("Llave") || inventorySystem.ItemList[1] == ("Llave") || inventorySystem.ItemList[2] == ("Llave"))
                            {
                                controlNave.controlTextoNave.hablando = true;
                                controlNave.controlTextoNave.PanelPerrosActivo = true;
                                MostrarSigSentencia();
                                currentSentence++;
                                AudioDialogos.clip = DialogoClip; // reproducir el audio cuando inicia el dialogo, este es especial, porque se necesita la llave para interactuar con esta nave
                                AudioDialogos.Play();
                            }
                        }
                    }
                }
                else
                {
                    nextbton.SetActive(false);
                }
            }
              if(Used == 1)
            {
                AudioDialogos.Stop();
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
        AudioDialogos.Stop();
    }

    public void conversacion()
    {
        switch (currentSentence)
        {
            case 1:
               if(S_Dialogos.id == 1)
                {
                    
                    controlNave.controlTextoNave.EdgarHablando = true;
                    if (count == 52)
                    {
                        AudioDialogos.Stop();
                    }
                }
               if(S_Dialogos.id == 2)
                {
                    controlNave.controlTextoNave.EdgarHablando = true;
                    if (count == 69)
                    {
                        AudioDialogos.Stop();
                    }
                }
               if(S_Dialogos.id == 3)
                {
                    controlNave.controlTextoNave.EdgarHablando = true;
                    if (count == 87)
                    {
                        AudioDialogos.Stop();
                    }
                }
               if(S_Dialogos.id == 4)
                {
                    controlNave.controlTextoNave.AstroHablando = true;
                    if (count == 34)
                    {
                        AudioDialogos.Stop();
                    }
                }
               if(S_Dialogos.id == 5)
                {
                    controlNave.controlTextoNave.EdgarHablando = true;
                    if (count == 65)
                    {
                        AudioDialogos.Stop();
                    }
                }
                break;
            case 2:

                if(S_Dialogos.id == 1)
                {
                    controlNave.controlTextoNave.AstroHablando = true;
                    controlNave.controlTextoNave.EdgarHablando = false;
                    if (count == 89)
                    {
                        AudioDialogos.Stop();
                    }
                }
                if(S_Dialogos.id == 2)
                {
                    controlNave.controlTextoNave.AstroHablando = true;
                    controlNave.controlTextoNave.EdgarHablando = false;
                    if (count == 124)
                    {
                        AudioDialogos.Stop();
                    }
                }
                if(S_Dialogos.id == 3)
                {
                    controlNave.controlTextoNave.AstroHablando = true;
                    controlNave.controlTextoNave.EdgarHablando = false;
                    if (count == 114)
                    {
                        AudioDialogos.Stop();
                    }
                }
                if(S_Dialogos.id == 4)
                {
                    controlNave.controlTextoNave.AstroHablando = true;
                    controlNave.controlTextoNave.EdgarHablando = false;
                    if (count == 90)
                    {
                        AudioDialogos.Stop();
                    }
                }
                if(S_Dialogos.id == 5)
                {
                    controlNave.controlTextoNave.AstroHablando = true;
                    controlNave.controlTextoNave.EdgarHablando = false;
                    if (count == 106)
                    {
                        AudioDialogos.Stop();
                    }
                }
                break;

            case 3:
                if(S_Dialogos.id == 1)
                {
                    controlNave.controlTextoNave.AstroHablando = false;
                    controlNave.controlTextoNave.EdgarHablando = true;
                    if (count == 240)
                    {
                        AudioDialogos.Stop();
                    }
                }
                if(S_Dialogos.id == 2)
                {
                    controlNave.controlTextoNave.AstroHablando = false;
                    controlNave.controlTextoNave.EdgarHablando = true;
                    if (count == 260)
                    {
                        AudioDialogos.Stop();
                    }
                }
                if(S_Dialogos.id == 3)
                {
                    controlNave.controlTextoNave.AstroHablando = false;
                    controlNave.controlTextoNave.EdgarHablando = true;
                    if (count == 266)
                    {
                        AudioDialogos.Stop();
                    }
                }
                if(S_Dialogos.id == 4)
                {
                    controlNave.controlTextoNave.AstroHablando = false;
                    controlNave.controlTextoNave.EdgarHablando = true;
                    if (count == 286)
                    {
                        AudioDialogos.Stop();
                    }
                }
                if(S_Dialogos.id == 5)
                {
                    controlNave.controlTextoNave.AstroHablando = false;
                    controlNave.controlTextoNave.EdgarHablando = true;
                    if (count == 127)
                    {
                        AudioDialogos.Stop();
                    }
                }
                break;


            case 4:
                if (S_Dialogos.id == 1)
                {
                    controlNave.controlTextoNave.AstroHablando = true;
                    controlNave.controlTextoNave.EdgarHablando = false;
                    if (count == 288)
                    {
                        AudioDialogos.Stop();
                    }
                }
                if (S_Dialogos.id == 2)
                {
                    controlNave.controlTextoNave.AstroHablando = true;
                    controlNave.controlTextoNave.EdgarHablando = false;
                    if (count == 349)
                    {
                        AudioDialogos.Stop();
                    }
                }
                if (S_Dialogos.id == 3)
                {
                    controlNave.controlTextoNave.AstroHablando = true;
                    controlNave.controlTextoNave.EdgarHablando = false;
                    if (count == 290)
                    {
                        AudioDialogos.Stop();
                    }
                }
                if (S_Dialogos.id == 4)
                {
                    controlNave.controlTextoNave.AstroHablando = true;
                    controlNave.controlTextoNave.EdgarHablando = false;
                    if (count == 321)
                    {
                        AudioDialogos.Stop();
                    }
                }
                if (S_Dialogos.id == 5)
                {
                    controlNave.controlTextoNave.AstroHablando = true;
                    controlNave.controlTextoNave.EdgarHablando = false;
                    if (count == 253)
                    {
                        AudioDialogos.Stop();
                    }
                }
                break;
            case 5:
                if (S_Dialogos.id == 1)
                {
                    controlNave.controlTextoNave.AstroHablando = false;
                    controlNave.controlTextoNave.EdgarHablando = true;
                    if (count == 410)
                    {
                        AudioDialogos.Stop();
                    }
                }
                if (S_Dialogos.id == 2)
                {
                    controlNave.controlTextoNave.AstroHablando = false;
                    controlNave.controlTextoNave.EdgarHablando = true;
                    if (count == 572)
                    {
                        AudioDialogos.Stop();
                    }
                }
                if (S_Dialogos.id == 3)
                {
                    controlNave.controlTextoNave.AstroHablando = false;
                    controlNave.controlTextoNave.EdgarHablando = true;
                    if (count == 326)
                    {
                        AudioDialogos.Stop();
                    }
                }
                if (S_Dialogos.id == 4)
                {
                    controlNave.controlTextoNave.AstroHablando = false;
                    controlNave.controlTextoNave.EdgarHablando = true;
                    if (count == 345)
                    {
                        AudioDialogos.Stop();
                    }
                }
                if (S_Dialogos.id == 5)
                {
                    controlNave.controlTextoNave.AstroHablando = false;
                    controlNave.controlTextoNave.EdgarHablando = true;
                    if (count == 280)
                    {
                        AudioDialogos.Stop();
                    }
                }
                break;
            case 6:
                if(S_Dialogos.id == 1)
                {
                    controlNave.controlTextoNave.EdgarHablando = true;
                    controlNave.controlTextoNave.AstroHablando = false;
                    if (count == 609)
                    {
                        AudioDialogos.Stop();
                    }
                }  
                if(S_Dialogos.id == 2)
                {
                    controlNave.controlTextoNave.AstroHablando = true;
                    controlNave.controlTextoNave.EdgarHablando = false;
                    if (count == 678)
                    {
                        AudioDialogos.Stop();
                    }
                }
                if(S_Dialogos.id == 3)
                {
                    controlNave.controlTextoNave.AstroHablando = false;
                    controlNave.controlTextoNave.EdgarHablando = true;
                    if (count == 568)
                    {
                        AudioDialogos.Stop();
                    }
                }
                if(S_Dialogos.id == 4)
                {
                    controlNave.controlTextoNave.AstroHablando = true;
                    controlNave.controlTextoNave.EdgarHablando = false;
                    if (count == 392)
                    {
                        AudioDialogos.Stop();
                    }
                }
                if(S_Dialogos.id == 5)
                {
                    controlNave.controlTextoNave.AstroHablando = true;
                    controlNave.controlTextoNave.EdgarHablando = false;
                    if (count == 469)
                    {
                        AudioDialogos.Stop();
                    }
                }
                break;

            case 7:
                if(S_Dialogos.id == 1)
                {
                    controlNave.controlTextoNave.AstroHablando = true;
                    controlNave.controlTextoNave.EdgarHablando = false;
                    if (count == 699)
                    {
                        AudioDialogos.Stop();
                    }
                }
                if(S_Dialogos.id == 2)
                {
                    controlNave.controlTextoNave.AstroHablando = false;
                    controlNave.controlTextoNave.EdgarHablando = false;
                    controlNave.ControlPanelesNave.ActivarPanelTexto = false;
                    controlNave.controlTextoNave.hablando = false;
                    controlNave.controlTextoNave.PanelPerrosActivo = false;
                    currentSentence = 0;
                    E.SetActive(false);
                    Used = 1;
                    AudioDialogos.Stop();
                }
                if(S_Dialogos.id == 3)
                {
                    controlNave.controlTextoNave.AstroHablando = false;
                    controlNave.controlTextoNave.EdgarHablando = true;
                    if (count == 772)
                    {
                        AudioDialogos.Stop();
                    }
                }
                if(S_Dialogos.id == 4)
                {
                    controlNave.controlTextoNave.AstroHablando = false;
                    controlNave.controlTextoNave.EdgarHablando = true;
                    if (count == 563)
                    {
                        AudioDialogos.Stop();
                    }
                }
                if(S_Dialogos.id == 5)
                {
                    controlNave.controlTextoNave.AstroHablando = false;
                    controlNave.controlTextoNave.EdgarHablando = true;
                    if (count == 526)
                    {
                        AudioDialogos.Stop();
                    }
                }
                break;

            case 8:
                if(S_Dialogos.id == 1)
                {
                        controlNave.controlTextoNave.AstroHablando = false;
                        controlNave.controlTextoNave.EdgarHablando = false;
                        controlNave.ControlPanelesNave.ActivarPanelTexto = false;
                        controlNave.controlTextoNave.hablando = false;
                        controlNave.controlTextoNave.PanelPerrosActivo = false;
                        currentSentence = 0;
                        E.SetActive(false);
                        AudioDialogos.Stop();
                        Used = 1;
                }
                if(S_Dialogos.id == 3)
                {
                    controlNave.controlTextoNave.AstroHablando = true;
                    controlNave.controlTextoNave.EdgarHablando = false;
                    if(count == 881)
                    {
                        AudioDialogos.Stop();
                    }
                }
                if(S_Dialogos.id == 4)
                {
                    controlNave.controlTextoNave.AstroHablando = false;
                    controlNave.controlTextoNave.EdgarHablando = true;
                    if (count == 786)
                    {
                        AudioDialogos.Stop();
                    }
                }
                if(S_Dialogos.id == 5)
                {
                    controlNave.controlTextoNave.AstroHablando = true;
                    controlNave.controlTextoNave.EdgarHablando = false;
                    if (count == 552)
                    {
                        AudioDialogos.Stop();
                    }
                }
                break;
            case 9:
                if(S_Dialogos.id == 3)
                {
                    controlNave.controlTextoNave.AstroHablando = false;
                    controlNave.controlTextoNave.EdgarHablando = false;
                    controlNave.ControlPanelesNave.ActivarPanelTexto = false;
                    controlNave.controlTextoNave.hablando = false;
                    controlNave.controlTextoNave.PanelPerrosActivo = false;    
                    E.SetActive(false);
                    currentSentence = 0;
                    AudioDialogos.Stop();
                    Used = 1;
                    if (inventorySystem.slot1Active != true)
                    {
                        inventorySystem.slot1.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                        inventorySystem.slot1Active = true;
                        inventorySystem.ItemList[0] = "Coordenada 1";
                        inventorySystem.coordenadaCount++;
                    }
                   
                    if (inventorySystem.slot2Active != true)
                    {
                        inventorySystem.slot2.gameObject.transform.GetChild(2).gameObject.SetActive(true);
                        inventorySystem.slot2Active = true;
                        inventorySystem.ItemList[1] = "Llave";
                    }
                }
                if(S_Dialogos.id == 4)
                {
                    controlNave.controlTextoNave.AstroHablando = false;
                    controlNave.controlTextoNave.EdgarHablando = true;
                    if (count == 1008)
                    {
                        AudioDialogos.Stop();
                    }
                }
                if(S_Dialogos.id == 5)
                {
                    controlNave.controlTextoNave.AstroHablando = false;
                    controlNave.controlTextoNave.EdgarHablando = true;
                    if (count == 636)
                    {
                        AudioDialogos.Stop();
                    }
                }

                break;
            case 10:
                if(S_Dialogos.id == 4)
                {
                    controlNave.controlTextoNave.AstroHablando = true;
                    controlNave.controlTextoNave.EdgarHablando = false;
                    if (count == 1135)
                    {
                        AudioDialogos.Stop();
                    }
                }
                if(S_Dialogos.id == 5)
                {
                    controlNave.controlTextoNave.AstroHablando = true;
                    controlNave.controlTextoNave.EdgarHablando = false;
                    if (count == 726)
                    {
                        AudioDialogos.Stop();
                    }
                }
                break;
            case 11:
                if(S_Dialogos.id == 4)
                {
                    controlNave.controlTextoNave.AstroHablando = false;
                    controlNave.controlTextoNave.EdgarHablando = true;
                    if (count == 1311)
                    {
                        AudioDialogos.Stop();
                        //1338
                    }
                }
                if(S_Dialogos.id == 5)
                {
                    controlNave.controlTextoNave.AstroHablando = false;
                    controlNave.controlTextoNave.EdgarHablando = false;
                    controlNave.ControlPanelesNave.ActivarPanelTexto = false;
                    controlNave.controlTextoNave.hablando = false;
                    controlNave.controlTextoNave.PanelPerrosActivo = false;
                    E.SetActive(false);
                    currentSentence = 0;
                    AudioDialogos.Stop();
                    Used = 1;
                }
                break;
            case 12:
                if(S_Dialogos.id == 4)
                {
                    controlNave.controlTextoNave.AstroHablando = true;
                    controlNave.controlTextoNave.EdgarHablando = false;
                    if (count == 1338)
                    {
                        AudioDialogos.Stop();
                    }
                }
                break;
            case 13:
                if (S_Dialogos.id == 4)
                {
                    controlNave.controlTextoNave.AstroHablando = false;
                    controlNave.controlTextoNave.EdgarHablando = true;
                    if (count == 1450)
                    {
                        AudioDialogos.Stop();
                    }
                }
                break;
            case 14:
                if (S_Dialogos.id == 4)
                {
                    controlNave.controlTextoNave.AstroHablando = false;
                    controlNave.controlTextoNave.EdgarHablando = false;
                    controlNave.ControlPanelesNave.ActivarPanelTexto = false;
                    controlNave.controlTextoNave.hablando = false;
                    controlNave.controlTextoNave.PanelPerrosActivo = false;
                    currentSentence = 0;
                    E.SetActive(false);
                    AudioDialogos.Stop();
                    Used = 1;
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
                break;
        }
    }
}
