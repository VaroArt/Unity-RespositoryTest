using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class flickering : MonoBehaviour
{
    public Light2D light2d;
    [HideInInspector]public float initialTime;
    public int Min;
    public int Max;
    public float delay;
    [HideInInspector] public int rangeR;

    void Start()
    {     
        StartCoroutine(start());
    }

  
    void Update()
    {
       
    }
   IEnumerator start()
    {
        yield return new WaitForSeconds(initialTime);
        StartCoroutine(lightFlicker());
    }
    IEnumerator lightFlicker()
    {
        yield return new WaitForSeconds(delay);
        rangeR = Random.Range(Min, Max);
        if(rangeR == 1)
        {
            //print("turn on");
            light2d.enabled = true;
        }
        if(rangeR==2)
        {
            // print("turn off");
            light2d.enabled = false;
        }
        StartCoroutine(lightFlicker());
    }
}
