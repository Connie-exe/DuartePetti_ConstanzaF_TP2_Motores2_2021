using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowCam : MonoBehaviour
{
    public float timeUp = 3f; //float que indica cuánto tiempo durará el slowmotion
    public float timeSlowMotion;//float del tiempo de slowmotion transcurrido
    void Start()
    {
        timeSlowMotion = 0f;
        timeUp = 3f;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        SlowMotion();
    }

    public void SlowMotion()
    {
        {
            if (Input.GetKeyDown(KeyCode.U) && timeSlowMotion <= timeUp && Time.timeScale == 1f)//si se toca la tecla u y el tiempo de slowmotion es menor o igual al tiempofonal y el "tiempo" en unity transucrre con normalidad
            {
                Debug.Log("U pressed");//se ve en consola el mensaje entre comillas
                Time.timeScale = 0.3f;// el tiempo en consola se ralentiza
            }
            timeSlowMotion += Time.deltaTime;//se va sumando float a la variable a medida que pasa el tiempo
            if (timeSlowMotion >= timeUp)//si el tiempo en slow motion es mayor o igual al tiempo final
            {
                Time.timeScale = 1f;//el tiempo en consola vuelve a la normalidad
                timeSlowMotion = 0f;//el tiempo slow motion vuelve a valer 0
            }
        }
        
    }
}
