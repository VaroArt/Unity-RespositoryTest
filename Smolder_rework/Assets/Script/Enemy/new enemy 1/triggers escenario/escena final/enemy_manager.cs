using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_manager : MonoBehaviour
{
    public Dialogue_Manager dialogeManager; 
    [Tooltip("Listado con los script de los enemigos deaa")]
    public enemy_behavior_final[] enemyBehaviors;
    [Tooltip("Audio Source propio del script")]
    public AudioSource audioSource;
    [Tooltip("Audio Source de la camara.Para cambiar la musica del nivel a persecucion, primero apago la musica de la camara y luego activo el audioSource de este script con la musica ya lista")]
    public AudioSource audioCamera;


    // Update is called once per frame
    void Update()
    {
        if (dialogeManager.S_Dialogos.id == 5) // si el dialogo es el final y ademas se termina el dialogo, al estar la variable Used = 1, empezaria la persecucion
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
        audioCamera.Stop();
        print("ready");
        enemyBehaviors[0].EnemeyReady();
        enemyBehaviors[1].EnemeyReady();
        audioSource.enabled = true;
    }
}
