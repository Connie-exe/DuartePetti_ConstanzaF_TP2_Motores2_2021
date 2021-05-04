using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//para poder usar la ui

public class ProtectorDome : MonoBehaviour
{
    public float timeUp = 3f;//se declara el tiempo final con un valor de 3f
    public float timeDome;//se declara el tiempo del domo
    public GameObject _dome;//se declara el gameobject _dome
    public Text powerUpText;//se declara el text
    void Start()
    {
        timeDome = 0f;//se inicializa el tiempo del domo a 0f
        timeUp = 5f;//se inicializa el tiempo final a 3f 
    }

    // Update is called once per frame
    void Update()
    {
        ActivateDome();//se llama a la clase ActivateDome
    }

    public void ActivateDome()
    {
        if (Input.GetKeyDown(KeyCode.Alpha6) && timeDome <= timeUp)//si se preiosna la tecla 6 y el tiempo del domo es menor o igual al timepo final
        {
            Debug.Log("6 pressed");//se escribe en consola que 6 ha sido presionado
            _dome.SetActive(true);//se activa el gamobeject domo
            powerUpText.text = "Gun: DOME - Ammo:∞";//se escribe en la pantalla lo que está entre comillas
        }
        timeDome += Time.deltaTime;//se le suman floats al tiempo del domo a medidad que pasa el tiempo en unity
        if (timeDome >= timeUp)//si el tiempo del domo es mayor o igual al timepo final
        {
            timeDome = 0f;//el timepo del domo pasa a valer 0f
            _dome.SetActive(false);//se desactiva en gameobject domo
        }
    }
}
