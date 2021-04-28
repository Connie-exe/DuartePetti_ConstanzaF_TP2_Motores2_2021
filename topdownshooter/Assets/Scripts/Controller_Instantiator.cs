using System.Collections.Generic;
using UnityEngine;

public class Controller_Instantiator : MonoBehaviour
{
    public List<GameObject> enemies;//se declara una lista con los enemigos
    public GameObject instantiatePos;//se declara el lugar donde aparecerán los objetos en unity
    public float timer = 7;//se declara un timer y vale 7 float porque el tiempo no es excato (como un int) y public para poder modificarlo desde unity
    private float time = 0;//se declara el tiempo y vale 0
    private int multiplier = 20;//se declara un multiplicador que vale 20

    void Update()
    {
        timer -= Time.deltaTime;//la variable timer va disminuyendo a medida que pasa el tiempo en la consola
        SpawnEnemies();//se llama la clase SpawnEnemies
        ChangeVelocity();//se llama la clase ChangeVelocity
    }

    private void ChangeVelocity()
    {
        time += Time.deltaTime;//la variable time aumenta a medida que pasa le tiempo en la consola
        if (time > multiplier)//si time es mayor a multiplier
        {
            multiplier *= 2; //se duplica multiplier
        }
    }

    private void SpawnEnemies()
    {
        if (timer <= 0)//si timer es menor o igual a 0
        {
            float offsetX = instantiatePos.transform.position.x;//se declara un float offsetX que es igual a la posición de la posición del instantiatePos en el eje x en unity
            int rnd = UnityEngine.Random.Range(0, enemies.Count);//se declara un int (rnd) que genera un número random entre 0 y el número máximo de enemigos que hay en la lista enemies
            for (int i = 0; i < 5; i++)//i comienza valiendo 0, hata que i sea menor a 5, i irá aumentando de a uno
            {
                offsetX = offsetX + 4;// la posición de spawn de los enemigos variará por 4 en el eje x
                Vector3 transform = new Vector3(offsetX, instantiatePos.transform.position.y, instantiatePos.transform.position.z);//aquí se declara la nueva posición del instantiate en el entorno 3d de unity
                Instantiate(enemies[rnd], transform, Quaternion.identity);//esto permite que los enemigos spwneen en random lugares sin repetición
            }
            timer = 7;//una vez que termine el for el timer valdrá 7 y saldrá del if
        }
    }
}
