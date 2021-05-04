using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//para poder usar la ui

public class ZombieGun : MonoBehaviour
{
    public GameObject zombiebullet;//se declara el obejecto zombiebullet
    public Transform firePoint;//se declara el lugar de firepoint
    public float bulletForce = 20f;//se declara la fuerza de la bala
    public Text powerUpText;//se declara un text
    void Start()
    {
        
    }

    void Update()
    {
        PressedKey();//se llama a la clase presserkey
    }

    public void PressedKey()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))//se se presiona la tela 4
        {
            Debug.Log("4 pressed");//se escribe en consola que 4 ha sido presionado         
            GameObject bullet = Instantiate(zombiebullet, firePoint.position, firePoint.rotation);//el gameobject bullet es igual a el bullet prefab en la posición del firepoint y con la rotación de firepoint 
            Rigidbody rb = bullet.GetComponent<Rigidbody>();//rigidbody es igual a el rigidbody de bullet
            rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);//el rigidbody se mueve hacia adelante con la fuerza de bullet
            powerUpText.text = "Gun: ZOMBIE ATTACK - Ammo:∞";//se escribe en la panalla lo que está entre comillas

        }
    }

}
