using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Flare_HUD : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public bool canDrag;
    public Image flareImage;
    Vector3 originalPos;
    public Throw_Flare_Manager manager;
    public void Start()
    {
        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }
    public void Update()
    {
        //print(Input.mousePosition);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canDrag = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (canDrag)
        {
           if(Input.mousePosition.x > 1289.0 && Input.mousePosition.x < 1600.0)
            {
                print("hello");
                //transform.position = Input.mousePosition;
                if (Input.mousePosition.y < 174.0 && Input.mousePosition.y > 63.0)
                {
                    transform.position = Input.mousePosition;
                }
            }
           if(Input.mousePosition.x > 1477.0)
            {
                this.gameObject.SetActive(false);
                Invoke("reload", 3f);
                manager.AmmoCount += 1;
            }
        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canDrag = false;
    }
    public void reload()
    {
        gameObject.transform.position = originalPos;
        this.gameObject.SetActive(true);
    }

}

