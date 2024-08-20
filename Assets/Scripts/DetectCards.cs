using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetectCards : MonoBehaviour
{
    public TextMeshProUGUI posText;
    public TextMeshProUGUI posFullLife;
    CardAttributes invocado = null;

    public int campo = 0; // 0 = N, 1 = L, 2 = S, 3 = O
    public int pos = 0; // 0 = Atk, 1 = Def

    void Start()
    {
        posText.text = "Nenhum";
    }

    void OnTriggerEnter(Collider other)
    {
        invocado = other.gameObject.GetComponent<CardAttributes>();
        posText.text = other.gameObject.name;
        posFullLife.text = other.gameObject.GetComponent<CardAttributes>().getLife().ToString();
        switch (campo) 
        {
            case 0:
                if(pos == 0)
                {GameObject.FindWithTag("Simulation").GetComponent<SimulationBehaviour>().campoNAtkPos = invocado;}
                else
                {GameObject.FindWithTag("Simulation").GetComponent<SimulationBehaviour>().campoNDefPos = invocado;}
                break;            
            case 1:
                if(pos == 0)
                {GameObject.FindWithTag("Simulation").GetComponent<SimulationBehaviour>().campoSAtkPos = invocado;}
                else
                {GameObject.FindWithTag("Simulation").GetComponent<SimulationBehaviour>().campoSDefPos = invocado;}
                break;            
            case 2:
                if(pos == 0)
                {GameObject.FindWithTag("Simulation").GetComponent<SimulationBehaviour>().campoLAtkPos = invocado;}
                else
                {GameObject.FindWithTag("Simulation").GetComponent<SimulationBehaviour>().campoLDefPos = invocado;}
                break;               
            case 3:
                if(pos == 0)
                {GameObject.FindWithTag("Simulation").GetComponent<SimulationBehaviour>().campoOAtkPos = invocado;}
                else
                {GameObject.FindWithTag("Simulation").GetComponent<SimulationBehaviour>().campoODefPos = invocado;}
                break;
        }
        other.gameObject.GetComponent<CardAttributes>().resetCurrentLife();
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<CardAttributes>() == invocado)
        {
            invocado = null;
            posText.text = "Nenhum";
            posFullLife.text = "0";
            switch (campo) 
            {
                case 0:
                    if(pos == 0)
                    {GameObject.FindWithTag("Simulation").GetComponent<SimulationBehaviour>().campoNAtkPos = null;}
                    else
                    {GameObject.FindWithTag("Simulation").GetComponent<SimulationBehaviour>().campoNDefPos = null;}
                    break;            
                case 1:
                    if(pos == 0)
                    {GameObject.FindWithTag("Simulation").GetComponent<SimulationBehaviour>().campoSAtkPos = null;}
                    else
                    {GameObject.FindWithTag("Simulation").GetComponent<SimulationBehaviour>().campoSDefPos = null;}
                    break;            
                case 2:
                    if(pos == 0)
                    {GameObject.FindWithTag("Simulation").GetComponent<SimulationBehaviour>().campoLAtkPos = null;}
                    else
                    {GameObject.FindWithTag("Simulation").GetComponent<SimulationBehaviour>().campoLDefPos = null;}
                    break;               
                case 3:
                    if(pos == 0)
                    {GameObject.FindWithTag("Simulation").GetComponent<SimulationBehaviour>().campoOAtkPos = null;}
                    else
                    {GameObject.FindWithTag("Simulation").GetComponent<SimulationBehaviour>().campoODefPos = null;}
                    break;
            }
        }
    }
}
