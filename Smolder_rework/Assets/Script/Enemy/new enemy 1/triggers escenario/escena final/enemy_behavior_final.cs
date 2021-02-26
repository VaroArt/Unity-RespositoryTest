using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_behavior_final : MonoBehaviour
{
    public Enemy_1_IA enemy;
    public Transform playertr;
    public BoxCollider2D colliderAttack;


    void Start()
    {
        enemy.patrol.isHide = true;
        enemy.movimiento.move = false;
    }

    public void EnemeyReady()
    {
        //El enemigo tiene muchos comportamientos que deben activarse para dar la ilusion de que esta listo, pero escondido
        //Se debe activar su efecto de desaparecer, darle al player como target, activarle el movimiento, darle velocidad, distancia de movimiento, y distancia de stop
        //Ademas de activar su collider de ataque, porque esta desactivado por si el player colisiona estando invisible el enemigo
        enemy.patrol.isHide = false;
        enemy.patrol.Points[0] = playertr;
        enemy.movimiento.move = true;
        enemy.movimiento.MoveDistance = 5f;
        enemy.movimiento.speed = 400f;
        enemy.movimiento.stopRadius = 1.31f;
        colliderAttack.enabled = true;
    }
}
