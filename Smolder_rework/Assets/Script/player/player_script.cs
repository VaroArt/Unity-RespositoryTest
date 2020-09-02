using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_script : MonoBehaviour
{
    Rigidbody2D myrg;
    Vector2 input;
    float shipAngle;
    public float speed;
    public float rotationInterpolation = 0.4f;
    public bool isMoving;
    public int vida;
    void Start()
    {
        myrg = GetComponent<Rigidbody2D>();
        vida = 2;
    }

    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        if(input.x != 0 || input.y != 0)
        {
            isMoving = true;
            rotationInterpolation = 0.4f;
        }
        else
        {
            isMoving = false; 
        }
        Rotation();
      

     
    }
    private void FixedUpdate()
    {
        myrg.velocity = input * speed * Time.deltaTime;
    }

    void Rotation()
    {
        Vector2 lookDir = new Vector2(-input.x, input.y);

        if (isMoving)
        {
            shipAngle = Mathf.Atan2(lookDir.x, lookDir.y) * Mathf.Rad2Deg;
        }
        if(myrg.rotation <= -90 && shipAngle >= 90)
        {
            myrg.rotation += 360;
            myrg.rotation = Mathf.Lerp(myrg.rotation, shipAngle, rotationInterpolation);
        }
        else if  (myrg.rotation >= 90 && shipAngle <= -90)
        {
            myrg.rotation -= 360;
            myrg.rotation = Mathf.Lerp(myrg.rotation, shipAngle, rotationInterpolation);
        }
        else
        {
            myrg.rotation = Mathf.Lerp(myrg.rotation, shipAngle, rotationInterpolation);
        } 
    }
}
