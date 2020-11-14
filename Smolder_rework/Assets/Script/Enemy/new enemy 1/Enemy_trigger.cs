using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_trigger : MonoBehaviour
{
    public string tipo_trigger;
    public GameObject enemy_Gobj;
    public Transform point;
    public Enemy_1_IA enemy_scr;

    void Start()
    {
        
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
              
              //  enemy_Gobj.gameObject.SetActive(true);
                Invoke("PointAssing", 0.5f);
            }
            if (tipo_trigger == ("entrada2")) // si el player colisiona con este trigger y tiene el string necesario, se activara el enemigo para que aparesca y asuste
            {

             //   enemy_Gobj.gameObject.SetActive(true);
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

    public void PointAssing()
    {
        enemy_scr.patrol.isHide = true;
        enemy_scr.patrol.Points[0] = point;
    }
}
