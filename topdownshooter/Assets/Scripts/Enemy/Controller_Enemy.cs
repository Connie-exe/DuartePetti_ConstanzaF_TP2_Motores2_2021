using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;//para poder usar la ai

public class Controller_Enemy : MonoBehaviour
{
    public static int numPatroler;//se declara un static para que se pueda usar en más scripts
    internal GameObject player;//se declara al jugador en su forma no observable
    internal NavMeshAgent agent;//se declara navmesh en su forma no observable
    internal Renderer render;//se declara al renderer en su forma no observable
    internal Vector3 destination;//se declara al vector3 destination en su forma no observable
    public float patrolDistance = 5;//un float distancia de patrulla que vale 5
    public float destinationTime = 4;//un float tiempo de destinación que vale 4
    public float enemySpeed;//un float velocidad del enemigo

    void Start()
    {
        render = GetComponent<Renderer>();//se llama al renderer 
        Restart._Restart.OnRestart += Reset;
        destination = new Vector3(UnityEngine.Random.Range(-10, 12), 1, UnityEngine.Random.Range(-12, 9));//el destino del enemigo tiene un valor random en todos sus 3 ejes
        agent = GetComponent<NavMeshAgent>();//se llama al navmeshagent
        player = GameObject.Find("Player");//se llama al objeto con etiqueta player
    }

    public void Reset()
    {
        Destroy(this.gameObject);//si se resetea el juego se destruye el script
    }

    internal virtual void OnCollisionEnter(Collision collision)//si collisiona con...
    {
        if (collision.gameObject.CompareTag("Projectile"))//con un objeto con etiqueta Projectile
        {
            Destroy(collision.gameObject);//se destruye el objeto con el que se colisiona
            Destroy(this.gameObject);//se destruye este objeto
            Controller_Hud.points++;//se agrega 1 punto a la variable points de Controller_Hud
        }
        if (collision.gameObject.CompareTag("CannonBall"))//con un objeto con etiqueta CannonBall
        {
            Destroy(this.gameObject);//se destruye este objeto
            Controller_Hud.points++;//se agrega 1 punto a la variable points de Controller_Hud
        }
        if (collision.gameObject.CompareTag("Bumeran"))//con un objeto con etiqueta Bumeran
        {
            Destroy(this.gameObject);//se destruye este objeto
            Controller_Hud.points++;//se agrega 1 punto a la variable points de Controller_Hud
        }
    }

    private void OnDestroy()//cuando se destruye este script
    {
        Instantiator.enemies.Remove(this);//se remueve el instantiator de enemigos
    }

    private void OnDisable()
    {
        Restart._Restart.OnRestart -= Reset;
    }
}
