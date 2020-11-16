using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Rendering;

public class camera_shake : MonoBehaviour
{
    public static camera_shake instance { get; private set; }
    private CinemachineVirtualCamera cv;
    private float shakeTimer;


    private void Awake()
    {
        instance = this;
        cv = GetComponent<CinemachineVirtualCamera>();
    }
    public void shakeCamera(float intensity,float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineB = cv.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineB.m_AmplitudeGain = intensity;
        shakeTimer = time;
    }
   

    // Update is called once per frame
    void Update()
    {if(shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0f)
            {
                CinemachineBasicMultiChannelPerlin cinemachineBasic = cv.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                cinemachineBasic.m_AmplitudeGain = 0f;

            }
        }
      
    }
}
