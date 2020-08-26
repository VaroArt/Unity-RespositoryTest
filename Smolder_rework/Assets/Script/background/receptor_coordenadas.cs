using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class receptor_coordenadas : MonoBehaviour
{
    public int coordenadas;
    public player_triggers player;
    public portal myportal;
    public Light2D light1;
    public GameObject CoordenadaOff;
    public GameObject CoordenadaOn;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("Player"))
        {
            if (player.currentObject == ("coordenada")&& coordenadas!=1)
            {
                light1.intensity = 3.68f;
                CoordenadaOff.gameObject.SetActive(false);
                CoordenadaOn.gameObject.SetActive(true);
                // print("coordenadas");
                coordenadas++;
                myportal.coordenadasCount ++;
                player.curretCoordenada.gameObject.SetActive(false);
            }
        }
    }
}
