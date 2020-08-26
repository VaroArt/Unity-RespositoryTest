using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float ViewRad;
    [Range(0, 360)]
    public float viewAng;

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    public List<Transform> visibleTargets = new List<Transform>();
    [Space(10)]
    public Enemy_IA_1 enemy;
    private void Start()
    {
        StartCoroutine("FindTargetsWithDelay", .2f);
    }

    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
           
        }
    }
    void FindVisibleTargets()
    {
        visibleTargets.Clear();
        Collider2D[] targetsInViewRadius = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), ViewRad, targetMask);
        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector2 dirToTarget = (target.position - transform.position).normalized;
           
            if (Vector2.Angle(transform.up, dirToTarget) < viewAng / 2)
            {
                float dstToTarget = Vector2.Distance(transform.position, target.position);
                if (Physics2D.Raycast(transform.position, dirToTarget, dstToTarget, targetMask))
                {
                    visibleTargets.Add(target);
                    if (visibleTargets.Count > 0 && target.transform.gameObject.tag == ("Player"))
                    {
                        enemy.Attackmode = 3;
                        enemy.canMove = true;
                        if(dstToTarget > enemy.stopRadius)
                        {
                            enemy.canMove = false;
                        }
                    }
                    
                    if(visibleTargets.Count > 0 && target.transform.gameObject.tag == ("Bengala"))
                    {
                        //print("bengala");
                        enemy.canMove = true;
                        enemy.Attackmode = 1;
                    }
                   
                }
            }
        }
        if (visibleTargets.Count < 1)
        {
            //print("bruh");
            enemy.canMove = false;
            enemy.Attackmode = 0;
        }
    }

    public Vector2 DirFromAngle(float angleInDegress, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegress -= transform.eulerAngles.z;
        }
        return new Vector2(Mathf.Sin(angleInDegress * Mathf.Deg2Rad), Mathf.Cos(angleInDegress * Mathf.Deg2Rad));
    }
}
