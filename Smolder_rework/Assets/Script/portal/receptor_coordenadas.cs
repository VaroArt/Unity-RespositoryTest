using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class receptor_coordenadas : MonoBehaviour
{
    [Header("ID")]
    public int ID;
    [Header("Scripts")]
    public InventarioSystem inventario;
    public portal myportal;
    public Light2D light;
    [Header("Animators")]
    public Animator receptor;

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

            if(inventario.coordenadaCount == 1)
            {

                light.intensity = 1.74f;
              /*  CoordenadaOff.gameObject.SetActive(false);
               *  animator
                CoordenadaOn.gameObject.SetActive(true);*/
                myportal.coordenadasCount++;
                inventario.coordenadaCount--;
                receptor.SetBool("On", true);
            }
            else if (inventario.coordenadaCount == 2)
            {
                light.intensity = 1.74f;
              /*  CoordenadaOff.gameObject.SetActive(false);
                CoordenadaOn.gameObject.SetActive(true);*/
                myportal.coordenadasCount++;
                inventario.coordenadaCount--;
                receptor.SetBool("On", true);
            }
           
        }
    }
}
