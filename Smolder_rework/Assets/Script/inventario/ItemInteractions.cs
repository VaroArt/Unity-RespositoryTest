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
    void Start()
    {
        
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
                    isUsed = 1;
                    E.SetActive(false);
                    timer -= Time.deltaTime;
                    Invoke("Off", 1f);
                    player.cantidadTurbo += 30f;
                    bengala.CantBengalas += 1;
                }
            }
            if (ID == 2)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    print("turbo");
                    imageMensaje.gameObject.SetActive(true); // hago visible el cuadro 
                    textImage.gameObject.SetActive(true); //y el texto
                    isUsed = 1;
                    E.SetActive(false);
                    timer -= Time.deltaTime;
                    Invoke("Off", 1f);
                    player.cantidadTurbo += 30f;
                }
            }
            if (ID == 3)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    print("bengala");
                    imageMensaje.gameObject.SetActive(true); // hago visible el cuadro 
                    textImage.gameObject.SetActive(true); //y el texto
                    isUsed = 1;
                    E.SetActive(false);
                    timer -= Time.deltaTime;
                    Invoke("Off", 1f);
                    bengala.CantBengalas += 1;
                }
            }
            if (ID == 4)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    print("bengala y turbo");
                    imageMensaje.gameObject.SetActive(true); // hago visible el cuadro 
                    textImage.gameObject.SetActive(true); //y el texto
                    isUsed = 1;
                    E.SetActive(false);
                    timer -= Time.deltaTime;
                    Invoke("Off", 1f);
                    bengala.CantBengalas += 1;
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
    }
}
