using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float rotationSpeed = 50f;
    void FixedUpdate()
    {
        transform.Rotate(0, Time.deltaTime * rotationSpeed, 0);
    }
}
