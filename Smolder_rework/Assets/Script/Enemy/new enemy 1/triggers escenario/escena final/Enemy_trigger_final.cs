using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_trigger_final : MonoBehaviour
{
    public Dialogue_Manager dialogeManager;
    public bool ready;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(dialogeManager.S_Dialogos.id == 5)
        {
            if(dialogeManager.Used == 1)
            {
                StartCoroutine("TimeToAction");
            }
        }
    }
    IEnumerator TimeToAction()
    {
        yield return new WaitForSeconds(3);
        print("ready");
        ready = true;
    }
}

