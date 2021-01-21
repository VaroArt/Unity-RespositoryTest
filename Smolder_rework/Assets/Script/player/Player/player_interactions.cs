using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;

public class player_interactions : MonoBehaviour
{
    public player_script player;
    public AudioClip movimiento;
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
        if (player.isMoving == false)
        {
            
            audioNave.clip = movimiento;
            audioNave.Play();
        }

    }
}
