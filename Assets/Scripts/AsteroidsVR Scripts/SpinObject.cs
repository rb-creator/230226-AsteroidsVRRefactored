using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinObject : MonoBehaviour
{
    public Vector3 rotationAxis;
    public float spinSpeed = 10.5f;
    public bool rotateAroundLocal = false;

    void Update()
    {
        // transform.Rotate(0, spinSpeed * Time.deltaTime, 0);
        if (rotateAroundLocal == true)
        {
            transform.Rotate(rotationAxis, spinSpeed * Time.deltaTime, Space.Self);
        }
        
        else
        {
            transform.Rotate (rotationAxis, spinSpeed * Time.deltaTime, Space.World);
        }
    }
}
