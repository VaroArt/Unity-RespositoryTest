using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nave_explosivo : MonoBehaviour
{
    public GameObject coordenada;
    public player_triggers player;
    public GameObject explosivo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag ==("Player"))
        {
            if (player.currentObject == ("bomba"))
            {
                coordenada.gameObject.SetActive(true);
                explosivo.gameObject.SetActive(false);

            }
        }
    }
}
