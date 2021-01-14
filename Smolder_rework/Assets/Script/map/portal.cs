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
    public GameObject lightportal;
    public CapsuleCollider2D mycapsule;
    public int portalID;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(coordenadasCount == 2)
        {
            mycapsule.isTrigger = true;
            portalabierto.gameObject.SetActive(true);
            portalcerrado.gameObject.SetActive(false);
            luceslaterales.gameObject.SetActive(true);
            lightportal.gameObject.SetActive(true);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == ("Player")&& portalID == 2)
        {
            if (coordenadasCount == 2)
            {
                print("endgame");
                SceneManager.LoadScene("UI_Credits");
            }
        }
        if (collision.tag == ("Player") && portalID == 1)
        {
            if (coordenadasCount == 2)
            {
                print("start game");
                SceneManager.LoadScene("Testeo pipe");
            }
        }

    }
}
