using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadItem : MonoBehaviour
{
    public player_script player;
    public BengalSystem bengala;
    public string TypeObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("Player")&& TypeObject == ("Turbo"))
        {
            player.cantidadTurbo += 20f;
            this.gameObject.SetActive(false);
        }
        if (collision.tag == ("Player") && TypeObject == ("Bengala"))
        {
            bengala.CantBengalas++;
            this.gameObject.SetActive(false);
        }
    }
}
