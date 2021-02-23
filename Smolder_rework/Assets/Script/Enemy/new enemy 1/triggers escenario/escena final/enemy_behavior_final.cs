using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_behavior_final : MonoBehaviour
{
    public Enemy_trigger_final trigger;
    public Enemy_1_IA enemy;
    public Transform playertr;
    void Start()
    {
        enemy.patrol.isHide = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger.ready)
        {
            enemy.patrol.isHide = false;
            enemy.patrol.Points[0] = playertr;
        }
    }
}
