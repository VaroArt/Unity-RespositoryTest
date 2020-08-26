using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;

public class portal : MonoBehaviour
{
    public GameObject portalcerrado;
    public GameObject portalabierto;
    public GameObject luceslaterales;
    public int coordenadasCount;
    public Light2D lightportal;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(coordenadasCount == 3)
        {
            portalabierto.gameObject.SetActive(true);
            portalcerrado.gameObject.SetActive(false);
            luceslaterales.gameObject.SetActive(true);
            lightportal.intensity = 48.85f;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == ("Player"))
        {
            if (coordenadasCount == 3)
            {
                print("endgame");
                SceneManager.LoadScene("Final");
            }
        }
      
    }
}
