using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Classe responsável por detectar a posição de colisão de objetos e atualizar a interface do jogo.
/// </summary>
public class PosDetection : MonoBehaviour
{
    GameObject Table;
    public int cardinalPos;
    public int fightPos;
    string collidedObjName = null;

    private void Start() 
    {
        Table = GameObject.Find("Interface").transform.GetChild(0).GetChild(0).gameObject;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (collidedObjName == null || collidedObjName != other.name)
        {
            Debug.Log(other.name + " em " + transform.name + " em " + transform.parent.parent.name);
            StartCoroutine("debugCd");
            collidedObjName = other.name;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.name == collidedObjName)
        {
            StopAllCoroutines();
            StartCoroutine("exitCd");
            collidedObjName = null;
        }
    }

    /// <summary>
    /// Coroutine que atualiza a interface do jogo após uma colisão.
    /// </summary>
    IEnumerator debugCd ()
    {
        yield return new WaitForSeconds(2);
        Table.transform.GetChild(cardinalPos).GetChild(fightPos).GetComponent<TextMeshProUGUI>().text = collidedObjName;
        Table.transform.parent.GetChild(1).gameObject.SetActive(true);
        GameObject.Find("Simulation").GetComponent<SimulationBehaviour>().StartChanging();

        switch(cardinalPos)
        {
            case 0:
                if (fightPos == 0)
                {
                    GameObject.Find("Simulation").GetComponent<SimulationBehaviour>().campoNAtkPos = collidedObjName;
                }
                else
                {
                    GameObject.Find("Simulation").GetComponent<SimulationBehaviour>().campoNDefPos = collidedObjName;
                }
                break;
            case 2:
                if (fightPos == 0)
                {
                    GameObject.Find("Simulation").GetComponent<SimulationBehaviour>().campoLAtkPos = collidedObjName;
                }
                else
                {
                    GameObject.Find("Simulation").GetComponent<SimulationBehaviour>().campoLDefPos = collidedObjName;
                }
                break;
            case 1:
                if (fightPos == 0)
                {
                    GameObject.Find("Simulation").GetComponent<SimulationBehaviour>().campoSAtkPos = collidedObjName;
                }
                else
                {
                    GameObject.Find("Simulation").GetComponent<SimulationBehaviour>().campoSDefPos = collidedObjName;
                }
                break;
            case 3:
                if (fightPos == 0)
                {
                    GameObject.Find("Simulation").GetComponent<SimulationBehaviour>().campoOAtkPos = collidedObjName;
                }
                else
                {
                    GameObject.Find("Simulation").GetComponent<SimulationBehaviour>().campoODefPos = collidedObjName;
                }
                break;
        }
    }
    
    /// <summary>
    /// Coroutine que restaura a interface do jogo após a saída de um objeto da colisão.
    /// </summary>
    IEnumerator exitCd ()
    {
        yield return new WaitForSeconds(2f);
        Table.transform.GetChild(cardinalPos).GetChild(fightPos).GetComponent<TextMeshProUGUI>().text = "";
        Table.transform.parent.GetChild(1).gameObject.SetActive(true);
        GameObject.Find("Simulation").GetComponent<SimulationBehaviour>().StartChanging();

        switch(cardinalPos)
        {
            case 0:
                if (fightPos == 0)
                {
                    GameObject.Find("Simulation").GetComponent<SimulationBehaviour>().campoNAtkPos = "";
                }
                else
                {
                    GameObject.Find("Simulation").GetComponent<SimulationBehaviour>().campoNDefPos = "";
                }
                break;
            case 1:
                if (fightPos == 0)
                {
                    GameObject.Find("Simulation").GetComponent<SimulationBehaviour>().campoLAtkPos = "";
                }
                else
                {
                    GameObject.Find("Simulation").GetComponent<SimulationBehaviour>().campoLDefPos = "";
                }
                break;
            case 2:
                if (fightPos == 0)
                {
                    GameObject.Find("Simulation").GetComponent<SimulationBehaviour>().campoSAtkPos = "";
                }
                else
                {
                    GameObject.Find("Simulation").GetComponent<SimulationBehaviour>().campoSDefPos = "";
                }
                break;
            case 3:
                if (fightPos == 0)
                {
                    GameObject.Find("Simulation").GetComponent<SimulationBehaviour>().campoOAtkPos = "";
                }
                else
                {
                    GameObject.Find("Simulation").GetComponent<SimulationBehaviour>().campoODefPos = "";
                }
                break;
        }
    }
}
