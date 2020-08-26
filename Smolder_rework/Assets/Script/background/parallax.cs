using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    private float lenght, startpos, startposy;
    public GameObject cam;
    public float parallaxEffect;
    public float parallaxEffect2;
    void Start()
    {
        startpos = transform.position.x;
        startposy = transform.position.y;
        
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate()
    {
        float dist = (cam.transform.position.x * parallaxEffect);
        float disty = (cam.transform.position.y * parallaxEffect);
        transform.position = new Vector3(startpos + dist, startposy + disty, transform.position.z);
    }

}
