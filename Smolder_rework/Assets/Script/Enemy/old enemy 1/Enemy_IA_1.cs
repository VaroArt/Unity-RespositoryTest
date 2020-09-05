using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class Enemy_IA_1 : MonoBehaviour
{
    [Header("Enemy Move Atributtes")]
    public Transform target;
    public Transform playerTarget;
    public Transform bengala;
    public Transform attackTarget;
    public Vector2 curretPlayerPos =new Vector2(0, 0);
    public float speedPatrol;
    public float nextWaypointDistance = 3f;
    public float moveRadius;
    public float offset;
    public bool canRotate;
    public bool canMove;
    [Header("Enemy Attack Atributtes")]
    public float stopRadius;
    public float TiempoBengala;
    public float chargeAttack;
    public float timetoStop;
    public int Attackmode;
    [Header("Enemy Patrol")]
    public Transform[] movePatrol;
    public float startWaitTime;
    [Header("Enemy gfx")]
    public SpriteRenderer enemygfx;
    public Material mat;
    bool isdissolving = false;
    public float fade = 1f;

    float waitTime;
    int randomSpot;
    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    [Header("Scripts")]
    public Seeker seeker;
    public player_script player;
    Rigidbody2D rb;
    CircleCollider2D circle;
    
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        circle = GetComponent<CircleCollider2D>();
        InvokeRepeating("updatePath", 0f, 0.1f);

        // parte de patrullaje del enemigo
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, movePatrol.Length);
        mat.SetFloat("_Fade", 1f);
    }

    void updatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }
    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
    private void Update()
    {
        attack();
        // canRotate = true;
      /*  if(canMove == false)
        {
            Attackmode = 0;
        }*/
       if (canMove)
        {
            //Attackmode = 3;

        }
        else
        {

        }
        if (canRotate)
        {
            RotateTowards(target.position);
        }
      /*  float MoveDistance = Vector3.Distance(target.position, transform.position);
        if (MoveDistance < stopRadius)
        {
            //stop move

        }
         else if (MoveDistance > stopRadius)
         {
             transform.position = Vector2.MoveTowards(transform.position, target.position, speedPatrol * Time.deltaTime);
         }*/
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        

        if (path == null)
            return;
        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
       
        float MoveDistance = Vector3.Distance(target.position, transform.position);

        float attackDistance = Vector3.Distance(target.position, transform.position);

        /*if(attackDistance < attackRadius)
        {
            timeToAttack += 2f * Time.deltaTime;
            if (timeToAttack >= 3f)
            {
                //canRotate = false;
                timeToAttack = 3f;
                Attackmode = 1;

            } 
        }*/
        /* if (attackDistance > attackRadius)
         {
            // canRotate = true;
             timeToAttack = 0f;
             Attackmode = 0;

         }*/
        /*  if (MoveDistance < stopRadius )
          {
              //stop move

          }*/


        /* else if (MoveDistance < moveRadius)
         {
             transform.position = Vector2.MoveTowards(transform.position, target.position, speedPatrol * Time.deltaTime);
             if (chargeAttack > 1f)
             {
                 Attackmode = 2;
             }
             // canRotate = true;
         }*/
        if (canMove)
        {
            //Attackmode = 3;
            transform.position = Vector2.MoveTowards(transform.position, target.position, speedPatrol * Time.deltaTime);
        }
        else
        {

        }

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if(distance < nextWaypointDistance)
        {
            currentWaypoint++;  
        }

    }
    private void RotateTowards(Vector2 target)
    {
        if (canRotate)
        {
            Vector2 direction = target - (Vector2)transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, stopRadius);
    }
    public void attack()
    {
        switch (Attackmode)
        {
            case 0:
                chargeAttack = 0;
                speedPatrol = 1f;
                canRotate = true;
                target = movePatrol[randomSpot];
                 float stop = Vector3.Distance(target.position, transform.position);
                if (stop < stopRadius)
                {
                    if (waitTime <= 0)
                    {
                        randomSpot = Random.Range(0, movePatrol.Length);
                        waitTime = startWaitTime;
                    }
                    else
                    {
                        waitTime -= Time.deltaTime;
                    }
                }
                 else if(stop > stopRadius)
                 {
                     transform.position = Vector2.MoveTowards(transform.position, movePatrol[randomSpot].position, speedPatrol * Time.deltaTime);
                   
                }
                
                /*canRotate = true;
                transform.position = Vector2.MoveTowards(transform.position, movePatrol[randomSpot].position, speedPatrol * Time.deltaTime);
                if (Vector2.Distance(transform.position, movePatrol[randomSpot].position) < 0.2f)
                {
                    if (waitTime <= 0)
                    {
                        randomSpot = Random.Range(0, movePatrol.Length);
                        waitTime = startWaitTime;
                    }
                    else
                    {
                        waitTime -= Time.deltaTime;
                    }
                }*/
                break;

            case 1:
                chargeAttack = 0;
                target = GameObject.FindGameObjectWithTag("Bengala").transform;
                speedPatrol = 2f;
                if(TiempoBengala < 10f)
                {
                    TiempoBengala += 1 * Time.deltaTime;
                }
                if(TiempoBengala > 10f)
                {
                    TiempoBengala = 0;
                    Attackmode = 0;
                }

                /*chargeAttack += 2 * Time.deltaTime;
                speedPatrol = 0f;
                stopRadius = 0f;*/
                //prueba de hacer invisible al enemigo..
                 isdissolving = true;
                  if (isdissolving)
                  {
                      fade -= Time.deltaTime;

                      if(fade<= 0f)
                      {
                          fade = 0f;
                          isdissolving = false;
                      }
                      mat.SetFloat("_Fade", fade);
                  }
                break;

            case 2:
              /*  canRotate = true;
                circle.isTrigger = true;
                speedPatrol = 10f;*/
                break;
            case 3:
               // curretPlayerPos = target.position;
                target = playerTarget;
                speedPatrol = 2f;
                stopRadius = 1.78f;
                canMove = true;
                //Attackmode = 5;
              /*  if (chargeAttack < 4f)
                {
                    chargeAttack += 20f * Time.deltaTime;
                   
                }
                if(chargeAttack > 4f)
                {
                    speedPatrol = 5f;
                    canRotate = false;
                    chargeAttack =
                   timetoStop += 10 * Time.deltaTime;
                }
                if(timetoStop > 0.5f)
                {

                }*/
              
                break;
            case 5:

               

                break;
              
        }
    }
    
}
