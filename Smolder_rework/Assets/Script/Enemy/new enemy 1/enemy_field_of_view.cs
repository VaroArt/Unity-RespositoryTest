using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_field_of_view : MonoBehaviour
{
    public Enemy_1_IA enemy;
    public int typeofview;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == ("Player")&& typeofview == 1)
        {
            enemy.targets.Recognition = true;
            print("vista general");
        }
        if (collision.tag == ("Player") && typeofview == 2)
        {
            //   enemy.moveMode = 2;
            print("vista expecifica");
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == ("Player") && typeofview == 1)
        {
            enemy.targets.Recognition = false;
        }
    }
}
