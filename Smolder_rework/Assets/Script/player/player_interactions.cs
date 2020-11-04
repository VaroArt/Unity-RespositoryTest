using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_interactions : MonoBehaviour
{
    public float taskLevel;
    public float noisyLevel;
    public GameObject enemy;
    private AudioSource myaudio;
    public  AudioSource cAudio;
    public AudioClip test;

    void Start()
    {
        myaudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    public void visibleEnemy()
    {
        enemy.SetActive(true);

    }
    public void invisibleEnemy()
    {
        enemy.SetActive(false);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("Interaction"))
        {
            visibleEnemy();
            myaudio.clip = test;
            myaudio.Play();
            cAudio.Stop();
        }
        if (collision.tag == ("Interaction2"))
        {
            invisibleEnemy();
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == ("Interaction"))
        {
            myaudio.Stop();
            cAudio.Play();
        }
    }
}
