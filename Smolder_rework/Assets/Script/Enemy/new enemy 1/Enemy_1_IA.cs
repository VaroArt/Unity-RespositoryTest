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

    [Header("Sensores")]
    public SensorEnemigo sensor;

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

    public void Update()
    {
        Reconocimiento();

        if (sensor.iniciateRaycast)
        {
            VerTarget();
           
        }

    }


    public void Reconocimiento()
    {
        if(sensor.Recognition)
        {
            sensor.recognitionTime += 1 * Time.deltaTime;
        }
        if(!sensor.Recognition)
        {
            sensor.recognitionTime -= 1 * Time.deltaTime;
        }
        if (sensor.recognitionTime > 4)
        {
            sensor.recognitionTime = 4;
        }

        if (sensor.recognitionTime < 0)
        {
            sensor.recognitionTime = 0;
        }
    }

    public void VerTarget()
    {
        Vector2 dirToTarget = (sensor.CurrentTarget.position - transform.position).normalized;

        if(Vector2.Angle(transform.up,dirToTarget)< sensor.raycastRange /2)
        {
            float dstToTarget = Vector2.Distance(transform.position, sensor.CurrentTarget.position);
            if (!Physics2D.Raycast(transform.position, dirToTarget, dstToTarget, sensor.obstacleMask))
            {
                Vector3 forward = transform.TransformDirection(sensor.CurrentTarget.position - transform.position);
                Debug.DrawRay(transform.position, forward, Color.green);
                sensor.Recognition = true;
            }
            else
            {
                sensor.Recognition = false;
            }
        }
       
    }
   
}
