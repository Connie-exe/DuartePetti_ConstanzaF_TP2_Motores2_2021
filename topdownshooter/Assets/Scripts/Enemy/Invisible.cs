using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisible : Controller_Enemy
{
    public MeshRenderer visibilidad;//se declara al renderer del objeto
    public float availableDistance;//un float para la distancia permitida
    private float distance;//un float para saber la distancia del enemigo al jugador

    private void Start()
    {
        visibilidad = GetComponent<MeshRenderer>();//se llama al renderer del objeto
    }
    private void FixedUpdate()
    {
        FollowingBehaviour();//se llama a la clase FollowingBehaviour
        GameObject Player = GameObject.FindGameObjectWithTag("Player");//se encuentra al player
        MeshRenderer MeshComponent = gameObject.GetComponent<MeshRenderer>();//se encuentra el renderer
        distance = Vector3.Distance(Player.transform.position, transform.position);//se setea el que el valor de la distancia es la distancia entre el objeto y el jugador


        if (distance < availableDistance)//si la distancia es menor a la distancia permitida
        {
            visibilidad.enabled = true;//el renderer se vuelve true(no se ve)
        }
        if (distance > availableDistance)//si la distancia es mayor a la permitida
        {
            visibilidad.enabled = false;//el renderer se vuelve false(se ve)
        }
    }

    private void FollowingBehaviour()
    {
        if (player != null)//si player es distinto de null
        {
            agent.SetDestination(player.transform.position);//el enemigo utiliza el navmesh para seguir la posición en la que se encuentra el jugador
        }
    }

}
