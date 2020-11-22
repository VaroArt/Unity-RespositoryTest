using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bengalaItem : MonoBehaviour
{
    public player_script player;
    
    void Start()
    {
        
    }

 
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("Player"))
        {
            
        }
    }
}
