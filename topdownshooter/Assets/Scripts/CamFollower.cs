using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollower : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        // Rota la cámara en cada frame así sigue mirando a target
        //transform.LookAt(target);
        transform.LookAt(target, Vector3.zero);
    }
}
