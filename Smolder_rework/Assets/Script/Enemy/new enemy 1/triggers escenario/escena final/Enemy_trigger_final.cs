using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_trigger_final : MonoBehaviour
{
    public int id;
    public enemy_manager manager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("Player")) // el resto de enemigos aparecera al pasar por los trigger
        {
            if(id == 1)
            {
                manager.enemyBehaviors[2].EnemeyReady();
            }
            if (id == 2)
            {
                manager.enemyBehaviors[3].EnemeyReady();
            }
            if (id == 3)
            {
                manager.enemyBehaviors[4].EnemeyReady();
            }
        }
    }
}
