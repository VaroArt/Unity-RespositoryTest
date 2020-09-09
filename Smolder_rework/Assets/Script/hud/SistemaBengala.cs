using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SistemaBengala : MonoBehaviour
{
    
    public int buttonRecarga1, buttonRecarga2, buttonRecarga3, buttonRecarga4;
    public Image luz1, luz2, luz3, luz4;
    public int Fire;
    int lastNumber;
    public int rand;
    void Start()
    {
     

    }


    void Update()
    {
       
    }
    public void ran()
    {
        // buttonRecarga = Random.Range(2, 4);
        GetRandom(1, 5);
        if (rand == 1)
        {
            luz1.color = new Color(1, 0.4f, 0.4f);
            luz2.color = new Color(1f, 1, 1f);
            luz3.color = new Color(1f, 1, 1f);
            luz4.color = new Color(1f, 1, 1f);
        }
        if (rand == 2)
        {
            luz1.color = new Color(1, 0.4f, 0.4f);
            luz2.color = new Color(1, 0.4f, 0.4f);
            luz3.color = new Color(1f, 1, 1f);
            luz4.color = new Color(1f, 1, 1f);
        }
        if (rand == 3)
        {
            luz1.color = new Color(1, 0.4f, 0.4f);
            luz2.color = new Color(1, 0.4f, 0.4f);
            luz3.color = new Color(1, 0.4f, 0.4f);
            luz4.color = new Color(1f, 1, 1f);
        }
        if (rand == 4)
        {
            luz1.color = new Color(1, 0.4f, 0.4f);
            luz2.color = new Color(1, 0.4f, 0.4f);
            luz3.color = new Color(1, 0.4f, 0.4f);
            luz4.color = new Color(1, 0.4f, 0.4f);
        }
    }
    int GetRandom(int min, int max)
    {
        rand = Random.Range(min, max);
        while (rand == lastNumber)
            rand = Random.Range(min, max);
        lastNumber = rand;
        return rand;
    }
    public void boton1Press()
    {
       if(rand == 1||rand == 2 || rand == 3 || rand == 4)
        {
            buttonRecarga1++;   
            luz1.color = new Color(0.4f, 1, 0.4f);
            if (buttonRecarga1 > 1)
            {
                buttonRecarga1 = 1;
            }
        }

    }
    public void boton2Press()
    {
        if (rand == 2|| rand == 3 || rand == 4)
        {
            buttonRecarga2++;
            luz2.color = new Color(0.4f, 1, 0.4f);
            if (buttonRecarga2 > 1)
            {
                buttonRecarga2 = 1;
            }
        }
       
    }
    public void boton3Press()
    {
        if (rand == 3 || rand == 4)
        {
            buttonRecarga3++;
            luz3.color = new Color(0.4f, 1, 0.4f);
            if (buttonRecarga3 > 1)
            {
                buttonRecarga3 = 1;
            }
        }
       
       
    }
    public void boton4Press()
    {
        if (rand == 4)
        {
            buttonRecarga4++;
            luz4.color = new Color(0.4f, 1, 0.4f);
            if (buttonRecarga4 > 1)
            {
                buttonRecarga4 = 1;
            }
        }
    }
    
}
