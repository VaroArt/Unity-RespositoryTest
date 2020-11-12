using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1_Rotation : MonoBehaviour
{
    public bool canRotate;
    public float angleRotation;
    public float offset;
    public Transform targetTr;
    public Animator enemyAnim;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canRotate)
        {
            RotateTowards(targetTr.position);    
        }
        rotateAnimation();

        angleRotation = transform.localEulerAngles.z;
        angleRotation = (int)angleRotation;
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

    private void RotateTowards(Vector2 target)
    {
      Vector2 direction = target - (Vector2)transform.position;
      direction.Normalize();
      float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
      transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }
}
