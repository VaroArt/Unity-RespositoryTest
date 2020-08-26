using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objetivos : MonoBehaviour
{
    public Text textoObjetivos;
    public int objetivosInt;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (objetivosInt)
        {
            case 1:
                textoObjetivos.text = "Explora la zona".ToString();
                return;
        }
    }
}
