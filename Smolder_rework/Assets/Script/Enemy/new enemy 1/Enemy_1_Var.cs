﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.Windows.Speech;

[System.Serializable]
public class EnemyGfx
{
    public Animator enemyAnim;
    public GameObject gbj;
    public SpriteRenderer enemygfx;
    public Material mat;
    public float fade = 1f;
    public bool isdissolving = false;

}
[System.Serializable]
public class VariablesMovimiento
{
    [Header("Variables movimiento")]
    public float speed;
    public float attackRadius;
    public bool move;
    [Header("Variables rotacion")]
    public float MoveDistance;
    public Enemy_1_Rotation rotation;
    [Header("Attack")]
    public player_script player;
    public float timer;
    [Header("Variables para hacer un random para ataque")]
    public int numFinal;
    public int randomNum;
    public int getRandom(int min, int max)
    {
        randomNum = Random.Range(min, max);
        while (randomNum == numFinal)
            randomNum = Random.Range(min, max);
        numFinal = randomNum;
        return randomNum;
    }
    [Header("Variable para llamar al ataque en cierta cantidad de tiempo")]
    public float AttackRate;
    public float nextAttack = 0.0F;
    public Enemy_1_Rotation rotateEnemy;
    public camera_shake camerashake;
    public float timercito;
    [Header("Rb")]
    public Rigidbody2D rb;
}
[System.Serializable]
public class SensorEnemigo
{
    [Header("Reconocimiento General")]
    public LayerMask obstacleMask;
    public bool RecognitionGeneral;
    public float raycastRangeGeneral;
    [Space(10)]
    [Range(0,2)]
    public float recognitionTime;
    [Header("Targets")]
    public Transform CurrentTarget;
    public Transform sensorTarget;
}
[System.Serializable]
public class PatrolMode
{
    [Header("HideMode")]
    public bool isHide;
    [Header("Puntos movimiento")]
    public Transform[] Points;
    [Space(10)]
    public float startWaitTime;
    public float waitTime;
    public int randomSpot;
}
[System.Serializable]
public class TaskSystem
{
    public string currentTask;
    public int TaskList;
    [Space(10)]
    [Range(0,100)]
    public int priority;
}


[System.Serializable]
public class PathFinder
{
    public Path path;
    public Seeker seeker;
    public float nextWaypointDistance = 3f;
    [HideInInspector]public int currentWaypoint = 0;
    [HideInInspector] public bool reachedEndOfPath = false;
}


public class Enemy_1_Var : MonoBehaviour
{
    
}


