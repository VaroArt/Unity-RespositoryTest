using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class receptor_coordenadas : MonoBehaviour
{

    public player_interactions player;
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
            if(player.coordenadaCount == 1)
            {
                light1.intensity = 3.68f;
                CoordenadaOff.gameObject.SetActive(false);
                CoordenadaOn.gameObject.SetActive(true);
                myportal.coordenadasCount++;
                player.coordenadaCount--;
            }
            else if(player.coordenadaCount == 2)
            {
                light1.intensity = 3.68f;
                CoordenadaOff.gameObject.SetActive(false);
                CoordenadaOn.gameObject.SetActive(true);
                myportal.coordenadasCount++;
                player.coordenadaCount--;
            }
      /*  light1.intensity = 3.68f;
          CoordenadaOff.gameObject.SetActive(false);
          CoordenadaOn.gameObject.SetActive(true);
          myportal.coordenadasCount ++;*/
        }
    }
}
