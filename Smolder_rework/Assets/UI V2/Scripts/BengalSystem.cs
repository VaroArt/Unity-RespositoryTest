using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BengalSystem : MonoBehaviour
{
    [Header("Bengala HUD")]
    public int buttonRecarga1, buttonRecarga2, buttonRecarga3, buttonRecarga4;
    public CanvasRenderer[] luces;
    public Color colorVerde;
    public Color colorRojo;
    public Color colorInactivo;
    int finalNum;
    public int RandomN;
    public int Fire;
    public int canShoot;
    public int AmmoCount;
    public UI_ControlNaveSc carganueva;
    [Header("Bengala spawn")]
    public GameObject flare;
    public Transform pointFlare;

    int GetRandom(int min, int max)
    {
        RandomN = Random.Range(min, max);
        while (RandomN == finalNum)
            RandomN = Random.Range(min, max);
        finalNum = RandomN;
        return RandomN;
    }

    void Start()
    {
        canShoot = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //parte del trowflare manager
        if (AmmoCount == 1)
        {
            carganueva.municionCargada = true;
            print("llamada");
        }
        if (AmmoCount > 1)
        {
            AmmoCount = 1;
        }
    }
     //recarga
    public void Ran()
    {
       GetRandom(1, 5);
        switch (RandomN)
        {
            case 1:
                luces[0].SetColor(colorRojo);
                luces[1].SetColor(colorInactivo);
                luces[2].SetColor(colorInactivo);
                luces[3].SetColor(colorInactivo);
                break;
            case 2:
                luces[0].SetColor(colorRojo);
                luces[1].SetColor(colorRojo);
                luces[2].SetColor(colorInactivo);
                luces[3].SetColor(colorInactivo);
                break;
            case 3:
                luces[0].SetColor(colorRojo);
                luces[1].SetColor(colorRojo);
                luces[2].SetColor(colorRojo);
                luces[3].SetColor(colorInactivo);
                break;
            case 4:
                luces[0].SetColor(colorRojo);
                luces[1].SetColor(colorRojo);
                luces[2].SetColor(colorRojo);
                luces[3].SetColor(colorRojo);
                break;
        }
    }

    public void Btn1Press()
    {
        if (RandomN == 1 || RandomN == 2 || RandomN == 3 || RandomN == 4)
        {
            buttonRecarga1++;
            luces[0].SetColor(colorVerde);
            //luces[0].color = new Color(0.4f, 1, 0.4f);
            if (buttonRecarga1 > 1)
            {
                buttonRecarga1 = 1;
            }
        }
        MecanismoDeRecarga();
    }
    public void Btn2Press()
    {
        if (RandomN == 2 || RandomN == 3 || RandomN == 4)
        {
            buttonRecarga2++;
            luces[1].SetColor(colorVerde);
            //luces[1].color = new Color(0.4f, 1, 0.4f);
            if (buttonRecarga2 > 1)
            {
                buttonRecarga2 = 1;
            }
        }
        MecanismoDeRecarga();
    }
    public void Btn3Press()
    {
        if (RandomN == 3 || RandomN == 4)
        {
            buttonRecarga3++;
            luces[2].SetColor(colorVerde);
            //luces[2].color = new Color(0.4f, 1, 0.4f);
            if (buttonRecarga3 > 1)
            {
                buttonRecarga3 = 1;
            }
        }
        MecanismoDeRecarga();
    }
    public void Btn4Press()
    {
        if (RandomN == 4)
        {
            buttonRecarga4++;
            luces[3].SetColor(colorVerde);
            //luces[3].color = new Color(0.4f, 1, 0.4f);
            if (buttonRecarga4 > 1)
            {
                buttonRecarga4 = 1;
            }
        }
        MecanismoDeRecarga();
    }

    public void MecanismoDeRecarga()
    {
        if (buttonRecarga1 + buttonRecarga2 + buttonRecarga3 + buttonRecarga4 == Fire)
        {
            print("FIRE!");
            AmmoCount = 1;
           /* manager.AmmoCount++;
            manager.canShoot = 0;*/

        }
    }
    public void Shoot()
    {
        Instantiate(flare, pointFlare.position, pointFlare.rotation);
    }
}
