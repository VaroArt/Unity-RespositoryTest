using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_portal_inicio : MonoBehaviour
{
    public GameObject E;
    public CircleCollider2D circle;
    public camera_shake shake;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Shakeshake()
    {
        shake.shakeCamera(2f, 0.3f);
    }
    public void startInteraction()
    {
        E.SetActive(true);
        circle.enabled = true;

    }
}
