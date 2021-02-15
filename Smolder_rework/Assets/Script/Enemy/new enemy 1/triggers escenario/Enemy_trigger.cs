using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_trigger : MonoBehaviour
{
    [Header("Identificador")]
    public string tipo_trigger;
    public int isUsed;
    [Header("GameObjects")]
    public GameObject enemy_Gobj;
    public GameObject trigger;
    [Header("Transform")]
    public Transform point;
    [Header("Scripts")]
    public Enemy_1_IA enemy_scr;
    [Header("Audios")]
    public AudioClip inter;
    private AudioSource audiointeraccion;



    void Start()
    {
        audiointeraccion = GetComponent<AudioSource>();
        enemy_scr.movimiento.move = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == ("Player"))
        {
            if(tipo_trigger == ("entrada") && isUsed !=1) // si el player colisiona con este trigger y tiene el string necesario, se activara el enemigo para que aparesca y asuste
            {
                audiointeraccion.clip = inter;
                audiointeraccion.Play();         // aqui activa el audio pa asustar diego
                Invoke("PointAssing", 0.5f);
                isUsed = 1;
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
               // trigger.SetActive(false);
            }
        }
    }

    public void PointAssing()
    {
        enemy_scr.patrol.isHide = true;
        enemy_scr.patrol.Points[0] = point;
        enemy_scr.sensor.CurrentTarget = enemy_scr.patrol.Points[0];
        enemy_scr.movimiento.move = true;
    }
}
