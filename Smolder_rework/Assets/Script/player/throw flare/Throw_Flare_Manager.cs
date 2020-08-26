using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Throw_Flare_Manager : MonoBehaviour
{
    public int canShoot;
    public int AmmoCount;
    public GameObject flare;
    public Transform pointFlare;
    public PanelControl panel;
    void Start()
    {
        canShoot = 1;   
    }

  
    void Update()
    {
        if(AmmoCount == 1)
        {
            panel.AmmoCharged = true;
        }
        if(AmmoCount > 1)
        {
            AmmoCount = 1;
        }
    }
    public void Shoot()
    {
        Instantiate(flare, pointFlare.position, pointFlare.rotation);
    }
}
