using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy2_test : MonoBehaviour
{
    public Animator enemyAnim;
    public Transform target;
    public Transform Playertarget;
    public float speed;
    [HideInInspector]public float nextWaypointDistance = 3f;
    public float attackRadius;
    public float moveRadius;
    public float angleRotation;
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

    private void Update()
    {
        angleRotation = transform.localEulerAngles.z;
        angleRotation = (int)angleRotation;
        if(angleRotation > 0 && angleRotation < 45)
        {
            print("up");
            enemyAnim.SetFloat("y",1);
            enemyAnim.SetFloat("x", 0);
        }
        if (angleRotation < 350 && angleRotation > 320)
        {
            print("up");
            enemyAnim.SetFloat("y", 1);
            enemyAnim.SetFloat("x", 0);
        }
        if (angleRotation < 90 && angleRotation > 45)
        {
            print("left");
            enemyAnim.SetFloat("y", 0);
            enemyAnim.SetFloat("x", -1);
        }
        if (angleRotation < 180 && angleRotation > 120)
        {
            print("down");
            enemyAnim.SetFloat("y", -1);
            enemyAnim.SetFloat("x", 0);
        }
        if (angleRotation < 270 && angleRotation > 230)
        {
            print("right");
            enemyAnim.SetFloat("y", 0);
            enemyAnim.SetFloat("x", 1);

        }

    }
    void FixedUpdate()
    {
      
        RotateTowards(target.position);
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

    private void RotateTowards(Vector2 target)
    {
        var offset = -90f;
       Vector2 direction = target - (Vector2)transform.position;
        direction.Normalize();
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, moveRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
