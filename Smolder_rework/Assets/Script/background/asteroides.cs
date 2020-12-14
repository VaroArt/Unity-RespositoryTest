using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroides : MonoBehaviour
{

    public Transform pos1, pos2;
    public float speed;
    public float rotateSpeed;
    [HideInInspector]public float rotZ;
    public Transform startPos;
    public bool Rotate;
    Vector3 nextPos;
    void Start()
    {
        nextPos = startPos.position;
       
    }


    void Update()
    {
        if(transform.position == pos1.position) //si llega a la posicion de arriba, baja
        {
            nextPos = pos2.position;
            Rotate = true;
        }
        if(transform.position == pos2.position) // si llega a la posicion de abajo, sube
        {
            nextPos = pos1.position;
            Rotate = false;
        }
        if (Rotate) // la rotacion mas izi del mundo... si sube rota hacia una direccion
        {
            rotZ += Time.deltaTime * rotateSpeed * Time.deltaTime;
        }
        else if (!Rotate) // si baja, rota hacia la direccion contraria.. simple, je
        {
            rotZ += Time.deltaTime * -rotateSpeed * Time.deltaTime;

        }
      
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, 0, rotZ);

    }
}
