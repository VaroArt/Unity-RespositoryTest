using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
   [HideInInspector] public float startpos, ypos;
    public GameObject cam;
    public float parallaxEffect;
    void Start()
    {
        startpos = transform.position.x;
        ypos = transform.position.y;
        
      
    }

    private void Update()
    {
        float dist = (cam.transform.position.x * parallaxEffect);
        float disty = (cam.transform.position.y * parallaxEffect);

        transform.position = new Vector3(startpos + dist, ypos + disty, transform.position.z);
    }

}
