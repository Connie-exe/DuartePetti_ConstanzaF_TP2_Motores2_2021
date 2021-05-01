using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Controller_Enemy
{
    private void FixedUpdate()
    {
        FollowingBehaviour();//se llama a la clase FollowingBehaviour
    }

    private void FollowingBehaviour()
    {
        if (player != null)//si player es distinto de null
        {
            agent.SetDestination(player.transform.position);//el enemigo utiliza el navmesh para seguir la posición en la que se encuentra el jugador
        }
    }

    public new void OnCollisionEnter(Collision collision)//si el objeto colisiona con...
    {
        if (collision.gameObject.CompareTag("Projectile"))//anula la el destroy de Controller_Enemy
        {
            agent.SetDestination(player.transform.position);//sigue persiguiendo al jugador
        }

    }
}
