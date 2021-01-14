using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pulse_radar : MonoBehaviour
{
    [SerializeField] private Transform radarping;
  //  [SerializeField] private Transform radarping2;
    public Transform pulsetr;
    public float range;
    public float rangeMax;
    public float rangespeed;
    public bool activate;
    public Sprite[] spriteTutorial;
    public Sprite[] sprites;
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
            

                if(collision.name ==("colision tutorial 1"))
                { 
                    ping_radar radar = radarpingtr.GetComponent<ping_radar>();
                    radar.spriterd.sprite = spriteTutorial[0];
                    radar.setColor(new Color(1, 1, 0));
                }

                #region Colisiones anillo de asteroides
                if (collision.name == ("colision 1"))
                {
                    ping_radar radar = radarpingtr.GetComponent<ping_radar>();
                    radar.spriterd.sprite = sprites[0];
                    radar.setColor(new Color(1, 1, 0));

                }
                if (collision.name == ("colision 2"))
                {
                    ping_radar radar = radarpingtr.GetComponent<ping_radar>();
                    radar.spriterd.sprite = sprites[1];
                    radar.setColor(new Color(1, 1, 0));

                }
                if (collision.name == ("colision 3"))
                {
                    ping_radar radar = radarpingtr.GetComponent<ping_radar>();
                    radar.spriterd.sprite = sprites[2];
                    radar.setColor(new Color(1, 1, 0));

                }
                if (collision.name == ("colision 4"))
                {
                    ping_radar radar = radarpingtr.GetComponent<ping_radar>();
                    radar.spriterd.sprite = sprites[3];
                    radar.setColor(new Color(1, 1, 0));

                }
                if (collision.name == ("colision 5"))
                {
                    ping_radar radar = radarpingtr.GetComponent<ping_radar>();
                    radar.spriterd.sprite = sprites[4];
                    radar.setColor(new Color(1, 1, 0));

                }
                if (collision.name == ("colision 6"))
                {
                    ping_radar radar = radarpingtr.GetComponent<ping_radar>();
                    radar.spriterd.sprite = sprites[5];
                    radar.setColor(new Color(1, 1, 0));

                }
                if (collision.name == ("colision 7"))
                {
                    ping_radar radar = radarpingtr.GetComponent<ping_radar>();
                    radar.spriterd.sprite = sprites[6];
                    radar.setColor(new Color(1, 1, 0));

                }
                if (collision.name == ("colision 8"))
                {
                    ping_radar radar = radarpingtr.GetComponent<ping_radar>();
                    radar.spriterd.sprite = sprites[7];
                    radar.setColor(new Color(1, 1, 0));

                }
                if (collision.name == ("colision 9"))
                {
                    ping_radar radar = radarpingtr.GetComponent<ping_radar>();
                    radar.spriterd.sprite = sprites[8];
                    radar.setColor(new Color(1, 1, 0));

                }
                if (collision.name == ("colision 10"))
                {
                    ping_radar radar = radarpingtr.GetComponent<ping_radar>();
                    radar.spriterd.sprite = sprites[9];
                    radar.setColor(new Color(1, 1, 0));

                }
                if (collision.name == ("colision 11"))
                {
                    ping_radar radar = radarpingtr.GetComponent<ping_radar>();
                    radar.spriterd.sprite = sprites[10];
                    radar.setColor(new Color(1, 1, 0));

                }
                if (collision.name == ("colision 12"))
                {
                    ping_radar radar = radarpingtr.GetComponent<ping_radar>();
                    radar.spriterd.sprite = sprites[11];
                    radar.setColor(new Color(1, 1, 0));

                }
                if (collision.name == ("colision 13"))
                {
                    ping_radar radar = radarpingtr.GetComponent<ping_radar>();
                    radar.spriterd.sprite = sprites[12];
                    radar.setColor(new Color(1, 1, 0));

                }
                if (collision.name == ("colision 14"))
                {
                    ping_radar radar = radarpingtr.GetComponent<ping_radar>();
                    radar.spriterd.sprite = sprites[13];
                    radar.setColor(new Color(1, 1, 0));

                }
                if (collision.name == ("colision 15"))
                {
                    ping_radar radar = radarpingtr.GetComponent<ping_radar>();
                    radar.spriterd.sprite = sprites[14];
                    radar.setColor(new Color(1, 1, 0));

                }
                if (collision.name == ("colision 16"))
                {
                    ping_radar radar = radarpingtr.GetComponent<ping_radar>();
                    radar.spriterd.sprite = sprites[15];
                    radar.setColor(new Color(1, 1, 0));

                }
                if (collision.name == ("colision 17"))
                {
                    ping_radar radar = radarpingtr.GetComponent<ping_radar>();
                    radar.spriterd.sprite = sprites[16];
                    radar.setColor(new Color(1, 1, 0));

                }

                #endregion

                if (collision.name == ("meteoro minimap"))
                {
                    ping_radar radar2 = radarpingtr.GetComponent<ping_radar>();
                    radar2.setColor(new Color(1, 1, 0));
                    //
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
                if (collision.name == ("portal minimap"))
                {
                    ping_radar radar2 = radarpingtr.GetComponent<ping_radar>();
                    radar2.setColor(new Color(0.5f, 0.5f, 0.5f));
                    //
                }
                if (collision.name == ("receptor minimap"))
                {
                    ping_radar radar2 = radarpingtr.GetComponent<ping_radar>();
                    radar2.setColor(new Color(0, 1, 1));
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
