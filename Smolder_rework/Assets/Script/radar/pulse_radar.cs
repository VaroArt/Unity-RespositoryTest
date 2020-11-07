using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pulse_radar : MonoBehaviour
{
    [SerializeField] private Transform radarping;
    public Transform pulsetr;
    public float range;
    public float rangeMax;
    public float rangespeed;
    public bool activate;
    [SerializeField] private List<Collider2D> col;

    private void Awake()
    {
        col = new List<Collider2D>();
    }

    private void Update()
    {
        if (activate)
        {
          range += rangespeed * Time.deltaTime;
        }
     
        if (range > rangeMax)
        {
            activate = false;
            range = 0f;
            col.Clear();  
        }
        pulsetr.localScale = new Vector3(range, range);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == ("minimap"))
        {
            col.Add(collision);
            // print(collision.name);
            foreach (Collider2D colision in col)
            {
             Transform radarpingtr =   Instantiate(radarping, collision.gameObject.transform.position, collision.transform.rotation);
             if (collision.name == ("meteoro minimap"))
             {
                    ping_radar radar = radarpingtr.GetComponent<ping_radar>();
                    radar.setColor(new Color(1, 1, 0));

             }
             if (collision.name == ("enemy minimap"))
             {
                    ping_radar radar2 = radarpingtr.GetComponent<ping_radar>();
                    radar2.setColor(new Color(1, 0, 0));
                   //
             }
                if (collision.name == ("nave minimap"))
                {
                    ping_radar radar2 = radarpingtr.GetComponent<ping_radar>();
                    radar2.setColor(new Color(0, 1, 0));
                    //
                }

            }
           
        }
    
    }
   
    public void pulse()
    {
        activate = true;
    }
}
