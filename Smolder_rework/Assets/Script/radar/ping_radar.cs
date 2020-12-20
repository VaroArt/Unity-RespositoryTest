using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ping_radar : MonoBehaviour
{
    public SpriteRenderer spriterd;
    [SerializeField] private float disappeartimer;
    [SerializeField] private float disappeartimerMax;
    [SerializeField] private Color color;




    private void Awake()
    {
        spriterd = GetComponent<SpriteRenderer>();
        disappeartimerMax = 1f;
        disappeartimer = 0f;
        color = new Color(1, 1, 1, 1f);
    }
    void Start()
    {

    }

  
    void Update()
    {
        disappeartimer += Time.deltaTime;

        color.a = Mathf.Lerp(disappeartimerMax, 0f, disappeartimer / disappeartimerMax);
        spriterd.color = color;

        if(disappeartimer >= disappeartimerMax)
        {
            Destroy(gameObject);
        }
    }
    public void setColor(Color color)
    {
        this.color = color;
    }
    public void setdisappeartimer(float disappeartimermax)
    {
        this.disappeartimerMax = disappeartimermax;
        disappeartimer = 0f;
    }

}
