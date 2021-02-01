using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Flare_Game : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public GameObject point;
    public Light2D luz;
    public GameObject bengala;
    public float countRadius;
    public bool Radius;
    public ParticleSystem spark;
    public ParticleSystem electricity;
    //Sonidos
    public AudioClip explosion;

    private AudioSource audioFlare;

    void Start()
    {

        audioFlare = GetComponent<AudioSource>();

        // rb.AddForce(transform.up * speed, ForceMode2D.Impulse);
        Invoke("exploid", 1f);

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.up * speed;
        if (Radius)
        {
            luz.pointLightOuterRadius += 30 * Time.deltaTime;
            luz.intensity =3;
            if(luz.pointLightOuterRadius > 15f)
            {
                Radius = false;
            }
        }

    }
    public void exploid()
    {
        spark.gameObject.SetActive(true);
        electricity.gameObject.SetActive(true);
        electricity.Play();
        spark.Play();
        bengala.transform.GetChild(0).gameObject.SetActive(false);
        speed = 0;
        Radius = true;

        audioFlare.clip = explosion;
        audioFlare.Play();
        
    }
}
