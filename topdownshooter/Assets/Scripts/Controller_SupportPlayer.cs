using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_SupportPlayer : MonoBehaviour
{
    private Vector3 movement;
    private Vector3 mousePos;
    private Rigidbody rb;
    public float speed = 5;
    internal Vector3 shootAngle;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");//el movimiento en el eje x va a ser controlado por los comandos axis "horizontal" (a,d)
        movement.z = Input.GetAxis("Vertical");//el movimiento en el eje x va a ser controlado por los comandos axis "horizontal" (w,s)
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//permite que el mouse se mueva en el mundo
    }
    public virtual void FixedUpdate()
    {
        Movement(); //llama a la clase Movement
    }

    private void Movement()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);//el rigidbody se moverá a cierta velocidad relacionada también con el tiempo en unity
        transform.LookAt(new Vector3(mousePos.x, 1, mousePos.z));//permite al rigidbody rotar sobre el eje y
    }

    public Vector3 GetLastAngle()
    {
        if (Input.GetKey(KeyCode.T))//si el usuario apreta la tecla w
        {
            shootAngle = Vector3.forward;//el ángulo del disparo a hacia adelante
        }
        if (Input.GetKey(KeyCode.F))//si el usuario apreta la tecla a
        {
            shootAngle = Vector3.left;//el ángulo del disparo a hacia la izquierda
        }
        if (Input.GetKey(KeyCode.G))//si el usuario apreta la tecla s
        {
            shootAngle = Vector3.back;//el ángulo del disparo a hacia abajo
        }
        if (Input.GetKey(KeyCode.H))//si el usuario apreta la tecla d
        {
            shootAngle = Vector3.right;//el ángulo del disparo a hacia la derecha
        }
        return shootAngle;//devuelve el valor de shootAngle
    }
}
