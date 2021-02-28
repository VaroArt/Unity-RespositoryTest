using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;

public class portal : MonoBehaviour
{

    public int coordenadasCount;
    public PolygonCollider2D mypolygon;
    public int portalID;
    public Animator portalAnim;
    public GameObject fadeIn;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(coordenadasCount == 2)
        {
            mypolygon.isTrigger = true;
            portalAnim.SetBool("On", true);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == ("Player")&& portalID == 2)
        {
            if (coordenadasCount == 2)
            {
                print("endgame");
                SceneManager.LoadScene("Final");
            }
        }
        if (collision.tag == ("Player") && portalID == 1)
        {
            if (coordenadasCount == 2)
            {
                print("start game");
                fadeIn.SetActive(true);
                Invoke("UsePortal", 1f);

            }
        }

    }
    public void UsePortal()
    {
        SceneManager.LoadScene("Testeo pipe"); // en el futuro, cambiar a escena de juego 1
    }
}
