using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_manager : MonoBehaviour
{
    public Dialogue_Manager dialogeManager;
    public enemy_behavior_final[] enemyBehaviors;

    // Update is called once per frame
    void Update()
    {
        if (dialogeManager.S_Dialogos.id == 5)
        {
            if (dialogeManager.Used == 1)
            {
                StartCoroutine("TimeToAction");
            }
        }
    }
    IEnumerator TimeToAction() // trigger inicial para los 2 primeros enemigos que salen despues del dialogo
    {
        yield return new WaitForSeconds(1);
        print("ready");
       enemyBehaviors[0].EnemeyReady();
       enemyBehaviors[1].EnemeyReady();

    }
}
