using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Player : MonoBehaviour
{
    public Transform target;

    public float suavizado = 5f;



    Vector3 desface;

    // Start is called before the first frame update

    void Start()

    {

        desface = transform.position - target.position;

    }





    void FixedUpdate()

    {

        Vector3 posicionObjetivo = target.position + desface;

        transform.position = Vector3.Lerp(transform.position, posicionObjetivo, suavizado * Time.deltaTime);

    }

}
