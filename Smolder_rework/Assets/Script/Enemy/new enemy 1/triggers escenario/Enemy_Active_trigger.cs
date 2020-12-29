using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Active_trigger : MonoBehaviour
{
    public GameObject enemy;
    public Enemy_1_IA enemyscr;
    public Transform point;
    public GameObject[] triggers;
    public GameObject[] enemies;
    public int triggerID;
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


            #region trigger activation
            if (triggerID == 1)
            {
                triggers[1].gameObject.SetActive(false);
                triggers[2].gameObject.SetActive(false);
                enemies[1].gameObject.SetActive(false);
                enemies[2].gameObject.SetActive(false);
            }
            if (triggerID == 2)
            {
                triggers[0].gameObject.SetActive(false);
                triggers[2].gameObject.SetActive(false);
                enemies[0].gameObject.SetActive(false);
                enemies[2].gameObject.SetActive(false);
            }
            if (triggerID == 3)
            {
                triggers[0].gameObject.SetActive(false);
                triggers[1].gameObject.SetActive(false);
                enemies[0].gameObject.SetActive(false);
                enemies[1].gameObject.SetActive(false);
            }
            if (triggerID == 4)
            {
                triggers[4].gameObject.SetActive(false);
                triggers[5].gameObject.SetActive(false);
                triggers[6].gameObject.SetActive(false);
                enemies[4].gameObject.SetActive(false);
                enemies[5].gameObject.SetActive(false);
                enemies[6].gameObject.SetActive(false);

            }
            if (triggerID == 5)
            {
                triggers[3].gameObject.SetActive(false);
                triggers[5].gameObject.SetActive(false);
                triggers[6].gameObject.SetActive(false);
                enemies[3].gameObject.SetActive(false);
                enemies[5].gameObject.SetActive(false);
                enemies[6].gameObject.SetActive(false);
            }
            if (triggerID == 6)
            {
                triggers[3].gameObject.SetActive(false);
                triggers[4].gameObject.SetActive(false);
                triggers[6].gameObject.SetActive(false);
                enemies[3].gameObject.SetActive(false);
                enemies[4].gameObject.SetActive(false);
                enemies[6].gameObject.SetActive(false);
            }
            if (triggerID == 7)
            {
                triggers[5].gameObject.SetActive(false);
                triggers[4].gameObject.SetActive(false);
                triggers[3].gameObject.SetActive(false);
                enemies[5].gameObject.SetActive(false);
                enemies[4].gameObject.SetActive(false);
                enemies[3].gameObject.SetActive(false);
            }
            #endregion
        }
    }
}
