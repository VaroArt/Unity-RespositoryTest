using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.Windows.Speech;

[System.Serializable]
public class EnemyGfx
{
    public GameObject gbj;
    public SpriteRenderer enemygfx;
    public Material mat;
    public float fade = 1f;
    public bool isdissolving = false;

}
[System.Serializable]
public class VariablesMovimiento
{
    public float speed;
    public float attackRadius;
    public bool move;
    public bool canRotate;
    public float offset;
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

    [Header("Reconocimiento de Secundario")]
    public bool RecognitionSecondary;
    [Space(10)]
    [Range(0, 4)]
    public float recognitionTime2;
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


