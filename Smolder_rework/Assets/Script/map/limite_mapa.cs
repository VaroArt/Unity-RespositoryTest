using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class limite_mapa : MonoBehaviour
{
    public SpriteRenderer mysprite;
    public float value;
    public float timetoDie;
    public bool repeatTime;
    public bool startOpaccity;
    public GameObject player;
    public float radius;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mysprite.color = new Color(1f, 0f, 0f, value);
        if (startOpaccity)
        {
            timetoDie += 1f * Time.deltaTime;
            turnOpaccity();
            if(value > 0.3f)
            {
                startOpaccity = false;
                repeatTime = true;
            }
            if(timetoDie > 3)
            {
                print("Die");
                SceneManager.LoadScene("Main Menu");
                //player.SetActive(false);
            }
        }
        if (repeatTime)
        {
            turnOpaccityOff();
            {
                if(value < 0)
                {
                    startOpaccity = true;
                    repeatTime = false;
                }
            }
        }
       /* float MoveDistance = Vector3.Distance(player.transform.position, transform.position);
        if (MoveDistance > radius)
        {
            
        }
        if(MoveDistance < radius)
        {
           
        }
   */
       
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("Player"))
        {
            startOpaccity = false;
            repeatTime = false;
            value = 0;
            timetoDie = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == ("Player"))
        {
            print("funcionaa!");
            startOpaccity = true;

        }
    }
    void turnOpaccity()
    {
        value += 0.8f * Time.deltaTime;
    }
    void turnOpaccityOff()
    {  
        value -= 0.8f * Time.deltaTime;
    }
}
