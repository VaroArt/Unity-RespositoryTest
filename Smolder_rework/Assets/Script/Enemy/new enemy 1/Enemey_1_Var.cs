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
    [Header("Nivel prioridad")]
    public float prioridad;
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
    public Transform[] points;
    [Space(10)]
    public float startWaitTime;
    public float waitTime;
    public int randomSpot;
}

[System.Serializable]
public class PathFinder
{
    Path path;
    public Seeker seeker;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
}

public class Enemey_1_Var : MonoBehaviour
{
    
}


