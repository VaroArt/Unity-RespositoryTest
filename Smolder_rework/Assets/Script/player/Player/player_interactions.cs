using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;

public class player_interactions : MonoBehaviour
{

    /* private AudioSource myaudio;  // estas variables de aqui a abajo son las que usaste diego pal audio, de la camara y pa cambiar el audio a otro
     public  AudioSource cAudio;
     public AudioClip test;*/
    public Dialogue_Manager manager;
   // public string currentItem;
   // public int coordenadaCount;
   // public Image Llave, Coordenada1, Coordenada2;
    void Start()
    {
        //   myaudio = GetComponent<AudioSource>(); // esto vo mismo me lo enseñaste asi que no se porque te lo comento
      //  currentItem = ("null");
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

  
    public void OnTriggerEnter2D(Collider2D collision)
    {
        /*   if (collision.tag == ("Interaction")) //aca si colisiona con interaction, pues se reproduce audio, aqui para el audio de la capara y reproduce el que se le agrega a este scrip
           {

               myaudio.clip = test;
               myaudio.Play();
               cAudio.Stop();
           }*/
        /*   if (collision.tag == ("Interaction2"))
           {

           }*/
       /* if (collision.tag == ("Evento Texto"))
        {
            manager = collision.GetComponent<Dialogue_Manager>();
        }*/
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
     /*   if (collision.tag == ("Evento Texto"))
        {
            if(manager.S_Dialogos.id == 4)
            {
                if(manager.currentSentence == 6)
                {
                    print("fin del dialogo, dame mi item");
                    Llave.gameObject.SetActive(true);
                    currentItem = ("Llave");
                }
            }
            if (manager.S_Dialogos.id == 1)
            {
                if (manager.currentSentence == 6)
                {
                    print("fin del dialogo, dame mi item 2");
                    Coordenada1.gameObject.SetActive(true);
                    currentItem = ("Coordenada");
                    coordenadaCount++;
                }
            }
            if (manager.S_Dialogos.id == 2)
            {
                if (manager.currentSentence == 7)
                {
                    print("fin del dialogo, dame mi item 3");
                    if(currentItem == ("Llave"))
                    {
                        Coordenada2.gameObject.SetActive(true);
                        currentItem = ("Coordenada");
                        print("Abri la nave y tengo su coordenada");
                        coordenadaCount++;
                    }
                 
                }
            }
        }*/
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        /*  if (collision.tag == ("Interaction"))
          {
              myaudio.Stop();  // aca es pa volver al audio de camara original, no creo que lo usemos
              cAudio.Play();
          }*/
      /*  if (collision.tag == ("Evento Texto"))
        {
            manager = null;
        }*/
    }
}
