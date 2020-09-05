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
    public float stopRadius;
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
        rotateAnimation();
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

        if(moveDistance < stopRadius)
        {

        }
        else if(moveDistance < moveRadius)
        {
                RotateTowards(target.position);
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
   
    public void rotateAnimation()
    {
        angleRotation = transform.localEulerAngles.z;
        angleRotation = (int)angleRotation;

        if (angleRotation >= 0)
        {
            enemyAnim.SetFloat("x", 0);
            enemyAnim.SetFloat("y", 1);
        }
        if (angleRotation >= 10 && angleRotation < 70)
        {
            enemyAnim.SetFloat("x", -1);
            enemyAnim.SetFloat("y", 1);
        }
        if (angleRotation >= 70 && angleRotation < 108)
        {
            enemyAnim.SetFloat("x", -1);
            enemyAnim.SetFloat("y", 0);
        }
        if (angleRotation >= 108 && angleRotation < 165)
        {
            enemyAnim.SetFloat("x", -1);
            enemyAnim.SetFloat("y", -1);
        }
        if (angleRotation >= 165 && angleRotation < 204)
        {
            enemyAnim.SetFloat("x", 0);
            enemyAnim.SetFloat("y", -1);
        }
        if (angleRotation >= 204 && angleRotation < 231)
        {
            enemyAnim.SetFloat("x", 1);
            enemyAnim.SetFloat("y", -1);
        }
        if (angleRotation >= 231 && angleRotation < 294)
        {
            enemyAnim.SetFloat("x", 1);
            enemyAnim.SetFloat("y", 0);
        }
        if (angleRotation >= 294 && angleRotation < 345)
        {
            enemyAnim.SetFloat("x", 1);
            enemyAnim.SetFloat("y", 1);
        }
        if (angleRotation >= 345)
        {
            enemyAnim.SetFloat("x", 0);
            enemyAnim.SetFloat("y", 1);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, moveRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stopRadius);
    }
}
