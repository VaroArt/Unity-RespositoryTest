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
      //  enemy.sensor.iniciateRaycast = true;

        enemy.sensor.CurrentTarget = collision.transform;
        print(collision);
        // print(collision);

        /*   if (enemy.sensor.recognitionTime == 4)
           {
               print("player visible");
           }*/

        /*  enemy.sensor.bengalaTr = collision.transform;
          enemy.sensor.CurrentTarget = enemy.sensor.bengalaTr;*/


    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        enemy.sensor.Recognition = false;
        enemy.sensor.iniciateRaycast = false;
        enemy.sensor.CurrentTarget = null;
    }
}
