﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_script : MonoBehaviour
{
   
    Rigidbody2D myrg;
    [HideInInspector]public Vector2 input;
    float shipAngle;
    [Header("Variables Movimiento y rotacion")]
    public float speed;
    float speedInitial = 60f;
    public float rotationInterpolation = 0.4f;
    public bool isMoving;
    public int vida;
    public UI_ControlNaveSc hud;
    [Header("Variables turbo")]
    [Range(0,100)]
    public float cantidadTurbo;
    public float turbospeed;
    public bool isTurboActivate;

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

        if(vida <= 1)
        {
            hud.ControlEstadoNave.VidaBaja = true;
        }
       if(vida <= 0)
        {
           
                input.x = 0f;
                input.y=0f;

        }

        UseTurbo();


    }
    private void FixedUpdate()
    {
        myrg.velocity = input * speed * Time.deltaTime;
    }

    public void UseTurbo()
    {
        if (Input.GetKey(KeyCode.LeftShift)&& cantidadTurbo !=0)
        {
            speed = turbospeed;
            cantidadTurbo -= 1 * Time.deltaTime;
            if(cantidadTurbo < 0)
            {
                cantidadTurbo = 0;
            }
        }
        else
        {
            speed = speedInitial;
        }
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
