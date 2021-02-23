using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Active_trigger : MonoBehaviour
{
    public GameObject enemy;
    public Enemy_1_IA enemyscr;
    public Transform[] points1;
    public Transform[] points2;
    public GameObject[] enemiesTrigger1;
    public GameObject[] enemiesTrigger2;
   [HideInInspector] public int RandomN1;
   [HideInInspector] public int RandomN2;
    int finalNum1;
    int finalNum2;
    public int ID;
    int GetRandom1(int min, int max)
    {
        RandomN1 = Random.Range(min, max);
        while (RandomN1 == finalNum1)
            RandomN1 = Random.Range(min, max);
        finalNum1 = RandomN1;
        return RandomN1;
    }
    int GetRandom2(int min, int max)
    {
        RandomN2 = Random.Range(min, max);
        while (RandomN2 == finalNum2)
            RandomN2 = Random.Range(min, max);
        finalNum2 = RandomN2;
        return RandomN2;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void RanPos()
    {
        GetRandom1(1, 5);

        switch (RandomN1)
        {
            case 1:
                 enemyscr.patrol.Points[0] = points1[0];
                 enemiesTrigger1[0].gameObject.SetActive(true);
                 print("ubicacion 1");
                break;

            case 2:
                enemyscr.patrol.Points[0] = points1[1];
                enemiesTrigger1[1].gameObject.SetActive(true);
                print("ubicacion 2");
                break;
            case 3:
                enemyscr.patrol.Points[0] = points1[2];
                enemiesTrigger1[2].gameObject.SetActive(true);
                print("ubicacion 3");
                break;
            case 4:
                enemyscr.patrol.Points[0] = points1[3];
                enemiesTrigger1[3].gameObject.SetActive(true);
                print("ubicacion 4");
                break;
        }
       
    }
    public void RanPos2()
    {
        GetRandom2(1, 5);

        switch (RandomN2)
        {
            case 1:
                enemyscr.patrol.Points[0] = points2[0];
                enemiesTrigger2[0].gameObject.SetActive(true);
                print("ubicacion 1");
                break;

            case 2:
                enemyscr.patrol.Points[0] = points2[1];
                enemiesTrigger2[1].gameObject.SetActive(true);
                print("ubicacion 1");
                break;
            case 3:
                enemyscr.patrol.Points[0] = points2[2];
                enemiesTrigger2[2].gameObject.SetActive(true);
                break;
            case 4:
                enemyscr.patrol.Points[0] = points2[3];
                enemiesTrigger2[3].gameObject.SetActive(true);
                break;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("Player"))
        {
  
            if(ID == 1)
            {
                RanPos();
            }
          if(ID == 2)
            {
                RanPos2();
            }
        }
    }
}
