using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieHunter : MonoBehaviour
{

    internal GameObject closest;//se declara que el gameobject closest
    internal NavMeshAgent zombieHunter;//se delcara un navmesh para zombieHunter
    void Start()
    {
        zombieHunter = GetComponent<NavMeshAgent>();//se llama al navmesh de zombiehunter
    }

    // Update is called once per frame
    void Update()
    {
        FindClosestAlly();//se llama a la clase FindClosestAlly
        FollowingBehaviour();//se llama a la clase FollowingBehaviour
    }
    public GameObject FindClosestAlly()
    {
        GameObject[] gos;//se declara una lista de gameobjects
        gos = GameObject.FindGameObjectsWithTag("Ally");//dentro de la lista van todos los gameobjects con etiqueta "Ally"
        closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)//si la distancia actual es menor a la distancia permitida
            {
                closest = go;//el objeto más cercano irá a la lista de gos
                Debug.Log("Ally Detected");//se escribirá en consola que se ha detectado al aliado
                distance = curDistance;//la distancia permitida ahora vale la distancia actual
            }
        }
        return closest;//retorna el valor de closest
    }

    private void FollowingBehaviour()
    {
        if (closest != null)//si closest es distinto de null
        {
            zombieHunter.SetDestination(closest.transform.position);//el enemigo utiliza el navmesh para seguir la posición en la que se encuentra el aliado
        }
    }
    public void OnCollisionEnter(Collision collision)//si collisiona con...
    {
        if (collision.gameObject.CompareTag("Ally"))//con un objeto con etiqueta Projectile
        {
            Destroy(collision.gameObject);//se destruye el objeto con el que se colisiona
            Destroy(this.gameObject);//se destruye este objeto
        }
    }
}
