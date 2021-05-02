using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieGun : MonoBehaviour
{
    public GameObject zombiebullet;
    public Transform firePoint;
    public float bulletForce = 20f;
    public Text powerUpText;
    void Start()
    {
        
    }

    void Update()
    {
        PressedKey();
    }

    public void PressedKey()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("4 pressed");            
            GameObject bullet = Instantiate(zombiebullet, firePoint.position, firePoint.rotation);//el gameobject bullet es igual a el bullet prefab en la posición del firepoint y con la rotación de firepoint 
            Rigidbody rb = bullet.GetComponent<Rigidbody>();//rigidbody es igual a el rigidbody de bullet
            rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);//el rigidbody se mueve hacia adelante con la fuerza de bullet
            powerUpText.text = "Gun: ZOMBIE ATTACK - Ammo:∞";

        }
    }

}
