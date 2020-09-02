using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_triggers : MonoBehaviour
{
    public string currentObject;
    public bool isdialogue;
    public GameObject curretCoordenada;
    public PanelControl panel;
    public DialogueManager manager;
    public Key key;
    public Coordenada coord;
    public Bomb bomb;
    public nave_key naveKey;
    public nave_explosivo naveExplosivo;
    public nave_coordenada naveCoordenadas;
    public Dialogue dialogue;
    public Animator buttonDialogueAnim;
    public Animator buttonInteractAnim;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.gameObject.name == ("nave1" )&& currentObject == ("llave"))
        {
             buttonDialogueAnim.SetBool("greyAgain", false);
             buttonDialogueAnim.SetBool("isChanging", true);
        }
        if(collision.gameObject.name == ("nave4"))
        {
            buttonDialogueAnim.SetBool("greyAgain", false);
            buttonDialogueAnim.SetBool("isChanging", true);
        }
        if (collision.gameObject.name == ("nave5") && currentObject == ("bomba"))
        {
            buttonDialogueAnim.SetBool("greyAgain", false);
            buttonDialogueAnim.SetBool("isChanging", true);
        }
        if(collision.gameObject.tag == ("key"))
        {

        }
        if (collision.gameObject.tag == ("bomba"))
        {
            
        }
        if (collision.gameObject.tag == ("coordenada"))
        {
            coord = collision.GetComponent<Coordenada>();
            curretCoordenada = collision.gameObject;

        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.name == ("nave1") && currentObject == ("llave"))
        {
            panel.dialogue1 = true;
            isdialogue = true;
            if (panel.dialogueinteract1 == 1 )
            {
                buttonDialogueAnim.SetBool("greyAgain", false);
                buttonDialogueAnim.SetBool("isChanging", false);
                buttonDialogueAnim.SetBool("alwaysGreen", true);
                panel.isEdgarTalking = true;
                panel.areTalking = true;
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            }

           if(panel.dialogueinteract1 == 2 && currentObject == ("llave"))
            {
                panel.isAstroTalking = true;
                panel.isEdgarTalking = false;
            }

            if (panel.dialogueinteract1 == 3 && currentObject == ("llave"))
            {
                panel.isEdgarTalking = true;
                panel.isAstroTalking = false; 
            }
            if(panel.dialogueinteract1 == 4 && currentObject == ("llave"))
            {
                panel.isEdgarTalking = false;
                panel.isAstroTalking = true;
            }
            if(panel.dialogueinteract1 == 5 && currentObject == ("llave"))
            {
                panel.isEdgarTalking = true;
                panel.isAstroTalking = false;
            }
            if (panel.dialogueinteract1 == 6 && currentObject == ("llave"))
            {
                panel.isEdgarTalking = false;
                panel.isAstroTalking = true;
            }
            if (panel.dialogueinteract1 == 7 && currentObject == ("llave"))
            {
                buttonDialogueAnim.SetBool("isChanging", false);
                buttonDialogueAnim.SetBool("alwaysGreen", false);
                buttonDialogueAnim.SetBool("greyAgain", true);
                manager.DisplayNextSentence();
                panel.isAstroTalking = false;
                panel.isEdgarTalking = false;
                panel.areTalking = false;
               naveKey.coordenada.gameObject.SetActive(true);
            }

        }

        if(collision.gameObject.name == ("nave4"))
        {
            panel.dialogue2 = true;
            isdialogue = true;
            if (panel.dialogueinteract2 == 1)
            {
                buttonDialogueAnim.SetBool("greyAgain", false);
                buttonDialogueAnim.SetBool("isChanging", false);
                buttonDialogueAnim.SetBool("alwaysGreen", true);
                panel.isAstroTalking = true;
                panel.areTalking = true;
                FindObjectOfType<DialogueManager>().StartDialogue2(dialogue);
            }

            if(panel.dialogueinteract2 == 2)
            {
               
                panel.isAstroTalking = false;
                panel.isEdgarTalking = true;

            }
            if (panel.dialogueinteract2 == 3)
            {
             //   manager.DisplayNextSentence2();
                panel.isEdgarTalking = true;
               
            }
            if (panel.dialogueinteract2== 4)
            {

                panel.isEdgarTalking = false;
                panel.isAstroTalking = true;  
            }
            if (panel.dialogueinteract2 == 6)
            {
                manager.DisplayNextSentence2();
                buttonDialogueAnim.SetBool("isChanging", false);
                buttonDialogueAnim.SetBool("alwaysGreen", false);
                buttonDialogueAnim.SetBool("greyAgain", true);
                panel.isAstroTalking = false;
                panel.isEdgarTalking = false;
                panel.areTalking = false;
                naveCoordenadas.coordenada.gameObject.SetActive(true);
            }

        }
        if (collision.gameObject.name == ("nave5") && currentObject == ("bomba"))
        {
            panel.dialogue3 = true;
            isdialogue = true;
            if (panel.dialogueinteract3 == 1 && currentObject == ("bomba"))
            {
                panel.isAstroTalking = true;
                buttonDialogueAnim.SetBool("greyAgain", false);
                buttonDialogueAnim.SetBool("isChanging", false);
                buttonDialogueAnim.SetBool("alwaysGreen", true);
                panel.areTalking = true;
                FindObjectOfType<DialogueManager>().StartDialogue3(dialogue);
            }
            if (panel.dialogueinteract3 == 2 && currentObject == ("bomba"))
            {
                panel.isEdgarTalking = true;
                panel.isAstroTalking = false;
            }
            if (panel.dialogueinteract3 == 3 && currentObject == ("bomba"))
            {
                panel.isEdgarTalking = false;
                panel.isAstroTalking = true;
            }
            if (panel.dialogueinteract3 == 4 && currentObject == ("bomba"))
            {
                panel.isEdgarTalking = true;
                panel.isAstroTalking = false;
            }
            if (panel.dialogueinteract3 == 5 && currentObject == ("bomba"))
            {
                panel.isEdgarTalking = true;
                panel.isAstroTalking = false;
            }
            if (panel.dialogueinteract3 == 6 && currentObject == ("bomba"))
            {
                panel.isEdgarTalking = false;
                panel.isAstroTalking = true;
            }
            if (panel.dialogueinteract3 == 7 && currentObject == ("bomba"))
            {
                panel.isEdgarTalking = true;
                panel.isAstroTalking = false;
            }

            if (panel.dialogueinteract3 == 8 && currentObject == ("bomba"))
            {
                manager.DisplayNextSentence3();
                panel.isAstroTalking = false;
                panel.isEdgarTalking = false;
                buttonDialogueAnim.SetBool("isChanging", false);
                buttonDialogueAnim.SetBool("alwaysGreen", false);
                buttonDialogueAnim.SetBool("greyAgain", true);
                panel.areTalking = false;
            }
        }



        if (collision.gameObject.name == ("ObjectCoordenada1"))
        {
            curretCoordenada = collision.gameObject;
        }

        if (collision.gameObject.name == ("ObjectCoordenada2"))
        {
            curretCoordenada = collision.gameObject;
        }

        if (collision.gameObject.name == ("ObjectCoordenada3"))
        {
            curretCoordenada = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == ("firstAlert"))
        {
            print("firstAlert");
        }
        if (collision.gameObject.name == ("nave1"))
        {
            panel.dialogue1 = false;
            buttonDialogueAnim.SetBool("isChanging", false);
            buttonDialogueAnim.SetBool("alwaysGreen", false);
            buttonDialogueAnim.SetBool("greyAgain", true);
            panel.dialogueinteract1 = 0;
            isdialogue = false;
            panel.isAstroTalking = false;
            panel.isEdgarTalking = false;
            panel.areTalking = false;
            
        }
        if (collision.gameObject.name == ("nave4"))
        {
            buttonDialogueAnim.SetBool("isChanging", false);
            buttonDialogueAnim.SetBool("alwaysGreen", false);
            buttonDialogueAnim.SetBool("greyAgain", true);
            panel.dialogue2 = false;
            panel.dialogueinteract2 = 0;
            isdialogue = false;
            panel.isAstroTalking = false;
            panel.isEdgarTalking = false;
            panel.areTalking = false;

        }
        if (collision.gameObject.name == ("nave5"))
        {
            buttonDialogueAnim.SetBool("isChanging", false);
            buttonDialogueAnim.SetBool("alwaysGreen", false);
            buttonDialogueAnim.SetBool("greyAgain", true);
            panel.dialogue3 = false;
            panel.dialogueinteract3 = 0;
            isdialogue = false;
            panel.isAstroTalking = false;
            panel.isEdgarTalking = false;
            panel.areTalking = false;

        }
    }
}
