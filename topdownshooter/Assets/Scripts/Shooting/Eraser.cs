using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eraser : MonoBehaviour
{
    public GameObject eraser;
    public Transform firePoint;
    public Text powerUpText;
    public float timeUp = 3f;
    public float timeEraser;
    void Start()
    {
        timeEraser = 0f;
        timeUp = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        PlaceBar();
    }
    public void PlaceBar()
    {
        if (Input.GetKeyDown(KeyCode.Alpha7) && timeEraser <= timeUp)
        {
            Debug.Log("7 pressed");
            GameObject bullet = Instantiate(eraser, firePoint.position, firePoint.rotation);//el gameobject bullet es igual a el bullet prefab en la posición del firepoint y con la rotación de firepoint
            //Rigidbody rb = bullet.GetComponent<Rigidbody>();//rigidbody es igual a el rigidbody de bullet
            powerUpText.text = "Gun: ERASER - Ammo:∞";

        }
        timeEraser += Time.deltaTime;
        if (timeEraser >= timeUp)
        {
            timeEraser = 0f;
            eraser.SetActive(false);
        }

    }
}
