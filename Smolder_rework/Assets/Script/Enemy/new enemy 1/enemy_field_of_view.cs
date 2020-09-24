using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_field_of_view : MonoBehaviour
{
    public Enemy_1_IA enemy;
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
            enemy.sensor.iniciateRaycast = true;
           
        }
       
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == ("Player"))
        {
            enemy.sensor.Recognition = false;
            enemy.sensor.iniciateRaycast = false;
        }
    }
}
