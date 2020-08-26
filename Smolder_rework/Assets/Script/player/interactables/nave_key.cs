using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nave_key : MonoBehaviour
{
    public GameObject coordenada;
    public GameObject key;
    public player_triggers player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == ("Player"))
        {
            if(player.currentObject == ("llave"))
            { 
                key.gameObject.SetActive(false);
            }
        }
    }
}
