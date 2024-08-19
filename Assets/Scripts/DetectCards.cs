using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetectCards : MonoBehaviour
{
    public TextMeshProUGUI posText;
    string invocado = "Nenhum";

    void Start()
    {
        posText.text = "Nenhum";
    }

    void OnTriggerEnter(Collider other)
    {
        invocado = other.gameObject.name;
        posText.text = other.gameObject.name;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == invocado)
        {
            invocado = "Nenhum";
            posText.text = "Nenhum";
        }
    }
}
