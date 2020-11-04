using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_interactions : MonoBehaviour
{
    public float taskLevel;
    public float noisyLevel;
    public GameObject enemy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    public void visibleEnemy()
    {
        enemy.SetActive(true);
    }
    public void invisibleEnemy()
    {
        enemy.SetActive(false);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("Interaction"))
        {
            visibleEnemy();
        }
        if (collision.tag == ("Interaction2"))
        {
            invisibleEnemy();
        }
    }
}
