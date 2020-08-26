using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public int ID;
    public float speed;
    public bool intBomb;
    public GameObject objectToFollow;
    public PanelControl panel;
    public player_triggers player;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (intBomb && panel.InteraccionActiva == 1)
        {
            player.buttonInteractAnim.SetBool("ChangeColor", false);
            player.buttonInteractAnim.SetBool("BacktoGrey", true);
            follow2();
            player.currentObject = ("bomba");
        }
    }
    public void follow2()
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
            if (panel.InteraccionActiva == 1)
            {
                intBomb = true;

            }
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == ("Player"))
        {
            player.buttonInteractAnim.SetBool("ChangeColor", false);
            player.buttonInteractAnim.SetBool("BacktoGrey", true);
            intBomb = false;
        }
    }
}
