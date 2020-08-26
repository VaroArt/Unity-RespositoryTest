using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.SceneManagement;

public class enemy1_test : MonoBehaviour
{
    public Transform target;
    public Transform Playertarget;
    public Transform bengala;
    public player_script playerScript;
    public float speed = 200f;
    public float speedPatrol;
    public float nextWaypointDistance = 3f;
    public float attackRadius;
    public float moveRadius;
    public float SoundRadius;
    public float charge;
    public float stop;
    public float TiempoBengala;
    public int moveMode;
    public bool canMove;
    [Header("Enemy Patrol")]
    public Transform[] movePatrol;
    public float startWaitTime;
    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    float waitTime;
    int randomSpot;
    public Seeker seeker;
    Rigidbody2D rb;
    public AudioSource audioFondo;
    AudioSource myaudio;
    public AudioClip myclip;
    public AudioClip myclip2;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, movePatrol.Length);
        myaudio = GetComponent<AudioSource>(); 
        // seeker.StartPath(rb.position, target.position, OnPathComplete);
        InvokeRepeating("updatePath", 0f, 0.1f);
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

    // Update is called once per frame
    void FixedUpdate()
    {
        
        move();
        
        if (path == null)
            return;
        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        if (canMove)
        {
            Vector2 force = direction * speed * Time.deltaTime;
            rb.AddForce(force);
        }
        float moveDistance = Vector3.Distance(Playertarget.position, transform.position);
        float soundPersecucion = Vector3.Distance(Playertarget.position, transform.position);
        
        if(soundPersecucion < attackRadius)
        {

        }
        else if (soundPersecucion > SoundRadius)
        {
            /*audioFondo.Stop();
            myaudio.clip = myclip2;
            myaudio.Play();*/
        }
        if (moveDistance < attackRadius)
        {
            print("muerte");
            SceneManager.LoadScene("Main Menu");
          
        }
        else if (moveDistance < moveRadius)
        {
            //rb.AddForce(force);
            target = Playertarget;
            moveMode = 0;
            canMove = true;
            RotateTowards(target.position);
            if(charge < 3f)
            {
                charge += 1 * Time.deltaTime;
                //
            }
           
            if(charge > 3f)
            {
               // attackRadius = 2f;
                speed = 1600f;
                myaudio.clip = myclip;
                myaudio.Play();
                if (stop < 1f)
                {
                    stop += 1 * Time.deltaTime;
                }
                if(stop > 1f)
                {
                    attackRadius = 1.32f;
                    speed = 400f;
                    charge = 0f;
                    stop = 0;
                }
            }

        }
       if(moveDistance > moveRadius)
        {
            //print("out of range");
            moveMode = 1;
            charge = 0;
            speed = 400;
        }

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;

        }

    }
    public void move()
    {
        switch (moveMode)
        {
            case 1:
                target = movePatrol[randomSpot];

                float moveDistance = Vector3.Distance(target.position, transform.position);
                if (moveDistance < attackRadius)
                {
                    if (waitTime <= 0)
                    {
                        randomSpot = Random.Range(0, movePatrol.Length);
                        waitTime = startWaitTime;
                    }
                    else
                    {
                        waitTime -= Time.deltaTime;
                    } //aqui va el ataque
                }
                else if (moveDistance > attackRadius)
                {
                   // transform.position = Vector2.MoveTowards(transform.position, movePatrol[randomSpot].position, speedPatrol * Time.deltaTime);
                    RotateTowards(target.position);
                    canMove = true;
                }

                break;
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == ("Bengala"))
        {
            print("ahora si o no ctm");
            bengala = collision.transform;
            target = bengala;
            moveMode = 0;
            RotateTowards(target.position);
            if(TiempoBengala < 5f)
            {
                TiempoBengala += 1 * Time.deltaTime;
            }
            if(TiempoBengala > 5f)
            {
                moveMode = 1;
                bengala.gameObject.SetActive(false);
            }
        }
        if(collision.tag == ("Player"))
        {
          
               

        }
    }
    private void RotateTowards(Vector2 target)
    {
        var offset = -90f;
        Vector2 direction = target - (Vector2)transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, moveRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, SoundRadius);
    }
    
}
