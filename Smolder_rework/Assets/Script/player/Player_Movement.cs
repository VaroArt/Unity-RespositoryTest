using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    [HideInInspector] public float moveInputy;
    [HideInInspector]public float moveInputX;
    public float speed;
    public float rotateSpeed;
    public Animator anim;
    Rigidbody2D rb;

    // Start is called before the first frame update

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveInputy = Input.GetAxisRaw("Vertical");
        moveInputX = Input.GetAxisRaw("Horizontal");
        
        if(moveInputy != 0)
        {
            transform.position += transform.up * Time.deltaTime * speed;
        }

       if(moveInputX > 0)
        {
            rb.rotation -= rotateSpeed;
            anim.SetBool("turnRight", true);
            anim.SetBool("Idle", false);
        }
       if(moveInputX == 0)
        {
            anim.SetBool("turnRight", false);
            anim.SetBool("Idle", true);
        }
        if (moveInputX < 0)
        {
            rb.rotation +=rotateSpeed;
            anim.SetBool("turnLeft", true);
            anim.SetBool("Idle", false);
        }
    }
}
