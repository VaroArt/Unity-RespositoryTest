using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1_Attack_Anim : MonoBehaviour
{
    public Animator anim;
    public player_script player;
    public player_interactions gameController;
    public camera_shake shake;
    public AudioSource audioSource;
    public AudioClip hitClip;





    //Estos void son basicamente lo que ocurre durante la animacion del ataque, del script Enemy_1_Attack
    //Un void para parar la animacion, cuando termina justo
    //Otro void para el ataque concretado, en este caso, si logro hacer hit correctamente, la pantalla temblaria, y restaria vida al player
    //Si logra matarlo, pues el player reproduciria su propia animacion de muerte mas su apropiado proceso de muerte (sonido de muerte, delay pequeño y reinicio de la escena)
    public void AttackTrigger()
    {
        anim.SetBool("attack", false);
       // print("vida player =" + player.vida);
    }
    public void shakeTime()
    {
        print("atack");
        audioSource.clip = hitClip;
        audioSource.Play();
        shake.shakeCamera(1f, 0.3f);
        player.vida--;
        if (player.vida == 0)
        {
            player.anim.SetBool("dead", true);
           // print("game over");
        }
    }
}
