using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pulse_radar : MonoBehaviour
{
    [SerializeField] private Transform radarping;
    [SerializeField] private Transform radarping2;
    public Transform pulsetr;
    public float range;
    public float rangeMax;
    public float rangespeed;
    public bool activate;
    [Tooltip("Sprites de anillos de asteroides tutorial")]
    public Sprite[] spriteTutorial;
    [Tooltip("Sprites de anillos de asteroides escena 1")]
    public Sprite[] sprites;
    [Tooltip("Sprites de anillos de asteroides escena final")]
    public Sprite[] spritesFinal;
    [Tooltip("Sprites de todas las colisiones que detecte el ping radar")]
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
        if(collision.tag == ("minimap") && activate)
        {
            col.Add(collision);
            // print(collision.name);
            foreach (Collider2D colision in col)
            {
                //  Transform radarpingtr =   Instantiate(radarping, collision.gameObject.transform.position, collision.transform.rotation);   
                #region Colisiones anillos tutorial
                if (collision.name ==("colision tutorial 1"))
                {
                    Transform radarpingtr2 = Instantiate(radarping2, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr2.GetComponent<ping_radar>();
                    radar2.spriterd.sprite = spriteTutorial[0];
                    radar2.setColor(new Color(1, 1, 0)); //amarillo
                }
                if (collision.name == ("colision tutorial 2"))
                {
                    Transform radarpingtr2 = Instantiate(radarping2, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr2.GetComponent<ping_radar>();
                    radar2.spriterd.sprite = spriteTutorial[2];
                    radar2.setColor(new Color(1, 1, 0)); //amarillo
                }
                if (collision.name == ("colision tutorial 3"))
                {
                    Transform radarpingtr2 = Instantiate(radarping2, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr2.GetComponent<ping_radar>();
                    radar2.spriterd.sprite = spriteTutorial[3];
                    radar2.setColor(new Color(1, 1, 0)); //amarillo
                }
                if (collision.name == ("colision tutorial 4"))
                {
                    Transform radarpingtr2 = Instantiate(radarping2, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr2.GetComponent<ping_radar>();
                    radar2.spriterd.sprite = spriteTutorial[1];
                    radar2.setColor(new Color(1, 1, 0)); //amarillo
                }
                #endregion

                #region Colisiones anillo nivel 1
                if (collision.name == ("colision 1"))
                {
                    Transform radarpingtr2 = Instantiate(radarping2, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr2.GetComponent<ping_radar>();
                    radar2.spriterd.sprite = sprites[0];
                    radar2.setColor(new Color(1, 1, 0));

                }
                if (collision.name == ("colision 2"))
                {
                    Transform radarpingtr2 = Instantiate(radarping2, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr2.GetComponent<ping_radar>();
                    radar2.spriterd.sprite = sprites[1];
                    radar2.setColor(new Color(1, 1, 0));

                }
                if (collision.name == ("colision 3"))
                {
                    Transform radarpingtr2 = Instantiate(radarping2, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr2.GetComponent<ping_radar>();
                    radar2.spriterd.sprite = sprites[2];
                    radar2.setColor(new Color(1, 1, 0));

                }
                if (collision.name == ("colision 4"))
                {
                    Transform radarpingtr2 = Instantiate(radarping2, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr2.GetComponent<ping_radar>();
                    radar2.spriterd.sprite = sprites[3];
                    radar2.setColor(new Color(1, 1, 0));

                }
                if (collision.name == ("colision 5"))
                {
                    Transform radarpingtr2 = Instantiate(radarping2, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr2.GetComponent<ping_radar>();
                    radar2.spriterd.sprite = sprites[4];
                    radar2.setColor(new Color(1, 1, 0));

                }
                if (collision.name == ("colision 6"))
                {
                    Transform radarpingtr2 = Instantiate(radarping2, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr2.GetComponent<ping_radar>();
                    radar2.spriterd.sprite = sprites[5];
                    radar2.setColor(new Color(1, 1, 0));

                }
                if (collision.name == ("colision 7"))
                {
                    Transform radarpingtr2 = Instantiate(radarping2, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr2.GetComponent<ping_radar>();
                    radar2.spriterd.sprite = sprites[6];
                    radar2.setColor(new Color(1, 1, 0));

                }
                if (collision.name == ("colision 8"))
                {
                    Transform radarpingtr2 = Instantiate(radarping2, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr2.GetComponent<ping_radar>();
                    radar2.spriterd.sprite = sprites[7];
                    radar2.setColor(new Color(1, 1, 0));

                }
                if (collision.name == ("colision 9"))
                {
                    Transform radarpingtr2 = Instantiate(radarping2, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr2.GetComponent<ping_radar>();
                    radar2.spriterd.sprite = sprites[8];
                    radar2.setColor(new Color(1, 1, 0));

                }
                if (collision.name == ("colision 10"))
                {
                    Transform radarpingtr2 = Instantiate(radarping2, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr2.GetComponent<ping_radar>();
                    radar2.spriterd.sprite = sprites[9];
                    radar2.setColor(new Color(1, 1, 0));

                }
                if (collision.name == ("colision 11"))
                {
                    Transform radarpingtr2 = Instantiate(radarping2, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr2.GetComponent<ping_radar>();
                    radar2.spriterd.sprite = sprites[10];
                    radar2.setColor(new Color(1, 1, 0));

                }
                if (collision.name == ("colision 12"))
                {
                    Transform radarpingtr2 = Instantiate(radarping2, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr2.GetComponent<ping_radar>();
                    radar2.spriterd.sprite = sprites[11];
                    radar2.setColor(new Color(1, 1, 0));

                }
                if (collision.name == ("colision 13"))
                {
                    Transform radarpingtr2 = Instantiate(radarping2, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr2.GetComponent<ping_radar>();
                    radar2.spriterd.sprite = sprites[12];
                    radar2.setColor(new Color(1, 1, 0));

                }
                if (collision.name == ("colision 14"))
                {
                    Transform radarpingtr2 = Instantiate(radarping2, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr2.GetComponent<ping_radar>();
                    radar2.spriterd.sprite = sprites[13];
                    radar2.setColor(new Color(1, 1, 0));

                }
                if (collision.name == ("colision 15"))
                {
                    Transform radarpingtr2 = Instantiate(radarping2, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr2.GetComponent<ping_radar>();
                    radar2.spriterd.sprite = sprites[14];
                    radar2.setColor(new Color(1, 1, 0));

                }
                if (collision.name == ("colision 16"))
                {
                    Transform radarpingtr2 = Instantiate(radarping2, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr2.GetComponent<ping_radar>();
                    radar2.spriterd.sprite = sprites[15];
                    radar2.setColor(new Color(1, 1, 0));

                }
                if (collision.name == ("colision 17"))
                {
                    Transform radarpingtr2 = Instantiate(radarping2, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr2.GetComponent<ping_radar>();
                    radar2.spriterd.sprite = sprites[16];
                    radar2.setColor(new Color(1, 1, 0));

                }
                if (collision.name == ("colision 18"))
                {
                    Transform radarpingtr2 = Instantiate(radarping2, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr2.GetComponent<ping_radar>();
                    radar2.spriterd.sprite = sprites[17];
                    radar2.setColor(new Color(1, 1, 0));

                }
                if (collision.name == ("colision 19"))
                {
                    Transform radarpingtr2 = Instantiate(radarping2, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr2.GetComponent<ping_radar>();
                    radar2.spriterd.sprite = sprites[18];
                    radar2.setColor(new Color(1, 1, 0));

                }
                if (collision.name == ("colision 20"))
                {
                    Transform radarpingtr2 = Instantiate(radarping2, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr2.GetComponent<ping_radar>();
                    radar2.spriterd.sprite = sprites[19];
                    radar2.setColor(new Color(1, 1, 0));

                }
                if (collision.name == ("colision 21"))
                {
                    Transform radarpingtr2 = Instantiate(radarping2, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr2.GetComponent<ping_radar>();
                    radar2.spriterd.sprite = sprites[20];
                    radar2.setColor(new Color(1, 1, 0));

                }
                if (collision.name == ("colision 22"))
                {
                    Transform radarpingtr2 = Instantiate(radarping2, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr2.GetComponent<ping_radar>();
                    radar2.spriterd.sprite = sprites[21];
                    radar2.setColor(new Color(1, 1, 0));

                }
                if (collision.name == ("colision 23"))
                {
                    Transform radarpingtr2 = Instantiate(radarping2, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr2.GetComponent<ping_radar>();
                    radar2.spriterd.sprite = sprites[22];
                    radar2.setColor(new Color(1, 1, 0));

                }
                if (collision.name == ("colision 24"))
                {
                    Transform radarpingtr2 = Instantiate(radarping2, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr2.GetComponent<ping_radar>();
                    radar2.spriterd.sprite = sprites[23];
                    radar2.setColor(new Color(1, 1, 0));

                }
                if (collision.name == ("colision 25"))
                {
                    Transform radarpingtr2 = Instantiate(radarping2, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr2.GetComponent<ping_radar>();
                    radar2.spriterd.sprite = sprites[24];
                    radar2.setColor(new Color(1, 1, 0));

                }
                if (collision.name == ("colision 26"))
                {
                    Transform radarpingtr2 = Instantiate(radarping2, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr2.GetComponent<ping_radar>();
                    radar2.spriterd.sprite = sprites[25];
                    radar2.setColor(new Color(1, 1, 0));

                }
                if (collision.name == ("colision 27"))
                {
                    Transform radarpingtr2 = Instantiate(radarping2, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr2.GetComponent<ping_radar>();
                    radar2.spriterd.sprite = sprites[26];
                    radar2.setColor(new Color(1, 1, 0));

                }
                if (collision.name == ("colision 28"))
                {
                    Transform radarpingtr1 = Instantiate(radarping, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar1 = radarpingtr1.GetComponent<ping_radar>();
                    radar1.spriterd.sprite = sprites[27];
                    radar1.setColor(new Color(1, 1, 0));

                }
             /*   if (collision.name == ("colision 29"))
                {
                    Transform radarpingtr2 = Instantiate(radarping2, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr2.GetComponent<ping_radar>();
                    radar2.spriterd.sprite = sprites[28];
                    radar2.setColor(new Color(1, 1, 0));

                }*/

                #endregion

                #region Colisiones anillos nivel final
                if (collision.name == ("colision final 1"))
                {
                    Transform radarpingtr2 = Instantiate(radarping2, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr2.GetComponent<ping_radar>();
                    radar2.spriterd.sprite = spritesFinal[0];
                    radar2.setColor(new Color(1, 1, 0)); //yellow y wea
                }
                if (collision.name == ("colision final 2"))
                {
                    Transform radarpingtr2 = Instantiate(radarping2, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr2.GetComponent<ping_radar>();
                    radar2.spriterd.sprite = spritesFinal[1];
                    radar2.setColor(new Color(1, 1, 0)); //yellow y wea
                }
                if (collision.name == ("colision final 3"))
                {
                    Transform radarpingtr2 = Instantiate(radarping2, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr2.GetComponent<ping_radar>();
                    radar2.spriterd.sprite = spritesFinal[2];
                    radar2.setColor(new Color(1, 1, 0)); //yellow y wea
                }
                if (collision.name == ("colision final 4"))
                {
                    Transform radarpingtr2 = Instantiate(radarping2, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr2.GetComponent<ping_radar>();
                    radar2.spriterd.sprite = spritesFinal[3];
                    radar2.setColor(new Color(1, 1, 0)); //yellow y wea
                }
                if (collision.name == ("colision final 5"))
                {
                    Transform radarpingtr2 = Instantiate(radarping2, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr2.GetComponent<ping_radar>();
                    radar2.spriterd.sprite = spritesFinal[4];
                    radar2.setColor(new Color(1, 1, 0)); //yellow y wea
                }
                if (collision.name == ("colision final 6"))
                {
                    Transform radarpingtr2 = Instantiate(radarping2, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr2.GetComponent<ping_radar>();
                    radar2.spriterd.sprite = spritesFinal[5];
                    radar2.setColor(new Color(1, 1, 0)); //yellow y wea
                }
                if (collision.name == ("colision final 7"))
                {
                    Transform radarpingtr2 = Instantiate(radarping2, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr2.GetComponent<ping_radar>();
                    radar2.spriterd.sprite = spritesFinal[6];
                    radar2.setColor(new Color(1, 1, 0)); //yellow y wea
                }
                if (collision.name == ("colision final 8"))
                {
                    Transform radarpingtr2 = Instantiate(radarping2, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr2.GetComponent<ping_radar>();
                    radar2.spriterd.sprite = spritesFinal[7];
                    radar2.setColor(new Color(1, 1, 0)); //yellow y wea
                }
                if (collision.name == ("colision final 9"))
                {
                    Transform radarpingtr2 = Instantiate(radarping2, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr2.GetComponent<ping_radar>();
                    radar2.spriterd.sprite = spritesFinal[8];
                    radar2.setColor(new Color(1, 1, 0)); //yellow y wea
                }
                if (collision.name == ("colision final 10"))
                {
                    Transform radarpingtr2 = Instantiate(radarping2, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr2.GetComponent<ping_radar>();
                    radar2.spriterd.sprite = spritesFinal[9];
                    radar2.setColor(new Color(1, 1, 0)); //yellow y wea
                }
                if (collision.name == ("colision final 11"))
                {
                    Transform radarpingtr2 = Instantiate(radarping2, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr2.GetComponent<ping_radar>();
                    radar2.spriterd.sprite = spritesFinal[10];
                    radar2.setColor(new Color(1, 1, 0)); //yellow y wea
                }
                if (collision.name == ("colision final 12"))
                {
                    Transform radarpingtr2 = Instantiate(radarping2, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr2.GetComponent<ping_radar>();
                    radar2.spriterd.sprite = spritesFinal[11];
                    radar2.setColor(new Color(1, 1, 0)); //yellow y wea
                }
                if (collision.name == ("colision final 13"))
                {
                    Transform radarpingtr2 = Instantiate(radarping2, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr2.GetComponent<ping_radar>();
                    radar2.spriterd.sprite = spritesFinal[12];
                    radar2.setColor(new Color(1, 1, 0)); //yellow y wea
                }
                if (collision.name == ("colision final 14"))
                {
                    Transform radarpingtr2 = Instantiate(radarping2, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr2.GetComponent<ping_radar>();
                    radar2.spriterd.sprite = spritesFinal[13];
                    radar2.setColor(new Color(1, 1, 0)); //yellow y wea
                }
                if (collision.name == ("colision final 15"))
                {
                    Transform radarpingtr2 = Instantiate(radarping2, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr2.GetComponent<ping_radar>();
                    radar2.spriterd.sprite = spritesFinal[14];
                    radar2.setColor(new Color(1, 1, 0)); //yellow y wea
                }
                if (collision.name == ("colision final 16"))
                {
                    Transform radarpingtr2 = Instantiate(radarping2, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr2.GetComponent<ping_radar>();
                    radar2.spriterd.sprite = spritesFinal[15];
                    radar2.setColor(new Color(1, 1, 0)); //yellow y wea
                }
                if (collision.name == ("colision final 17"))
                {
                    Transform radarpingtr2 = Instantiate(radarping2, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr2.GetComponent<ping_radar>();
                    radar2.spriterd.sprite = spritesFinal[16];
                    radar2.setColor(new Color(1, 1, 0)); //yellow y wea
                }
                if (collision.name == ("colision final 18"))
                {
                    Transform radarpingtr2 = Instantiate(radarping2, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr2.GetComponent<ping_radar>();
                    radar2.spriterd.sprite = spritesFinal[17];
                    radar2.setColor(new Color(1, 1, 0)); //yellow y wea
                }
                if (collision.name == ("colision final 19"))
                {
                    Transform radarpingtr2 = Instantiate(radarping2, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr2.GetComponent<ping_radar>();
                    radar2.spriterd.sprite = spritesFinal[18];
                    radar2.setColor(new Color(1, 1, 0)); //yellow y wea
                }
                #endregion
                if (collision.name == ("meteoro minimap"))
                {
                    Transform radarpingtr = Instantiate(radarping, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr.GetComponent<ping_radar>();
                    radar2.setColor(new Color(1, 1, 0)); //amarillo
                    //
                }
                if (collision.name == ("enemy minimap"))
                {
                    Transform radarpingtr = Instantiate(radarping, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr.GetComponent<ping_radar>();
                    radar2.setColor(new Color(1, 0, 0)); // rojo
                   //
                }
                if (collision.name == ("nave minimap"))
                {
                    Transform radarpingtr = Instantiate(radarping, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr.GetComponent<ping_radar>();
                    radar2.setColor(new Color(0, 1, 0)); //verde
                    //
                }
                if (collision.name == ("portal minimap"))
                {
                    Transform radarpingtr = Instantiate(radarping, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr.GetComponent<ping_radar>();
                    radar2.setColor(new Color(0.5f, 0.5f, 0.5f)); //gris
                    //
                }
                if (collision.name == ("receptor minimap"))
                {
                    Transform radarpingtr = Instantiate(radarping, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr.GetComponent<ping_radar>();
                    radar2.setColor(new Color(0, 1, 1));  //cyan
                    //
                }
                if(collision.name == ("satelite minimap"))
                {
                    Transform radarpingtr = Instantiate(radarping, collision.gameObject.transform.position, collision.transform.rotation);
                    ping_radar radar2 = radarpingtr.GetComponent<ping_radar>();
                    radar2.setColor(new Color(0, 1, 0)); //
                }
            }
           
        }
    
    }
   
    public void pulse()
    {
        activate = true;
    }
}
