using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
    public static List<Controller_Enemy> enemies;//declara la lista de enemigos del script Controller_Enemy
    public List<GameObject> enemy;//declara la lista de enemigos
    public List<GameObject> positions;//declara la lista de posiciones
    public GameObject powerUp;//declara el gameobject powerup
    private GameObject powerUpInstance;//declara el gameobject powerupInstance
    private float initialWaveDuration, initialAumentedWaveDuration, initialPowerUpTime;//declara 3 floats, uno para el inicio de la ola de enemigos, otro para la duración de la ola y otro para el tiempo de duración del powerup
    public int wave = 1;//declara un int que vale 1 
    public float waveDuration = 5, aumentedWaveDuration = 3, powerUpTime = 10;//declara 3 floats, la duración de la ola (5), el aumento de la ola (3), y el tiempo del powerup (10)

    private void Start()
    {
        enemies = new List<Controller_Enemy>();//inicializa la lista de enemigos
        initialWaveDuration = waveDuration;//la duración de la ola inicial es igual a la duración de la ola
        initialAumentedWaveDuration = aumentedWaveDuration;//el aumento inicial de la duración de la ola es igual al aumento de la duración de la ola
        initialPowerUpTime = powerUpTime;//el tiempo inicial del tiempo del power up es igual al tiempo del power up
        Restart._Restart.OnRestart += Reset;
        SpawnEnemies();//llama a la clase que Spawnenemies
    }

    private void Reset()
    {
        waveDuration = initialWaveDuration; //la duración de la ola es igual a la duración inicial de la ola
        aumentedWaveDuration = initialAumentedWaveDuration;//el aumento de la duración de la ola es igual al aunmento inicial de la duración de la ola
        powerUpTime = initialPowerUpTime;//el tiempo del power up es igual al tiempo inicial del power up
        wave = 1;//la ola pasa a valer 1
        if (powerUpInstance != null)//si el powerupinstance es distinto de null
            Destroy(powerUpInstance);//se destruye el powerupinstance
        foreach (Controller_Enemy c in enemies)
        {
            c.Reset();
        }
        SpawnEnemies();//llama a la clase SpawnEnemies
    }

    private void Update()
    {
        waveDuration -= Time.deltaTime;//la duración de la ola va disminuyendo a medida que pasa el tiempo en unity
        powerUpTime -= Time.deltaTime;//la duración del powerup va disminuyendo a medida que pasa el tiempo en unity
        if (powerUpTime < 0)//si powerup es menor a 0
        {
            SpawnPowerUp();//llama a la clase PowerUp
        }
        if (waveDuration < 0)//si la duración de la ola es menor a 0
        {
            SpawnEnemies();//llama a la clase SpawnEnemies
        }
    }

    private void SpawnEnemies()
    {
        if (!Controller_Hud.gameOver)//si el bool gamover del script Controller_Hud es false
        {
            int enemiesCount = wave * 2;//el contador de enemigos (int) es igual a la ola por 2
            for (int i = 0; i < enemiesCount; i++)//i inicia valiendo 0, hasta que valga la cantidad de enemigos, aumentará de uno en uno en cada vuelta
            {
                int random = UnityEngine.Random.Range(0, positions.Count);//un número random entre 0 y las posiciones
                GameObject enemyInstance = Instantiate(enemy[UnityEngine.Random.Range(0, enemy.Count)], positions[random].transform.position, Quaternion.identity);//aparecen enemigos random en lugares random dentro de los instanciadores
                enemies.Add(enemyInstance.GetComponent<Controller_Enemy>());
            }
            aumentedWaveDuration += 0.3f;//el aumento de la duración de la ola es de +0.3f
            waveDuration = aumentedWaveDuration;//la duración de la ola es igual al aumento de la duración de la ola
            wave++;//la ola aumenta en 1
        }
    }

    private void SpawnPowerUp()
    {
        Vector3 randomizer = new Vector3(UnityEngine.Random.Range(-7, 7), 1, UnityEngine.Random.Range(-7, 7));//se randomiza con dos números random en dónde aparecerá el power up
        powerUpInstance = Instantiate(powerUp, randomizer, Quaternion.identity);//se instancia el powerupinstance con el randomizer
        Destroy(powerUpInstance, 10);//se destruye el powerupintance en 10
        powerUpTime = 20;//el tiempo del powerup vale 20
    }

    private void OnDisable() //si el objeto se destruye
    {
        Restart._Restart.OnRestart -= Reset;//se resetea
    }
}
