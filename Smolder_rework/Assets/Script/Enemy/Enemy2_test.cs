using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy2_test : MonoBehaviour
{
    public Transform target;
    public Transform Playertarget;
    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    public float attackRadius;
    public float moveRadius;
    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    public Seeker seeker;
    Rigidbody2D rb;
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("updatePath", 0f, .5f);

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

    void FixedUpdate()
    {

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

        
        float moveDistance = Vector3.Distance(Playertarget.position, transform.position);


        if(moveDistance < attackRadius)
        {

        }
        else if(moveDistance < moveRadius)
        {
            Vector2 force = direction * speed * Time.deltaTime;
            rb.AddForce(force);
        }
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, moveRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
