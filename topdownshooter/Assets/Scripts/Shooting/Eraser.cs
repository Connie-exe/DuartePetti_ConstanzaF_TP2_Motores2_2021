using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//para poder usar la ui

public class Eraser : MonoBehaviour
{
    public GameObject eraser;//se declara el gameobject eraser
    public Transform firePoint;//se declara el lugar de firepoint
    public Text powerUpText;//se delcara el text
    public float timeUp = 3f;//se delcara el tiempo fonal que vale 3f
    public float timeEraser;//se delclara el tiempo del eraser
    void Start()
    {
        timeEraser = 0f;//se inicializa el tiempo del eraser a of
        timeUp = 5f;//se inicializa el tiempo final a 5f
    }

    // Update is called once per frame
    void Update()
    {
        PlaceBar();//se llama a al clase PLaceBar
    }
    public void PlaceBar()
    {
        if (Input.GetKeyDown(KeyCode.Alpha7) && timeEraser <= timeUp)//si se presiona la tecla 7 y el tiempo del eraser es menor o igual al tiempo final
        {
            Debug.Log("7 pressed");//se escribe en consola que se ha presionado el 7
            eraser.SetActive(true);//se activa el gameobjecteraser
            GameObject bullet = Instantiate(eraser, firePoint.position, firePoint.rotation);//el gameobject bullet es igual a el bullet prefab en la posición del firepoint y con la rotación de firepoint
            //Rigidbody rb = bullet.GetComponent<Rigidbody>();//rigidbody es igual a el rigidbody de bullet
            powerUpText.text = "Gun: ERASER - Ammo:∞";//se escribe en pantalla lo que está entre comillas

        }
        timeEraser += Time.deltaTime;//se le suman floats al tiempoeraser a medida que pasa el tiempo en unity
        if (timeEraser >= timeUp)//si tiempo eraser es mayor o igual al tiempo final
        {
            timeEraser = 0f;//timepo eraser pasa a valer 0f
            eraser.SetActive(false);//el gameobject eraser se desactiva en unity
        }

    }
}
