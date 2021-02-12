using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player_interactions : MonoBehaviour
{
    [Header("Scripts")]
    public player_script player;
    public limite_mapa alerta;
    [Header("Desactivables")]
    public Light2D playerlight;
    public TrailRenderer trail1, trail2;
    public float timer;
    [Header("Audios player")]
    public AudioClip movimiento;
    public AudioClip dead;
    private AudioSource audioNave;

    void Start()
    {
        audioNave = GetComponent<AudioSource>();
        audioNave.volume = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

        if (player.isMoving)
        {
            audioNave.volume = 0.13f;
        }
        if (player.isMoving == false && player.vida >0 && player.repbool == false)
        {
            audioNave.clip = movimiento;
            audioNave.Play();
        }
        if (player.vida < 1)
        {
            print("no life");
            timer -= 1 * Time.deltaTime;

            if (timer <= 2)
            {
               alerta.Invoke("reinicio", 1f);
            }
            if(timer <= 1)
            {
               
                print("dead");
            }
            if (timer <= 0)
            {
                player.gameObject.SetActive(false);
            }
        }

    }
    public void deadSound()
    {
        player.vida = 0;
        audioNave.clip = dead;
        audioNave.Play();
        trail1.gameObject.SetActive(false);
        trail2.gameObject.SetActive(false);
        playerlight.gameObject.SetActive(false);
    }
}
