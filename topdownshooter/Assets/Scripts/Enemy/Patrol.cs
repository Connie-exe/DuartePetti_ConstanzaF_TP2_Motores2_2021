using UnityEngine;

public class Patrol : Controller_Enemy
{
    private void FixedUpdate()
    {
        Patroling();//llama a la clase Patroling
    }

    private void Patroling()
    {
        if (player != null)//si player es distinto de null
        {
            var heading = player.transform.position - this.transform.position;//al restar la posición de este objeto a la posición del player, este objeto "se dirige" al player
            var distance = heading.magnitude;// la distancia es igual a la magnitud que hay entre el player y el heading del este objeto
            if (distance < patrolDistance)//si distancia es menor que la distancia de la patrulla
            {
                agent.SetDestination(player.transform.position);//se le dice al objeto que mediante el navmesh siga al player
            }
            else//de lo contrario
            {
                PatrolBehaviour();//llama a la función PatrolBehaviour
            }
        }
    }

    private void PatrolBehaviour()
    {
        agent.SetDestination(destination);//se pone una destinación mediante el navmesh
        destinationTime -= Time.deltaTime;//el tiempo de destinación disminuye a medida que pasa el tiempo en unity
        if (destinationTime < 0)//si el tiempo de destinación es menor a 0
        {
            destination = new Vector3(Random.Range(-10, 12), 1, Random.Range(-12, 9));//la destinación se define con 2 valores random en el espacio, en sus ejes x y z
            destinationTime = 4;//y el valor del tiempo de destinación pasa a valer 4
        }
    }
}
