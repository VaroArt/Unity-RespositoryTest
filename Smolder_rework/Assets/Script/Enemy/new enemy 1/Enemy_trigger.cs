using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_trigger : MonoBehaviour
{
    public string tipo_trigger;
    public GameObject enemy_Gobj;
    public Transform point;
    public Enemy_1_IA enemy_scr;
    public GameObject trigger;
    public AudioClip inter;

    private AudioSource audiointeraccion;



    void Start()
    {
        audiointeraccion = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == ("Player"))
        {
            if(tipo_trigger == ("entrada")) // si el player colisiona con este trigger y tiene el string necesario, se activara el enemigo para que aparesca y asuste
            {
                audiointeraccion.clip = inter;
                audiointeraccion.Play();         // aqui activa el audio pa asustar diego
             
                Invoke("PointAssing", 0.5f);
            }
            if (tipo_trigger == ("entrada2")) // si el player colisiona con este trigger y tiene el string necesario, se activara el enemigo para que aparesca y asuste
            {

                                                // esto es una prueba, pa la interaccion expecifica que marcaste, pero ta incompleto y no lo voy a usar pal testeo
                Invoke("PointAssing", 0.5f);
            }
        }
        if(collision.tag == ("Enemy")) // para que el enemigo desaparesca
        {
            if(tipo_trigger == ("salida"))
            {
                enemy_Gobj.gameObject.SetActive(false);
                enemy_scr.patrol.isHide = false;
            }
           
        }

    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == ("Player"))
        {
            if(tipo_trigger == ("entrada"))
            {
                trigger.SetActive(false);
            }
        }
    }

    public void PointAssing()
    {
        enemy_scr.patrol.isHide = true;
        enemy_scr.patrol.Points[0] = point;
    }
}
