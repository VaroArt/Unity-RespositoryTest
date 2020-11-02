using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_fov_secondary : MonoBehaviour
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
       

        if (collision.tag == ("Bengala"))
        {
            enemy.sensor.sensorTarget = collision.transform;
            enemy.sensor.RecognitionSecondary = true;
          //enemy.sensor.RecognitionGeneral = true;
        }

        else if (collision.tag == ("Player"))
        {
          //enemy.sensor.RecognitionGeneral = true;
            enemy.sensor.sensorTarget = collision.transform;
            enemy.sensor.RecognitionSecondary = true;
        }

    }
    public void OnTriggerExit2D(Collider2D collision)
    {   
        //enemy.sensor.RecognitionGeneral = false;
          enemy.sensor.RecognitionSecondary = false;
          enemy.sensor.sensorTarget = null;
    }
}
