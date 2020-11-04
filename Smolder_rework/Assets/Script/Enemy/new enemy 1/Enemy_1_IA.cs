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
      
        gfx.mat.SetFloat("_Fade", 1f);
    }
    public void Start()
    {
        movimiento.move = true;
        patrol.randomSpot = Random.Range(0, patrol.Points.Length);
        InvokeRepeating("updatePath", 0f, 0.1f);
        Path.seeker = GetComponent<Seeker>();
        movimiento.rb = GetComponent<Rigidbody2D>();
        patrol.waitTime = patrol.startWaitTime;
       
    }

    public void Update()
    {
        Hide();
        taskTrigger();
        taskList();
        Reconocimiento();
        ReconocimientoSecundario();

    }

    public void FixedUpdate()
    {
        if (movimiento.move)
        {
           MovimientoBase();
        }
      
    }

    #region Sensor vision 
    public void Reconocimiento()
    {
        if(sensor.RecognitionGeneral)
        {
            sensor.recognitionTime += 1 * Time.deltaTime;
        }
        if(!sensor.RecognitionGeneral)
        {
            sensor.recognitionTime -= 1 * Time.deltaTime;
            
        }
        if (sensor.recognitionTime > 2)
        {
            sensor.recognitionTime = 2;
            if(sensor.sensorTarget.tag == ("Bengala"))
            {
                 sensor.CurrentTarget = sensor.sensorTarget;
                tasks.priority = 20;
            }
            else if (sensor.sensorTarget.tag == ("Player"))
            {
                tasks.priority = 20;
                sensor.CurrentTarget = sensor.sensorTarget;
            }
        }

        if (sensor.recognitionTime < 0)
        {
            tasks.priority = 10;
            sensor.recognitionTime = 0;
        }
    }

    public void ReconocimientoSecundario()
    {
        if (sensor.RecognitionSecondary)
        {
            sensor.recognitionTime2 += 1.5f * Time.deltaTime;
        }
        if (!sensor.RecognitionSecondary)
        {
            sensor.recognitionTime2 -= 1.5f * Time.deltaTime;

        }
        if (sensor.recognitionTime2 > 4)
        {
            sensor.recognitionTime2 = 4;
            if (sensor.sensorTarget.tag == ("Bengala"))
            {
                sensor.CurrentTarget = sensor.sensorTarget;
            }
            else if (sensor.sensorTarget.tag == ("Player"))
            {
                sensor.CurrentTarget = sensor.sensorTarget;
            }
        }

        if (sensor.recognitionTime2 < 0)
        {
            sensor.recognitionTime2 = 0;
        }
    }
    public void VerTarget()
    {
        Vector2 dirToTarget = (sensor.sensorTarget.position - transform.position).normalized;

        if(Vector2.Angle(transform.up,dirToTarget)< sensor.raycastRangeGeneral)
        {
            float dstToTarget = Vector2.Distance(transform.position, sensor.sensorTarget.position);
            if (!Physics2D.Raycast(transform.position, dirToTarget, dstToTarget, sensor.obstacleMask))
            {
                Vector3 forward = transform.TransformDirection(sensor.sensorTarget.position - transform.position);
                Debug.DrawRay(transform.position, forward, Color.green);
                sensor.RecognitionGeneral = true;
            }
           else
            {
                sensor.RecognitionGeneral = false;
                sensor.sensorTarget = null;
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
                patrullaje();

                break;
            case 2:
                tasks.currentTask = ("Explore Zone 2");
                sensor.CurrentTarget = sensor.sensorTarget;
               
                break;
            case 3:

                break;       
        }
    }
    public void taskTrigger()
    {
        if (tasks.priority <= 10)
        {
           
            tasks.TaskList = 1;
        }

        if (tasks.priority == 20)
        {
            movimiento.move = true;
            tasks.TaskList = 2;
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
        sensor.CurrentTarget = patrol.Points[patrol.randomSpot];

        float moveDistance = Vector3.Distance(sensor.CurrentTarget.position, transform.position);

        if (moveDistance < movimiento.attackRadius)
        {
            if (patrol.waitTime <= 0)
            {
                patrol.randomSpot = Random.Range(0, patrol.Points.Length);
                patrol.waitTime = patrol.startWaitTime;
            }
            else
            {
                movimiento.move = false;
                patrol.waitTime -= Time.deltaTime;

            }
        }
        else if (moveDistance > movimiento.attackRadius)
        {
            movimiento.move = true;
        }
    }

    #endregion

    #region Hide mode
    public void Hide()
    {
        if (patrol.isHide)
        {
            gfx.isdissolving = true;
            if (gfx.isdissolving)
            {
                gfx.fade -= Time.deltaTime;

                if(gfx.fade <= 0f)
                {
                    gfx.fade = 0f;
                    gfx.isdissolving = false;
                }
                gfx.mat.SetFloat("_Fade", gfx.fade);
            }
        }
        if (!patrol.isHide)
        {
            gfx.fade += Time.deltaTime;
            if(gfx.fade >= 1)
            {
                gfx.fade = 1f;
            }
            gfx.mat.SetFloat("_Fade", gfx.fade);
        }
    }

    #endregion

    private void RotateTowards(Vector2 target)
    {
        if (movimiento.canRotate)
        {
            Vector2 direction = target - (Vector2)transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(Vector3.forward * (angle + movimiento.offset));
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, movimiento.attackRadius);
    }
}
