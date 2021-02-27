using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class receptor_coordenadas : MonoBehaviour
{
    [Header("ID")]
    public int Used;
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

            if(inventario.coordenadaCount == 1 && Used !=1)
            {
                light.intensity = 1.74f;
                myportal.coordenadasCount++;
                inventario.coordenadaCount--;
                receptor.SetBool("On", true);
                Used = 1;
            }
            else if (inventario.coordenadaCount == 2 && Used != 1)
            {
                light.intensity = 1.74f;
                myportal.coordenadasCount++;
                inventario.coordenadaCount--;
                receptor.SetBool("On", true);
                Used = 1;
            }
           
        }
    }
}
