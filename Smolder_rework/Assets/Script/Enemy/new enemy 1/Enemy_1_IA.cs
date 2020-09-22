using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class Enemy_1_IA : Enemey_1_Var
{
    [Header("EnemtGFX")]
    public EnemyGfx gfx;

    [Header("Movimiento")]
    public VariablesMovimiento variables_movimiento;

    [Header("Transform")]
    public Targets targets;

    [Header("Patrullaje")]
    public PatrolMode patrol;

    [Header("PathFind")]
    public PathFinder path;
    public void Awake()
    {
        
    }
    public void Start()
    {
        variables_movimiento.speed = 400;
        path.seeker = GetComponent<Seeker>();
        variables_movimiento.rb = GetComponent<Rigidbody2D>();
        patrol.waitTime = patrol.startWaitTime;
        patrol.randomSpot = Random.Range(0, patrol.points.Length);
    }

    void Update()
    {
        
    }

}
