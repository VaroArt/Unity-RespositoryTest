using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System.Threading.Tasks;

public class Enemy_1_IA : Enemy_1_Var
{
    [Header("EnemtGFX")]
    public EnemyGfx gfx;

    [Header("Movimiento")]
    public VariablesMovimiento movimiento;

    [Header("Sensores")]
    public SensorEnemigo sensor;

    [Header("Task")]
    public TaskSystem tasks;

    [Header("Patrullaje")]
    public PatrolMode patrol;

    [Header("PathFind")]
    public PathFinder Path;


    public void Awake()
    {
      

    }
    public void Start()
    {
        InvokeRepeating("updatePath", 0f, 0.1f);
        Path.seeker = GetComponent<Seeker>();
        movimiento.rb = GetComponent<Rigidbody2D>();
        patrol.waitTime = patrol.startWaitTime;
        patrol.randomSpot = Random.Range(0, patrol.points.Length);
    }

    public void Update()
    {
        taskTrigger();
        taskList();
        Reconocimiento();
        if (sensor.CurrentTarget != null)
        {
           // VerTarget();
        } 
    }

    public void FixedUpdate()
    {
        MovimientoBase();
    }

    #region Sensor vision 
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

        if(Vector2.Angle(transform.up,dirToTarget)< sensor.raycastRange)
        {
            float dstToTarget = Vector2.Distance(transform.position, sensor.CurrentTarget.position);
            if (!Physics2D.Raycast(transform.position, dirToTarget, dstToTarget, sensor.obstacleMask))
            {
                Vector3 forward = transform.TransformDirection(sensor.CurrentTarget.position - transform.position);
                Debug.DrawRay(transform.position, forward, Color.green);
                sensor.Recognition = true;
               /* if(sensor.CurrentTarget == sensor.PlayerTr)
                {

                }
                if (sensor.CurrentTarget == sensor.bengalaTr)
                {

                }*/
            }
           else
            {
                sensor.Recognition = false;
               // sensor.CurrentTarget = null;
            }
        }
       
    }

    public void perderTarget()
    {
        sensor.CurrentTarget = null;
    }

    #endregion

    #region Pathfind
    void updatePath()
    {
        if (Path.seeker.IsDone())
        {
            Path.seeker.StartPath(movimiento.rb.position, sensor.CurrentTarget.position, OnPathComplete);
        }
    }
    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            Path.path = p;
            Path.currentWaypoint = 0;
        }
    }

    #endregion

    #region Tareas
    public void taskList()
    {
        switch (tasks.TaskList)
        {
            case 1:
                tasks.currentTask = ("Explore Zone");
                tasks.priority = 10;
                break;
            case 2:
                tasks.currentTask = ("Explore Zone 2");
                tasks.priority = 20;
                break;
        }
    }
    public void taskTrigger()
    {
        if (tasks.priority <= 10)
        {
            patrullaje();
        }

        if (tasks.priority >= 20)
        {
            sensor.CurrentTarget = sensor.PlayerTr;
        }
    }
    #endregion

    #region Movimiento Base
    public void MovimientoBase()
    {
        if (Path.path == null)
            return;
        if (Path.currentWaypoint >= Path.path.vectorPath.Count)
        {
            Path.reachedEndOfPath = true;
            return;
        }
        else
        {
            Path.reachedEndOfPath = false;
        }
        Vector2 direction = ((Vector2)Path.path.vectorPath[Path.currentWaypoint] - movimiento.rb.position).normalized;

        Vector2 force = direction * movimiento.speed * Time.deltaTime;
        movimiento.rb.AddForce(force);

        float distance = Vector2.Distance(movimiento.rb.position, Path.path.vectorPath[Path.currentWaypoint]);

        if (distance < Path.nextWaypointDistance)
        {
            Path.currentWaypoint++;
        }
    }

    #endregion

    #region Movimiento Patrullaje
    public void patrullaje()
    {
        sensor.CurrentTarget = patrol.points[patrol.randomSpot];

        float moveDistance = Vector3.Distance(sensor.CurrentTarget.position, transform.position);

        if (moveDistance > movimiento.attackRadius)
        {
            if (patrol.waitTime <= 0)
            {
                patrol.randomSpot = Random.Range(0, patrol.points.Length);
                patrol.waitTime = patrol.startWaitTime;
            }
            else
            {
                patrol.waitTime -= Time.deltaTime;
            }
        }
        else if (moveDistance > movimiento.attackRadius)
        {
            //movimiento 
        }
    }

    #endregion
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, movimiento.attackRadius);
    }
}
