using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy_trigger_final : MonoBehaviour
{
    public int id;
    public enemy_manager manager;
    public AudioSource audioFinal;
    public AudioClip portazo;
    public GameObject FadeIn;
    public GameObject Enemys;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("Player")) // el resto de enemigos aparecera al pasar por los trigger
        {
            if(id == 1)
            {
                manager.enemyBehaviors[2].EnemeyReady();
            }
            if (id == 2)
            {
                manager.enemyBehaviors[3].EnemeyReady();
            }
            if (id == 3)
            {
                manager.enemyBehaviors[4].EnemeyReady();
            }
            if(id == 4)
            {
                audioFinal.clip = portazo;
                audioFinal.Play();
                FadeIn.gameObject.SetActive(true);
                Enemys.gameObject.SetActive(false);
                Invoke("Endgame", 2f);
            }
        }

    }
    public void Endgame()
    {
        SceneManager.LoadScene("UI_Credits");
    }
}
