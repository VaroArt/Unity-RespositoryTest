﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1_Attack_Anim : MonoBehaviour
{
    public Animator anim;
    public player_script player;
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
        print("false");
        player.vida--;
    }
}
