using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProtectorDome : MonoBehaviour
{
    public float timeUp = 3f;
    public float timeDome;
    public GameObject _dome;
    public Text powerUpText;
    void Start()
    {
        timeDome = 0f;
        timeUp = 3f;        
    }

    // Update is called once per frame
    void Update()
    {
        ActivateDome();
    }

    public void ActivateDome()
    {
        if (Input.GetKeyDown(KeyCode.Alpha6) && timeDome <= timeUp)
        {
            Debug.Log("6 pressed");
            _dome.SetActive(true);
            powerUpText.text = "Gun: DOME - Ammo:∞";
        }
        timeDome += Time.deltaTime;
        if (timeDome >= timeUp)
        {
            timeDome = 0f;
            _dome.SetActive(false);
        }
    }
}
