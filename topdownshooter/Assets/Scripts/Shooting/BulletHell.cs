using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletHell : MonoBehaviour
{
    //public GameObject hellbullet;
    //public Transform firePoint;
    //public Transform firePoint1;
    //public Transform firePoint2;
    //public float bulletForce = 20f;
    public Text powerUpText;
    public int numberOfProjectiles;
    public float projectileSpeed;
    public GameObject hellbullet;

    private Vector3 startPos;
    private const float radius = 1f;
    void Start()
    {
        
    }

    void Update()
    {
        //PressedKey();
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            startPos = transform.position;
            SpawnProjectile(numberOfProjectiles);
        }
     
    }

    public void PressedKey()
    {
        //if (Input.GetKeyDown(KeyCode.Alpha5))
        //{
        //    Debug.Log("5 pressed");
        //    GameObject bullet = Instantiate(hellbullet, firePoint.position, firePoint.rotation);//el gameobject bullet es igual a el bullet prefab en la posición del firepoint y con la rotación de firepoint 
        //    GameObject bullet1 = Instantiate(hellbullet, firePoint1.position, firePoint1.rotation);
        //    GameObject bullet2 = Instantiate(hellbullet, firePoint2.position, firePoint2.rotation);
        //    Rigidbody rb = bullet.GetComponent<Rigidbody>();//rigidbody es igual a el rigidbody de bullet
        //    Rigidbody rb1 = bullet1.GetComponent<Rigidbody>();
        //    Rigidbody rb2 = bullet2.GetComponent<Rigidbody>();
        //    rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
        //    rb1.AddForce(firePoint1.forward * bulletForce, ForceMode.Impulse);
        //    rb2.AddForce(firePoint2.forward * bulletForce, ForceMode.Impulse);//el rigidbody se mueve hacia adelante con la fuerza de bullet
        //    powerUpText.text = "Gun: BULLET HELL - Ammo:∞";

        //}

    }

    private void SpawnProjectile(int numberOfProjectiles)
    {
        float angleShoot = 360 / numberOfProjectiles;
        float angle = 0f;
        for(int i = 0; i <= numberOfProjectiles - 1; i++)
        {
            float projectileXPos = startPos.x + Mathf.Sin((angle * Mathf.PI) / 180 * radius);
            float projectileYPos = startPos.x + Mathf.Cos((angle * Mathf.PI) / 180 * radius);

            Vector3 projectileVector = new Vector3(projectileXPos, projectileYPos,0);
            Vector3 projectileMoveDirection = (projectileVector - startPos).normalized * projectileSpeed;

            GameObject obj = Instantiate(hellbullet, startPos, Quaternion.identity);
            obj.GetComponent<Rigidbody>().velocity = new Vector3(projectileMoveDirection.x, 0, projectileMoveDirection.y);

            angle += angleShoot;
        }
        powerUpText.text = "Gun: BULLET HELL - Ammo:∞";
    }
}
