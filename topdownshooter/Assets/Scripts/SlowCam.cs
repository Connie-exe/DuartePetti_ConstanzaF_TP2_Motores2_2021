using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowCam : MonoBehaviour
{
    public float timeUp = 3f;
    public float timeSlowMotion;
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
        //if (Time.timeScale == 1f)
        {
            if (Input.GetKeyDown(KeyCode.U) && timeSlowMotion <= timeUp && Time.timeScale == 1f)
            {
                Debug.Log("U pressed");
                Time.timeScale = 0.3f;  
            }
            timeSlowMotion += Time.deltaTime;
            if (timeSlowMotion >= timeUp)
            {
                Time.timeScale = 1f;
                timeSlowMotion = 0f;
            }
        }
        
    }
}
