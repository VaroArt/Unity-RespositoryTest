using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public int ID;
    public float speed;
    public bool intKey;
    public bool canPress;
    public GameObject objectToFollow;
    public PanelControl panel;
    public player_triggers player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (intKey && panel.InteraccionActiva == 1)
        {
            follow();
            player.buttonInteractAnim.SetBool("ChangeColor", false);
            player.buttonInteractAnim.SetBool("BacktoGrey", true);
            player.currentObject = ("llave");
        }
    }
    public void follow()
    {
        float interpolation = this.speed * Time.deltaTime;
        Vector3 position = transform.position;
        position.y = Mathf.Lerp(this.transform.position.y, objectToFollow.transform.position.y, interpolation);
        position.x = Mathf.Lerp(this.transform.position.x, objectToFollow.transform.position.x, interpolation);
        this.transform.position = position;
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == ("Player"))
        {
            player.buttonInteractAnim.SetBool("ChangeColor", true);
            player.buttonInteractAnim.SetBool("BacktoGrey", false);
            // intKey = true;
            if (panel.InteraccionActiva == 1)
            {
                intKey = true;

            }
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == ("Player"))
        {
            player.buttonInteractAnim.SetBool("ChangeColor", false);
            player.buttonInteractAnim.SetBool("BacktoGrey", true);
            intKey = false;
        }
    }
}
