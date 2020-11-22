using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turboItem : MonoBehaviour
{
    public player_script player;
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
            player.cantidadTurbo += 20f;
            this.gameObject.SetActive(false);
        }
    }
}
