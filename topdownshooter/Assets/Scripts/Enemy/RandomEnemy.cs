using UnityEngine;

public class RandomEnemy : Controller_Enemy
{
    private void FixedUpdate()
    {
        PatrolBehaviour();//se llama a la clase PatrolBehaviour
    }

    private void PatrolBehaviour()
    {
        agent.SetDestination(destination);//se pone una destinaión mediante el nav mesh
        destinationTime -= Time.deltaTime;//el tiempo de destinación disminuye a medida que pasa el tiempo en unity
        if (destinationTime < 0)//si el tiempo de destiación es menor a 0
        {
            destination = new Vector3(Random.Range(-10, 12), 1, Random.Range(-12, 9));//la destinación se define con 2 valores random en el espacio, en sus ejes x y z
            destinationTime = 4;//y el valor del tiempo de destinación pasa a valer 4
        }
    }
}
