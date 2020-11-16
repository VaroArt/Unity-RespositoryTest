using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Active_trigger : MonoBehaviour
{
    public GameObject enemy;
    public Enemy_1_IA enemyscr;
    public Transform point;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("Player"))
        {
            enemy.SetActive(true);
            enemyscr.patrol.Points[0] = point;
        }
    }
}
