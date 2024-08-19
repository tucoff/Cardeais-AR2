using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCards : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Card Detected: " + other.gameObject.name);
    }
}
