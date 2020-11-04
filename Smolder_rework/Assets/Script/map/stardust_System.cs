using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stardust_System : MonoBehaviour
{
    public player_script player;
    public ParticleSystem particle;
    public ParticleSystem.VelocityOverLifetimeModule myvelocity;
    public float valueY;
    public float valueX;
    void Start()
    {
        myvelocity = particle.velocityOverLifetime;
    }

    // Update is called once per frame
    void Update()
    {

        moveUp();
        moveDown();
    }
    public void moveUp()
    {
        myvelocity.y = -player.input.y * 10;
    }
    public void moveDown()
    {
        myvelocity.x = -player.input.x * 10;
    }
    
}
