using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.Windows.Speech;

[System.Serializable]
public class EnemyGfx
{
    public SpriteRenderer enemygfx;
    public Material mat;
    public float fade = 1f;
    bool isdissolving = false;

}
[System.Serializable]
public class VariablesMovimiento
{
    public float speed;
    public float attackRadius;
    public bool move;
    public Rigidbody2D rb;
}
[System.Serializable]
public class SensorEnemigo
{
    [Header("Reconocimiento de targets")]
    public LayerMask obstacleMask;
    public bool Recognition;
    public bool iniciateRaycast;
    public float raycastRange;
    [Space(10)]
    [Range(0,4)]
    public float recognitionTime;

    [Header("Targets")]
    public Transform CurrentTarget;
    public Transform PlayerTr;
    public Transform bengalaTr;
}
[System.Serializable]
public class PatrolMode
{
    public Transform[] pointsLow;
    public Transform[] pointsMid;
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


