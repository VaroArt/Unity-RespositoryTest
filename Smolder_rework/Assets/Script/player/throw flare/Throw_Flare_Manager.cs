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
    public UI_ControlNaveSc carganueva;
    void Start()
    {
        canShoot = 1;   
    }

    // para probar el sistema de recarga en el UI Nuevo
    //desactiva el panel.ammocharged, su public panelcontrol
    //si quieres usar el antiguo, descactiva carganueva y 
    //UI_ControlNaveSc
    void Update()
    {
        if(AmmoCount == 1)
        {
            panel.AmmoCharged = true;
            carganueva.municionCargada = true;
            print("llamada");
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
