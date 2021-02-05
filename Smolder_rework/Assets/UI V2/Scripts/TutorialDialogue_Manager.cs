using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialDialogue_Manager : MonoBehaviour
{
    public Dialogos S_TDialogos;
    public UI_ControlNaveSc C_Nave;
    public TutorialController elementosTutorial;
    public BengalSystem bengala;
    public player_script player;
    Queue<string> Sentencias;
    [Space(20)]
    public GameObject PanelDialogo;
    public Text Display;
    public GameObject nextbton;
    string sentenciaActiva;
    public float typingSpeed;
    public int currentSentence;
    public GameObject E;
    public InventarioSystem inventorySystem;
    public int Used;
    [Header("sonidos")]
    private AudioSource AudioDialogos;
    public AudioClip DialogoClip;
    public int count;
    void Start()
    {
        AudioDialogos = GetComponent<AudioSource>();
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
            count++;
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
                    print("E");
                }
                if(S_TDialogos.id == 0)
                {
                    IniciarDialogo();
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
                    if (S_TDialogos.id == 0)
                    {
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            elementosTutorial.tutotial_elements.IsAstro1Act = false;
                            elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                            elementosTutorial.tutotial_elements.Texto1Activo = true;
                            elementosTutorial.tutotial_elements.TutoPanelCentral = true;
                            elementosTutorial.tutotial_elements.TutoBtonLuz = false;
                            elementosTutorial.tutotial_elements.TutoFuncionLuz = false;
                            MostrarSigSentencia();
                            currentSentence++;
                            AudioDialogos.clip = DialogoClip; // reproducir el audio cuando inicia el dialogo
                            AudioDialogos.Play();
                        }
                    }
                    nextbton.SetActive(true);
                 
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (S_TDialogos.id == 1000 && currentSentence != 4)
                        {
                            elementosTutorial.tutotial_elements.IsAstro1Act = true;
                            elementosTutorial.tutotial_elements.IsEdgar1Act = false;
                            elementosTutorial.tutotial_elements.Texto1Activo = true;
                            elementosTutorial.tutotial_elements.TutoPanelCentral = true;
                            elementosTutorial.tutotial_elements.TutoBtonLuz = false;
                            elementosTutorial.tutotial_elements.TutoFuncionLuz = false;
                            MostrarSigSentencia();
                            currentSentence++;
                            AudioDialogos.clip = DialogoClip; // reproducir el audio cuando inicia el dialogo
                            AudioDialogos.Play();
                        }
                        if(S_TDialogos.id == 1001)
                        {
                            elementosTutorial.tutotial_elements.IsAstro1Act = false;
                            elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                            elementosTutorial.tutotial_elements.Texto1Activo = true;
                            elementosTutorial.tutotial_elements.TutoPanelCentral = true;
                            elementosTutorial.tutotial_elements.TutoBtonRadar = false;
                            elementosTutorial.tutotial_elements.TutoPanelRadar = false;
                            MostrarSigSentencia();
                            currentSentence++;
                            AudioDialogos.clip = DialogoClip; // reproducir el audio cuando inicia el dialogo
                            AudioDialogos.Play();
                        }
                        if (S_TDialogos.id == 1002 && currentSentence !=8)
                        {
                            elementosTutorial.tutotial_elements.Texto1Activo = true;
                            elementosTutorial.tutotial_elements.TutoPanelCentral = true;
                            elementosTutorial.tutotial_elements.TutoBtonMotor = false;
                            elementosTutorial.tutotial_elements.TutoFuncionMotor = false;
                            AudioDialogos.clip = DialogoClip; // reproducir el audio cuando inicia el dialogo
                            AudioDialogos.Play();

                            MostrarSigSentencia();
                            currentSentence++;
                        }
                        if (S_TDialogos.id == 1003)
                        {
                            elementosTutorial.tutotial_elements.Texto1Activo = true;
                            elementosTutorial.tutotial_elements.TutoPanelCentral = true;
                            MostrarSigSentencia();
                            currentSentence++;
                            AudioDialogos.clip = DialogoClip; // reproducir el audio cuando inicia el dialogo
                            AudioDialogos.Play();
                        }
                        if (S_TDialogos.id == 1004)
                        {
                            elementosTutorial.tutotial_elements.Texto2Activo = true;
                            elementosTutorial.tutotial_elements.TutoPanelCentral = true;
                            elementosTutorial.tutotial_elements.TutoBtonInventario = false;
                            elementosTutorial.tutotial_elements.TutoPanelInventario = false;
                            MostrarSigSentencia();
                            currentSentence++;
                            AudioDialogos.clip = DialogoClip; // reproducir el audio cuando inicia el dialogo
                            AudioDialogos.Play();
                        }
                        if (S_TDialogos.id == 1005)
                        {
                            elementosTutorial.tutotial_elements.Texto1Activo = true;
                            elementosTutorial.tutotial_elements.TutoPanelCentral = true;
                            elementosTutorial.tutotial_elements.TutoBtonRecarga = false;
                            elementosTutorial.tutotial_elements.TutopanelRegarga = false;
                            MostrarSigSentencia();
                            currentSentence++;
                            AudioDialogos.clip = DialogoClip; // reproducir el audio cuando inicia el dialogo
                            AudioDialogos.Play();
                        }
                        if (S_TDialogos.id == 1006)
                        {
                            elementosTutorial.tutotial_elements.Texto1Activo = true;
                            elementosTutorial.tutotial_elements.TutoPanelCentral = true;
                            MostrarSigSentencia();
                            currentSentence++;
                            AudioDialogos.clip = DialogoClip; // reproducir el audio cuando inicia el dialogo
                            AudioDialogos.Play();
                        }
                        if (S_TDialogos.id == 1007)
                        {
                            elementosTutorial.tutotial_elements.Texto1Activo = true;
                            elementosTutorial.tutotial_elements.TutoPanelCentral = true;
                            MostrarSigSentencia();
                            currentSentence++;
                            AudioDialogos.clip = DialogoClip; // reproducir el audio cuando inicia el dialogo
                            AudioDialogos.Play();
                        }
                        if (S_TDialogos.id == 1008)
                        {
                            elementosTutorial.tutotial_elements.Texto1Activo = true;
                            elementosTutorial.tutotial_elements.TutoPanelCentral = true;
                            MostrarSigSentencia();
                            currentSentence++;
                            AudioDialogos.clip = DialogoClip; // reproducir el audio cuando inicia el dialogo
                            AudioDialogos.Play();
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
        elementosTutorial.tutotial_elements.TutoBtonRecarga = false;
        elementosTutorial.tutotial_elements.TutopanelRegarga = false;
        elementosTutorial.tutotial_elements.TutoBtonInventario = false;
        elementosTutorial.tutotial_elements.TutoPanelInventario = false;
        elementosTutorial.tutotial_elements.TutoPanelRadar = false;
        elementosTutorial.tutotial_elements.TutoBtonRadar = false;
        elementosTutorial.tutotial_elements.Texto2Activo = false;
        elementosTutorial.tutotial_elements.IsAstro2Act = false;
        elementosTutorial.tutotial_elements.IsEdgar2Act = true;
        elementosTutorial.tutotial_elements.Texto1Activo = false;
        elementosTutorial.tutotial_elements.TutoPanelCentral = false;
        elementosTutorial.tutotial_elements.TutoBtonLuz = false;
        elementosTutorial.tutotial_elements.TutoFuncionLuz = false;
        elementosTutorial.tutotial_elements.TutoBtonMotor = false;
        elementosTutorial.tutotial_elements.TutoFuncionMotor = false;
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
                if(S_TDialogos.id == 0)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                    if(count == 92)
                    {
                        AudioDialogos.Stop();
                    }
                }
                if (S_TDialogos.id == 1000)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                    elementosTutorial.tutotial_elements.TutoPanelCentral = false;
                    elementosTutorial.tutotial_elements.TutoBtonLuz = true;
                    elementosTutorial.tutotial_elements.TutoFuncionLuz = false;
                    if (count == 167)
                    {
                        AudioDialogos.Stop();
                    }

                }
                if (S_TDialogos.id == 1001)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                    elementosTutorial.tutotial_elements.TutoPanelCentral = true;
                    elementosTutorial.tutotial_elements.TutoBtonRadar = false;
                    elementosTutorial.tutotial_elements.TutoPanelRadar = false;
                    if (count == 158)
                    {
                        AudioDialogos.Stop();
                    }
                }
                if (S_TDialogos.id == 1002)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                    elementosTutorial.tutotial_elements.TutoPanelCentral = false;
                    elementosTutorial.tutotial_elements.TutoBtonMotor = true;
                    elementosTutorial.tutotial_elements.TutoFuncionMotor = false;
                    if (count == 129)
                    {
                        AudioDialogos.Stop();
                    }
                }
                if (S_TDialogos.id == 1003)
                {

                }
                if (S_TDialogos.id == 1004)
                {
                    elementosTutorial.tutotial_elements.IsAstro2Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar2Act = true;
                    elementosTutorial.tutotial_elements.TutoBtonInventario = true;
                    elementosTutorial.tutotial_elements.TutoPanelInventario = false;
                    elementosTutorial.tutotial_elements.TutoPanelCentral = false;
                    if (count == 122)
                    {
                        AudioDialogos.Stop();
                    }
                }
                if (S_TDialogos.id == 1005)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                    elementosTutorial.tutotial_elements.TutoPanelCentral = true;
                    elementosTutorial.tutotial_elements.TutoBtonRecarga = false;
                    elementosTutorial.tutotial_elements.TutopanelRegarga = false;
                    if (count == 117)
                    {
                        AudioDialogos.Stop();
                    }
                }
                if (S_TDialogos.id == 1006)
                {
                }
                if (S_TDialogos.id == 1007)
                {
                }
                if (S_TDialogos.id == 1008)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = true;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = false;
                    if (count == 47)
                    {
                        AudioDialogos.Stop();
                    }
                }
                break;
            case 2:
                if (S_TDialogos.id == 0)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = true;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = false;
                    if (count == 121)
                    {
                        AudioDialogos.Stop();
                    }
                }
                if (S_TDialogos.id == 1000)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = true;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = false;
                    elementosTutorial.tutotial_elements.TutoPanelCentral = false;
                    elementosTutorial.tutotial_elements.TutoBtonLuz = true;
                    elementosTutorial.tutotial_elements.TutoFuncionLuz = false;
                    if (count == 208)
                    {
                        AudioDialogos.Stop();
                    }
                }
                if (S_TDialogos.id == 1001)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = true;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = false;
                    elementosTutorial.tutotial_elements.TutoPanelCentral = true;
                    elementosTutorial.tutotial_elements.TutoBtonRadar = false;
                    elementosTutorial.tutotial_elements.TutoPanelRadar = false;
                    if (count == 300)
                    {
                        AudioDialogos.Stop();
                    }
                }
                if (S_TDialogos.id == 1002)
                {
                    C_Nave.OpcionesMYL.InfoMotorActiva = true;
                    elementosTutorial.tutotial_elements.IsAstro1Act = true;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = false;
                    elementosTutorial.tutotial_elements.TutoPanelCentral = false;
                    elementosTutorial.tutotial_elements.TutoBtonMotor = false;
                    elementosTutorial.tutotial_elements.TutoFuncionMotor = true;
                    if (count == 282)
                    {
                        AudioDialogos.Stop();
                    }
                }
                if (S_TDialogos.id == 1003)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                }
                if (S_TDialogos.id == 1004)
                {
                    C_Nave.ControlPanelesNave.ActivarPanelInventario = true;
                    elementosTutorial.tutotial_elements.IsAstro2Act = true;
                    elementosTutorial.tutotial_elements.IsEdgar2Act = false;
                    elementosTutorial.tutotial_elements.TutoBtonInventario = false;
                    elementosTutorial.tutotial_elements.TutoPanelInventario = true;
                    elementosTutorial.tutotial_elements.TutoPanelCentral = false;
                    if (count == 180)
                    {
                        AudioDialogos.Stop();
                    }
                }
                if (S_TDialogos.id == 1005)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = true;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = false;
                    elementosTutorial.tutotial_elements.TutoPanelCentral = false;
                    elementosTutorial.tutotial_elements.TutoBtonRecarga = true;
                    elementosTutorial.tutotial_elements.TutopanelRegarga = false;
                    if (count == 204)
                    {
                        AudioDialogos.Stop();
                    }
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
                    if (inventorySystem.slot2Active != true)
                    {
                        inventorySystem.slot2.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                        inventorySystem.slot2Active = true;
                        inventorySystem.ItemList[1] = "Coordenada 2";
                        inventorySystem.coordenadaCount++;
                    }
                    if (count == 161)
                    {
                        AudioDialogos.Stop();
                    }
                }
                break;

            case 3:
                if (S_TDialogos.id == 0)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                    if (count == 204)
                    {
                        AudioDialogos.Stop();
                    }
                    // elementosTutorial.tutotial_elements.TutoBtonDron = true;
                    // elementosTutorial.tutotial_elements.TutoPanelCentral = false;
                }
                if (S_TDialogos.id == 1000)
                {
                    C_Nave.OpcionesMYL.InfoLuzActiva = true;
                    elementosTutorial.tutotial_elements.nextBtonact = true;
                    elementosTutorial.tutotial_elements.IsAstro1Act = true;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = false;
                    elementosTutorial.tutotial_elements.TutoPanelCentral = false;
                    elementosTutorial.tutotial_elements.TutoBtonLuz = false;
                    elementosTutorial.tutotial_elements.TutoFuncionLuz = true;
                    if (count == 284)
                    {
                        AudioDialogos.Stop();
                    }
                }
                if (S_TDialogos.id == 1001)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                    elementosTutorial.tutotial_elements.TutoPanelCentral = false;
                    elementosTutorial.tutotial_elements.TutoBtonRadar = true;
                    elementosTutorial.tutotial_elements.TutoPanelRadar = false;
                    if (count == 369)
                    {
                        AudioDialogos.Stop();
                    }
                }
                if (S_TDialogos.id == 1002)
                {
                    C_Nave.OpcionesMYL.InfoMotorActiva = true;
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                    elementosTutorial.tutotial_elements.TutoPanelCentral = false;
                    elementosTutorial.tutotial_elements.TutoBtonMotor = false;
                    elementosTutorial.tutotial_elements.TutoFuncionMotor = true;
                    if (count == 291)
                    {
                        AudioDialogos.Stop();
                    }
                }
                if (S_TDialogos.id == 1003)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                }
                if (S_TDialogos.id == 1004)
                {
                    C_Nave.ControlPanelesNave.ActivarPanelInventario = true;
                    elementosTutorial.tutotial_elements.IsAstro2Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar2Act = true;
                    elementosTutorial.tutotial_elements.TutoBtonInventario = false;
                    elementosTutorial.tutotial_elements.TutoPanelInventario = true;
                    elementosTutorial.tutotial_elements.TutoPanelCentral = false;
                    if (count == 200)
                    {
                        AudioDialogos.Stop();
                    }

                }
                if (S_TDialogos.id == 1005)
                {
                    C_Nave.ControlPanelesNave.ActivarPanelRecarga = true;
                    elementosTutorial.tutotial_elements.IsAstro1Act = true;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = false;
                    elementosTutorial.tutotial_elements.TutoPanelCentral = false;
                    elementosTutorial.tutotial_elements.TutoBtonRecarga = false;
                    elementosTutorial.tutotial_elements.TutopanelRegarga = true;
                    if (count == 274)
                    {
                        AudioDialogos.Stop();
                    }
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
                    elementosTutorial.tutotial_elements.IsAstro1Act = true;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = false;
                    if (count == 281)
                    {
                        AudioDialogos.Stop();
                    }
                }
                break;

            case 4:
                if (S_TDialogos.id == 0)
                {
                    elementosTutorial.tutotial_elements.TutoBtonDron = true;
                    elementosTutorial.tutotial_elements.IsAstro1Act = true;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = false;
                    elementosTutorial.tutotial_elements.TutoPanelCentral = false;
                    if (count == 331)
                    {
                        AudioDialogos.Stop();
                    }
                }
                if (S_TDialogos.id == 1000)
                {
                    C_Nave.OpcionesMYL.InfoLuzActiva = true;
                    elementosTutorial.tutotial_elements.nextBtonact = true;
                    elementosTutorial.tutotial_elements.IsAstro1Act = true;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = false;
                    elementosTutorial.tutotial_elements.TutoPanelCentral = false;
                    elementosTutorial.tutotial_elements.TutoBtonLuz = false;
                    elementosTutorial.tutotial_elements.TutoFuncionLuz = true;
                    AudioDialogos.Stop();

                }
                if (S_TDialogos.id == 1001)
                {
                    C_Nave.ControlPanelesNave.ActivarPanelRadar = true;
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                    elementosTutorial.tutotial_elements.TutoPanelCentral = false;
                    elementosTutorial.tutotial_elements.TutoBtonRadar = false;
                    elementosTutorial.tutotial_elements.TutoPanelRadar = true;
                    if (count == 455)
                    {
                        AudioDialogos.Stop();
                    }
                }
                if (S_TDialogos.id == 1002)
                {
                    C_Nave.OpcionesMYL.InfoMotorActiva = false;
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                    elementosTutorial.tutotial_elements.TutoPanelCentral = true;
                    elementosTutorial.tutotial_elements.TutoBtonMotor = false;
                    elementosTutorial.tutotial_elements.TutoFuncionMotor = false;
                    if (count == 294)
                    {
                        AudioDialogos.Stop();
                    }
                }
                if (S_TDialogos.id == 1003)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                }
                if (S_TDialogos.id == 1004)
                {
                    C_Nave.ControlPanelesNave.ActivarPanelInventario = false;
                    elementosTutorial.tutotial_elements.Texto2Activo = false;
                    elementosTutorial.tutotial_elements.TutoPanelCentral = false;
                    elementosTutorial.tutotial_elements.TutoBtonInventario = false;
                    elementosTutorial.tutotial_elements.TutoPanelInventario = false;
                    elementosTutorial.tutotial_elements.IsAstro2Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar2Act = false;
                    currentSentence = 0;
                    E.SetActive(false);
                    AudioDialogos.Stop();
                    Used = 1;
                }
                if (S_TDialogos.id == 1005)
                {
                    C_Nave.ControlPanelesNave.ActivarPanelRecarga = true;
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                    elementosTutorial.tutotial_elements.TutoPanelCentral = false;
                    elementosTutorial.tutotial_elements.TutoBtonRecarga = false;
                    elementosTutorial.tutotial_elements.TutopanelRegarga = true;
                    if (count == 382)
                    {
                        AudioDialogos.Stop();
                    }
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
                    if (count == 448)
                    {
                        AudioDialogos.Stop();
                    }
                }
                break;
            case 5:
                if(S_TDialogos.id == 0)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = true;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = false;
                    elementosTutorial.tutotial_elements.TutoPanelCentral = false;
                    if (count == 442)
                    {
                        AudioDialogos.Stop();
                    }
                }
                if (S_TDialogos.id == 1001)
                {
                    C_Nave.ControlPanelesNave.ActivarPanelRadar = false;
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = false;
                    elementosTutorial.tutotial_elements.Texto1Activo = false;
                    elementosTutorial.tutotial_elements.TutoBtonRadar = false;
                    elementosTutorial.tutotial_elements.TutoPanelCentral = false;
                    elementosTutorial.tutotial_elements.TutoPanelRadar = false;
                    currentSentence = 0;
                    E.SetActive(false);
                    AudioDialogos.Stop();
                    Used = 1;
                }
                if (S_TDialogos.id == 1002)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                    elementosTutorial.tutotial_elements.TutoPanelCentral = true;
                    elementosTutorial.tutotial_elements.TutoBtonMotor = false;
                    elementosTutorial.tutotial_elements.TutoFuncionMotor = false;
                    if (count == 359)
                    {
                        AudioDialogos.Stop();
                    }
                }
                if (S_TDialogos.id == 1003)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                }
                if (S_TDialogos.id == 1004)
                {

                }
                if (S_TDialogos.id == 1005)
                {
                    C_Nave.ControlPanelesNave.ActivarPanelRecarga = false;
                    elementosTutorial.tutotial_elements.IsAstro1Act = true;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = false;
                    elementosTutorial.tutotial_elements.TutoPanelCentral = true;
                    elementosTutorial.tutotial_elements.TutoBtonRecarga = false;
                    elementosTutorial.tutotial_elements.TutopanelRegarga = false;
                    if (count == 401)
                    {
                        AudioDialogos.Stop();
                    }
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
                    elementosTutorial.tutotial_elements.IsEdgar1Act = false;
                    elementosTutorial.tutotial_elements.Texto1Activo = false;
                    elementosTutorial.tutotial_elements.TutoPanelCentral = false;
                    currentSentence = 0;
                    E.SetActive(false);
                    Used = 1;
                    AudioDialogos.Stop();

                }
                break;
            case 6:
                if(S_TDialogos.id == 0)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                    elementosTutorial.tutotial_elements.TutoPanelCentral = false;
                    if (count == 451)
                    {
                        AudioDialogos.Stop();
                    }
                }
                if (S_TDialogos.id == 1001)
                {

                }
                if (S_TDialogos.id == 1002)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = true;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = false;
                    elementosTutorial.tutotial_elements.TutoPanelCentral = true;
                    elementosTutorial.tutotial_elements.TutoBtonMotor = false;
                    elementosTutorial.tutotial_elements.TutoFuncionMotor = false;
                    if (count == 462)
                    {
                        AudioDialogos.Stop();
                    }
                }
                if (S_TDialogos.id == 1003)
                {
                    currentSentence = 0;
                    E.SetActive(false);
                    this.gameObject.SetActive(false);
                }
                if (S_TDialogos.id == 1004)
                {
                    elementosTutorial.tutotial_elements.Texto2Activo = false;
                    elementosTutorial.tutotial_elements.TutoPanelCentral = false;
                    elementosTutorial.tutotial_elements.TutoBtonInventario = false;
                    elementosTutorial.tutotial_elements.TutoPanelInventario = false;
                    elementosTutorial.tutotial_elements.IsAstro2Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar2Act = false;
                    currentSentence = 0;
                    E.SetActive(false);
                    Used = 1;
                }
                if (S_TDialogos.id == 1005)
                {
                    C_Nave.ControlPanelesNave.ActivarPanelRecarga = false;
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = false;
                    elementosTutorial.tutotial_elements.TutoPanelCentral = false;
                    elementosTutorial.tutotial_elements.TutoBtonRecarga = false;
                    elementosTutorial.tutotial_elements.TutopanelRegarga = false;
                    elementosTutorial.tutotial_elements.Texto1Activo = false;
                    bengala.CantBengalas = 3;
                    AudioDialogos.Stop();
                    currentSentence = 0;
                    E.SetActive(false);
                    Used = 1;
                }
                if (S_TDialogos.id == 1006)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = false;
                    elementosTutorial.tutotial_elements.Texto1Activo = false;
                    elementosTutorial.tutotial_elements.TutoPanelCentral = false;
                    currentSentence = 0;
                    E.SetActive(false);
                    AudioDialogos.Stop();
                    Used = 1;
                }
                if (S_TDialogos.id == 1007)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = false;
                    elementosTutorial.tutotial_elements.Texto1Activo = false;
                    elementosTutorial.tutotial_elements.TutoPanelCentral = false;
                    currentSentence = 0;
                    E.SetActive(false);
                    Used = 1;
                }
                if (S_TDialogos.id == 1008)
                {


                }
                break;
            case 7:
                if(S_TDialogos.id == 0)
                {
                    elementosTutorial.tutotial_elements.Texto1Activo = false;
                    elementosTutorial.tutotial_elements.TutoPanelCentral = false;
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = false;
                    elementosTutorial.tutotial_elements.TutoBtonDron = false;
                    AudioDialogos.Stop();
                    E.gameObject.SetActive(false);

                    Used = 1;
                }
                if (S_TDialogos.id == 1001)
                {
                    C_Nave.ControlPanelesNave.ActivarPanelRadar = false;
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = false;
                    elementosTutorial.tutotial_elements.Texto1Activo = false;
                    elementosTutorial.tutotial_elements.TutoBtonRadar = false;
                    elementosTutorial.tutotial_elements.TutoPanelCentral = false;
                    elementosTutorial.tutotial_elements.TutoPanelRadar = false;
                    currentSentence = 0;
                    E.SetActive(false);
                }
                if (S_TDialogos.id == 1002)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = true;
                    elementosTutorial.tutotial_elements.TutoPanelCentral = true;
                    elementosTutorial.tutotial_elements.TutoBtonMotor = false;
                    elementosTutorial.tutotial_elements.TutoFuncionMotor = false;
                    if (count == 483)
                    {
                        AudioDialogos.Stop();
                    }
                    //para poder dar la primera coordenada
                    if (inventorySystem.slot1Active != true)
                    {
                        inventorySystem.slot1.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                        inventorySystem.slot1Active = true;
                        inventorySystem.ItemList[0] = "Coordenada 1";
                        inventorySystem.coordenadaCount++;
                    }
                    
                }
                if (S_TDialogos.id == 1003)
                {
                    currentSentence = 0;
                    E.SetActive(false);
                    this.gameObject.SetActive(false);
                }
                if (S_TDialogos.id == 1004)
                {
                    elementosTutorial.tutotial_elements.Texto2Activo = false;
                    elementosTutorial.tutotial_elements.TutoPanelCentral = false;
                    elementosTutorial.tutotial_elements.TutoBtonInventario = false;
                    elementosTutorial.tutotial_elements.TutoPanelInventario = false;
                    elementosTutorial.tutotial_elements.IsAstro2Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar2Act = false;
                    currentSentence = 0;
                    E.SetActive(false);
                }
                if (S_TDialogos.id == 1005)
                {
                    C_Nave.ControlPanelesNave.ActivarPanelRecarga = false;
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = false;
                    elementosTutorial.tutotial_elements.TutoPanelCentral = false;
                    elementosTutorial.tutotial_elements.TutoBtonRecarga = false;
                    elementosTutorial.tutotial_elements.TutopanelRegarga = false;
                    elementosTutorial.tutotial_elements.Texto1Activo = false;
                    currentSentence = 0;
                    E.SetActive(false);
                    Used = 1;

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
                break;
            case 8:
                if (S_TDialogos.id == 1002)  //off
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = false;
                    elementosTutorial.tutotial_elements.Texto1Activo = false;
                    elementosTutorial.tutotial_elements.TutoPanelCentral = false;
                    elementosTutorial.tutotial_elements.TutoBtonMotor = false;
                    elementosTutorial.tutotial_elements.TutoFuncionMotor = false;
                    AudioDialogos.Stop();
                    E.SetActive(false);
                    Used = 1;
                }
                if (S_TDialogos.id == 1003)
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
                break;
            case 9:
                if (S_TDialogos.id == 1002)
                {
                    elementosTutorial.tutotial_elements.IsAstro1Act = false;
                    elementosTutorial.tutotial_elements.IsEdgar1Act = false;
                    elementosTutorial.tutotial_elements.Texto1Activo = false;
                    elementosTutorial.tutotial_elements.TutoPanelCentral = false;
                    elementosTutorial.tutotial_elements.TutoBtonMotor = false;
                    elementosTutorial.tutotial_elements.TutoFuncionMotor = false;
                    currentSentence = 0;
                    E.SetActive(false);
                    Used = 1;
                }
                break;
        }

        if(currentSentence >= 10) //correccion de fallos
        {
            if (S_TDialogos.id == 1002)
            {
                elementosTutorial.tutotial_elements.IsAstro1Act = false;
                elementosTutorial.tutotial_elements.IsEdgar1Act = false;
                elementosTutorial.tutotial_elements.Texto1Activo = false;
                elementosTutorial.tutotial_elements.TutoPanelCentral = false;
                elementosTutorial.tutotial_elements.TutoBtonMotor = false;
                elementosTutorial.tutotial_elements.TutoFuncionMotor = false;
                currentSentence = 0;
                E.SetActive(false);
                Used = 1;
            }
        }
    }

    public void BtonNext()
    {
        if(S_TDialogos.id == 1000)
        {
            C_Nave.OpcionesMYL.InfoLuzActiva = false;
            elementosTutorial.tutotial_elements.IsAstro1Act = false;
            elementosTutorial.tutotial_elements.IsEdgar1Act = false;
            elementosTutorial.tutotial_elements.Texto1Activo = false;
            elementosTutorial.tutotial_elements.TutoPanelCentral = false;
            elementosTutorial.tutotial_elements.nextBtonact = false;
            elementosTutorial.tutotial_elements.TutoBtonLuz = false;
            elementosTutorial.tutotial_elements.TutoFuncionLuz = false;
            currentSentence = 0;
            E.SetActive(false);
            Used = 1;
            AudioDialogos.Stop();
        }

    }
}
