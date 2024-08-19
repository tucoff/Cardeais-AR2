using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetectCards : MonoBehaviour
{
    public TextMeshProUGUI posText;
    public TextMeshProUGUI posFullLife;
    string invocado = "Nenhum";

    public int campo = 0; // 0 = N, 1 = L, 2 = S, 3 = O
    public int pos = 0; // 0 = Atk, 1 = Def

    void Start()
    {
        posText.text = "Nenhum";
    }

    void OnTriggerEnter(Collider other)
    {
        invocado = other.gameObject.name;
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
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == invocado)
        {
            invocado = "Nenhum";
            posText.text = "Nenhum";
            posFullLife.text = "0";
            switch (campo) 
            {
                case 0:
                    if(pos == 0)
                    {GameObject.FindWithTag("Simulation").GetComponent<SimulationBehaviour>().campoNAtkPos = "";}
                    else
                    {GameObject.FindWithTag("Simulation").GetComponent<SimulationBehaviour>().campoNDefPos = "";}
                    break;            
                case 1:
                    if(pos == 0)
                    {GameObject.FindWithTag("Simulation").GetComponent<SimulationBehaviour>().campoSAtkPos = "";}
                    else
                    {GameObject.FindWithTag("Simulation").GetComponent<SimulationBehaviour>().campoSDefPos = "";}
                    break;            
                case 2:
                    if(pos == 0)
                    {GameObject.FindWithTag("Simulation").GetComponent<SimulationBehaviour>().campoLAtkPos = "";}
                    else
                    {GameObject.FindWithTag("Simulation").GetComponent<SimulationBehaviour>().campoLDefPos = "";}
                    break;               
                case 3:
                    if(pos == 0)
                    {GameObject.FindWithTag("Simulation").GetComponent<SimulationBehaviour>().campoOAtkPos = "";}
                    else
                    {GameObject.FindWithTag("Simulation").GetComponent<SimulationBehaviour>().campoODefPos = "";}
                    break;
            }
        }
    }
}
