﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class flickering : MonoBehaviour
{
    public Light2D light2d;
    [Header("Light Charge")]
    public float lightCharge;
    [HideInInspector]public int Count;
    public UI_ControlNaveSc HUD;
    public BengalSystem bengala;
    [Header("Flickering system")]
    public bool iniciate;
    public int Min;
    public int Max;
    [HideInInspector] public int rangeR;

    void Start()
    {     
      
    }

  
    void Update()
    {

        HUD.LinternaNave.LinternaBar.fillAmount = lightCharge / 100f; // transformar valor float para el HUD

        #region Press linterna
        if (Input.GetKeyDown(KeyCode.F))
        {
            Count += 1;
        }

        if(Count > 1)
        {
            Count = 0;
        }
        #endregion

        #region condicion para linterna activa o no
        if (Count == 1)
        {
            light2d.enabled = true;
            lightCharge -= 0.7f * Time.deltaTime;
        }
        if(Count == 0)
        {
            light2d.enabled = false;
        }

      
        if (lightCharge <= 0)
        {
            light2d.enabled = false;
            lightCharge = 0;
        }
        #endregion

        if (iniciate)
        {
            lightFlicker();
        }

      if(lightCharge <= 0f)
        {
            Max = 25;
        }

      if(lightCharge > 100f) // limitar la cantidad de luz solo a 100%
        {
            lightCharge = 100f;
        }
        if (lightCharge < 30f) // si tienes menos carga que cierta cantidad de cifra, pues la luz parpadeara
        {
            iniciate = true;

        }
        else iniciate = false;

    }
     public void lightFlicker()
    {
        rangeR = Random.Range(Min, Max);
        if (rangeR == 1)
        {
            //print("turn on");
            light2d.enabled = true;
        }
        if (rangeR == 2)
        {
            // print("turn off");
            light2d.enabled = false;
        }
    }   

    public void RecargaLinterna()
    {
        if (bengala.CantBengalas != 0 && lightCharge < 100) //preguntar si al menos hay una bengala disponible para recargar y la cantidad de linterna no es 100%
        {
            bengala.CantBengalas--;
            lightCharge += 20f;

        }
     

    }
}
