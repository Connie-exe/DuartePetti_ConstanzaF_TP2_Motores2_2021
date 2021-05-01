using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PowerUpsEater : Controller_Enemy
{
    private void FixedUpdate()
    {
        FollowingBehaviour();//se llama a la clase FollowingBehaviour
    }

    private void FollowingBehaviour()
    {
        if (powerup != null)//si player es distinto de null
        {
            agent.SetDestination(powerup.transform.position);//el enemigo utiliza el navmesh para seguir la posición en la que se encuentra el powerup
        }
        if(powerup == null)//si el powerup no está
        {
            Destroy(this.gameObject);//se destruye este objeto
        }
    }

    public new void OnCollisionEnter(Collision collision)//si el objeto colisiona con...
    {
        if (collision.gameObject.CompareTag("PowerUp"))//con el objeto de etiqueta PowerUp
        {
            Destroy(collision.gameObject);//se destruye el objeto con el que colisiona
            Destroy(this.gameObject);//se destruye este objeto
        }

    }
}
