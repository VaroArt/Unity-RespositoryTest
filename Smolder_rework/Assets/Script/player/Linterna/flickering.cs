using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class flickering : MonoBehaviour
{
    public Light2D light2d;
    [Header("Light Count")]
    public float lightCharge;
    public int Count;
    public UI_ControlNaveSc HUD;
    [Header("Flickering system")]
    public bool iniciate;
    public int Min;
    public int Max;
    public int rangeR;

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
            lightCharge -= 1 * Time.deltaTime;
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
