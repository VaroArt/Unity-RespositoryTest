using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InfoInventario : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
    public GameObject InfoSlot1, InfoSlot2, InfoSlot3;
    public InventarioSystem inventario;
    public Text text;



    public void OnPointerEnter(PointerEventData eventData)
    {
        //print(name);
        if(gameObject.name ==("slot 1"))
        {
            print("slot1");
            InfoSlot1.SetActive(true);

            if(inventario.ItemList[0] == ("Coordenada 1"))
            {
                text.text = "Coordenada N°1";
            }
            else if(inventario.ItemList[0]==("Coordenada 2"))
            {
                text.text = "Coordenada N°2";
            }
            else if (inventario.ItemList[0] == ("Llave"))
            {
                text.text = "Llave";
            }
        }
        if (gameObject.name == ("slot 2"))
        {
            print("slot2");
            InfoSlot2.SetActive(true);

            if (inventario.ItemList[1] == ("Coordenada 1"))
            {
                text.text = "Coordenada N°1";
            }
            else if (inventario.ItemList[1] == ("Coordenada 2"))
            {
                text.text = "Coordenada N°2";
            }
            else if (inventario.ItemList[1] == ("Llave"))
            {
                text.text = "Llave";
            }

        }
        if (gameObject.name == ("slot 3"))
        {
            print("slot3");
            InfoSlot3.SetActive(true);

            if (inventario.ItemList[2] == ("Coordenada 1"))
            {
                text.text = "Coordenada N°1";
            }
            else if (inventario.ItemList[2] == ("Coordenada 2"))
            {
                text.text = "Coordenada N°2";
            }
            else if (inventario.ItemList[2] == ("Llave"))
            {
                text.text = "Llave";
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (gameObject.name == ("slot 1"))
        {
            print("slot1");
            InfoSlot1.SetActive(false);
        }
        if (gameObject.name == ("slot 2"))
        {
            print("slot2");
            InfoSlot2.SetActive(false);
        }
        if (gameObject.name == ("slot 3"))
        {
            print("slot3");
            InfoSlot3.SetActive(false);
        }
    }
    
}
