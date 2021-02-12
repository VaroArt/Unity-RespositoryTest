using System.Collections;
using System.Collections.Generic;
//using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;

public class limite_mapa : MonoBehaviour
{
    [Header("Sprite")]
    public SpriteRenderer mysprite;
    [Header("Variables")]
    public float value;
    public float timetoDie;
    public bool repeatTime;
    public bool startOpaccity;
    [Header("Animator")]
    public Animator playerAnim;
    [Header("Scripts")]
    public player_script player_scr;
    public player_interactions controller;

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
            if(timetoDie > 2)
            {
               // player_scr.vida = 0;         
                playerAnim.SetBool("dead", true);
            }
            if(timetoDie > 3)
            {
                print("Die");
                reinicio();
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
        if(collision.tag == ("Player")&& player_scr.vida !=0)
        {
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
    public void reinicio()
    {
        SceneManager.LoadScene("UI_Menu");
    }
}
