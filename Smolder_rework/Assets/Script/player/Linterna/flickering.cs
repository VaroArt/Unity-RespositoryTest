using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class flickering : MonoBehaviour
{
    public Light2D light2d;
    public bool iniciate;
    public int Min;
    public int Max;
    public int rangeR;

    void Start()
    {     
      
    }

  
    void Update()
    {
        if (iniciate)
        {
            lightFlicker();
        }
     
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
}
