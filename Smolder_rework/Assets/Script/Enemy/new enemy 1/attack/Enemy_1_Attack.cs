using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1_Attack : MonoBehaviour
{
    public Enemy_1_IA enemy_scr;
    public player_script player;
    public AudioSource audioAttack;
    public AudioClip attackClip;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag ==("Player") && Time.time > enemy_scr.attack.nextAttack) //Para que el ataque del enemigo se reprodusca con delay, con cooldown, y no fuera a cada rato el wate
        {
            enemy_scr.attack.nextAttack = Time.time + enemy_scr.attack.attackRate;
            enemy_scr.gfx.enemyAnim.SetBool("attack", true);
            audioAttack.clip = attackClip;
            audioAttack.Play();
        }  
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == ("Player") && Time.time > enemy_scr.attack.nextAttack) //En trigger enter inicia el proceso, y si te quedas en el rango de ataque, puede seguir atacandote, como cualquier enemigo basicamente
        {
            enemy_scr.attack.nextAttack = Time.time + enemy_scr.attack.attackRate;
            enemy_scr.gfx.enemyAnim.SetBool("attack", true);
            audioAttack.Play();

        }
    }
    public void OnTriggerExit2D(Collider2D collision) // Si uno se sale del rango, pues dejaria de atacar, de hecho se reiniciaria el proceso. Incluso si el enemigo estuviera apunto de volver a atacar
    {
        if (collision.tag == ("Player"))
        {
            enemy_scr.gfx.enemyAnim.SetBool("attack", false);
        }
    }
}
