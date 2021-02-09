using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInteractions : MonoBehaviour
{
    public int ID;
    public  int isUsed;
    public GameObject E;
    public Image imageMensaje;
    public Text textImage;
    public Animator imageAnim, textAnim;
    public float timer;
    public BengalSystem bengala;
    public player_script player;


    public AudioClip recolectar;
    public AudioSource audioItems;

    void Start()
    {
        audioItems = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("Player") && isUsed != 1)
        {
            E.gameObject.SetActive(true);
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == ("Player") && isUsed !=1)
        {
            if(ID == 1)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    print("bengala y turbo");
                    imageMensaje.gameObject.SetActive(true); // hago visible el cuadro 
                    textImage.gameObject.SetActive(true); //y el texto
                    audioItems.clip = recolectar;
                    audioItems.Play(); //Se reproduce el audio
                    isUsed = 1;  //Se setea que se pueda usar solo 1 vez
                    E.SetActive(false);
                    timer -= Time.deltaTime;
                    Invoke("Off", 1f);
                    player.cantidadTurbo += 30f;
                    bengala.CantBengalas += 1;
                    imageAnim.SetBool("On", true); //Se activa la animacion
                    textAnim.SetBool("On", true); //Se activa la animacion
                }
            }
            if (ID == 2)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    print("turbo");
                    imageMensaje.gameObject.SetActive(true); // hago visible el cuadro 
                    textImage.gameObject.SetActive(true); //y el texto
                    audioItems.clip = recolectar;
                    audioItems.Play(); //Se reproduce el audio
                    isUsed = 1; //Se setea que se pueda usar solo 1 vez
                    E.SetActive(false);
                    timer -= Time.deltaTime;
                    Invoke("Off", 1f);
                    player.cantidadTurbo += 30f;
                    imageAnim.SetBool("On", true); //Se activa la animacion
                    textAnim.SetBool("On", true); //Se activa la animacion
                }
            }
            if (ID == 3)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    print("bengala");
                    imageMensaje.gameObject.SetActive(true); // hago visible el cuadro 
                    textImage.gameObject.SetActive(true); //y el texto
                    audioItems.clip = recolectar;
                    audioItems.Play(); //Se reproduce el audio
                    isUsed = 1; //Se setea que se pueda usar solo 1 vez
                    E.SetActive(false);
                    timer -= Time.deltaTime;
                    Invoke("Off", 1f);
                    bengala.CantBengalas += 1;
                    imageAnim.SetBool("On", true); //Se activa la animacion
                    textAnim.SetBool("On", true); //Se activa la animacion
                }
            }
            if (ID == 4)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    print("bengala y turbo");
                    imageMensaje.gameObject.SetActive(true); // hago visible el cuadro 
                    textImage.gameObject.SetActive(true); //y el texto
                    audioItems.clip = recolectar;
                    audioItems.Play(); //Se reproduce el audio
                    isUsed = 1; //Se setea que se pueda usar solo 1 vez
                    E.SetActive(false);
                    timer -= Time.deltaTime;
                    Invoke("Off", 1f);
                    bengala.CantBengalas += 1;
                    imageAnim.SetBool("On", true); //Se activa la animacion
                    textAnim.SetBool("On", true); //Se activa la animacion
                }
            }

        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == ("Player"))
        {
            E.gameObject.SetActive(false);

        }
       
    }
    public void Off()
    {
        imageAnim.SetBool("IsFinish", true);
        textAnim.SetBool("isFinish", true);
        imageAnim.SetBool("On", false);
        textAnim.SetBool("On", false);

    }
}
