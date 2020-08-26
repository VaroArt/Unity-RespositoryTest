using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;
    public PanelControl panel;

    public Queue<string> sentences;
    public Queue<string> sentences2;
    public Queue<string> sentences3;
    void Start()
    {
        sentences = new Queue<string>();
        sentences2 = new Queue<string>();
        sentences3 = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    public void StartDialogue2(Dialogue dialogue2)
    {
        sentences.Clear();
        sentences2.Clear();
        foreach (string sentence2 in dialogue2.sentences2)
        {
            sentences2.Enqueue(sentence2);
           
        }
        DisplayNextSentence2();
    }
    public void StartDialogue3(Dialogue dialogue3)
    {
        sentences.Clear();
        sentences2.Clear();
        sentences3.Clear();
        foreach (string sentence3 in dialogue3.sentences3)
        {
            sentences3.Enqueue(sentence3);

        }
        DisplayNextSentence3();
    }
    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        //StopAllCoroutines();
       // StartCoroutine(TypeSentence(sentence));
       
    }
    public void DisplayNextSentence2()
    {
        if (sentences2.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence2 = sentences2.Dequeue();
        dialogueText.text = sentence2;
        //StopAllCoroutines();
        // StartCoroutine(TypeSentence(sentence));

    }
    public void DisplayNextSentence3()
    {
        if (sentences3.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence3 = sentences3.Dequeue();
        dialogueText.text = sentence3;
        //StopAllCoroutines();
        // StartCoroutine(TypeSentence(sentence));

    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
    public void EndDialogue()
    {
        print("end conversation");

    }


}
