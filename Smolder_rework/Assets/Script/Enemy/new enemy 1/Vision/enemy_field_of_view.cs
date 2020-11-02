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
        //enemy.sensor.sensorTarget = collision.transform;

        if (collision.tag == ("Bengala"))
        {
            enemy.sensor.sensorTarget = collision.transform;
            //enemy.sensor.Recognition = true;
            enemy.VerTarget();
        }

         else if (collision.tag == ("Player"))
         {
            enemy.sensor.sensorTarget = collision.transform;
          //  enemy.sensor.Recognition = true;
            enemy.VerTarget();
        }

    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        enemy.sensor.RecognitionGeneral = false;
        enemy.sensor.sensorTarget = null;
    }
}
