using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax_effect : MonoBehaviour
{
    [SerializeField] private float parallaxEffect;
    private Transform cameraTr;
    private Vector3 lastCameraPos;
    void Start()
    {
        cameraTr = Camera.main.transform;
        lastCameraPos = cameraTr.position;
    }

   
    void LateUpdate()
    {
        Vector3 deltaMov = cameraTr.position - lastCameraPos;
        transform.position += deltaMov * parallaxEffect;
        lastCameraPos = cameraTr.position;
    }
}
