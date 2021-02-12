using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1_Attack_Anim : MonoBehaviour
{
    public Animator anim;
    public player_script player;
    public player_interactions gameController;
    public camera_shake shake;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttackTrigger()
    {
        anim.SetBool("attack", false);
       // print("vida player =" + player.vida);
    }
    public void shakeTime()
    {
        shake.shakeCamera(1f, 0.3f);
        player.vida--;
        if (player.vida == 0)
        {
            player.anim.SetBool("dead", true);
           // print("game over");
        }
    }
}
