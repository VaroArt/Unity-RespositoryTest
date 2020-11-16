using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.SceneManagement;


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
        patrol.isHide = false;  
        patrol.randomSpot = Random.Range(0, patrol.Points.Length);
        InvokeRepeating("updatePath", 0f, 0.1f);
        Path.seeker = GetComponent<Seeker>();
        movimiento.rb = GetComponent<Rigidbody2D>();
        patrol.waitTime = patrol.startWaitTime;
       
    }

    public void Update()
    {
        #region reset game
        if (movimiento.player.vida <= 0)
        {
            movimiento.timercito -= 1 * Time.deltaTime;
           if(movimiento.timercito <= 2)
            {
                movimiento.player.gameObject.SetActive(false);
            }

            // 
           
        }
        if (movimiento.timercito <= 0)
        {
            SceneManager.LoadScene("UI_Menu");
        }
        #endregion

        Hide();
         Reconocimiento();
         taskTrigger();
         taskList();
         movimiento.rotation.canRotate = true;
         movimiento.rotation.targetTr = sensor.CurrentTarget;

        #region Ver target con radius
        float moveDistance = Vector3.Distance(sensor.sensorTarget.transform.position, transform.position);

        if (moveDistance < movimiento.attackRadius)
        {
           // movimiento.move = false;
        }
        else if (moveDistance < movimiento.MoveDistance)
        {
           // print("target in radius");
             VerTarget();
        }
        if (moveDistance > movimiento.MoveDistance)
        {
           // print("target not in radius");
            sensor.RecognitionGeneral = false;
            //movimiento.rotation.canRotate = false;
        }
        #endregion
    }

    public void FixedUpdate()
    {
      MovimientoBase();
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
            tasks.priority = 15;
            sensor.recognitionTime = 2;
            if(Time.time > movimiento.nextAttack)
            {
                movimiento.nextAttack = Time.time + movimiento.AttackRate;
                RandomAttackTime();
            }
            if(sensor.sensorTarget.tag == ("Bengala"))
            {
                sensor.CurrentTarget = sensor.sensorTarget;
                movimiento.move = true;
            }
            else if (sensor.sensorTarget.tag == ("Player"))
            {
                sensor.CurrentTarget = sensor.sensorTarget;
                movimiento.move = true;
            }
         
        }

        
        if (sensor.recognitionTime <= 0)
        {
           
           
           //sensor.CurrentTarget = null;
            tasks.priority = 10;
            sensor.recognitionTime = 0;
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
              
                // sensor.sensorTarget = null;
              }
          }
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
    public void taskTrigger()
    {
        if (tasks.priority <= 10)
        {
            tasks.TaskList = 1;
        }
        if(tasks.priority >10 && tasks.priority <= 20)
        {
            tasks.TaskList = 2;
        }
    }


    public void taskList()
    {
        switch (tasks.TaskList)
        {
            case 1:
                patrullaje();
                break;
            case 2:
                // activar musica y se para musica 1   
                break;
            case 3:

                break;       
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
  
          if (movimiento.move)
          {
              Vector2 force = direction * movimiento.speed * Time.deltaTime;
              movimiento.rb.AddForce(force);
          }
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

    #region ATTACK
    public void RandomAttackTime()
    {
        movimiento.getRandom(1, 3);
        switch (movimiento.randomNum)
        {
            case 1:
                
                print("velocidad normal 1");
                movimiento.speed = 500f;
                movimiento.MoveDistance = 3.6f;
                break;
            case 2:
                print("Velocidad ataque");
                movimiento.speed = 1800f;
                movimiento.MoveDistance = 4;
              
                break;
            case 3:
               
                print("velocidad normal 2");
                movimiento.speed = 500f;
                movimiento.MoveDistance = 3.6f;
                break;
        }

    }
    #endregion

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == ("Player"))
        {
            movimiento.rotateEnemy.enemyAnim.SetBool("attack", true);
            movimiento.player.vida--;
            camera_shake.instance.shakeCamera(2f, 0.3f);

        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == ("Player"))
        {
            movimiento.rotateEnemy.enemyAnim.SetBool("attack", false);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, movimiento.attackRadius);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, movimiento.MoveDistance);

    }
}
