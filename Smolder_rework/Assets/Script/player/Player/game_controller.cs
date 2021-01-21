using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game_controller : MonoBehaviour
{
    public player_script player;
    [Header("Reinicio")]
    public float timer;
    public AudioSource audioSource;
    public AudioClip dead;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.vida <= 0)
        {
            timer -= 1 * Time.deltaTime;
           
            if (timer <= 2)
            {
               player.gameObject.SetActive(false);
            }
        }
        if(timer == 3)
        {
        }
        if (timer <= 0)
        {
            SceneManager.LoadScene("UI_Menu");
        }
    }
    public void deadSound()
    {
        audioSource.clip = dead;
        audioSource.Play();
    }
}
