using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1_Attack : MonoBehaviour
{
    public Enemy_1_IA enemy_scr;
    public player_script player;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag ==("Player") && Time.time > enemy_scr.attack.nextAttack)
        {
            enemy_scr.attack.nextAttack = Time.time + enemy_scr.attack.attackRate;
            enemy_scr.gfx.enemyAnim.SetBool("attack", true);
            print("attack");
            player.vida--;
        }
      
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == ("Player") && Time.time > enemy_scr.attack.nextAttack)
        {
            enemy_scr.attack.nextAttack = Time.time + enemy_scr.attack.attackRate;
            enemy_scr.gfx.enemyAnim.SetBool("attack", true);
            print("attack");
            player.vida--;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == ("Player"))
        {
            enemy_scr.gfx.enemyAnim.SetBool("attack", false);
        }
    }
    public void AttackTrigger()
    {
        enemy_scr.gfx.enemyAnim.SetBool("attack", false);
        print("false");
    }
}
