using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SimulationBehaviour : MonoBehaviour
{
    bool isChanging = false; // Variável que indica se a animação de mudança está ocorrendo
    int round = 0; // Número do round atual
    [SerializeField] int turn = 0; // 0 = N, 1 = L, 2 = S, 3 = O
    
    // Campo Norte
    public string campoNAtkPos = ""; // Posição de ataque no campo Norte
    public string campoNDefPos = ""; // Posição de defesa no campo Norte

    // Campo Sul
    public string campoSAtkPos = ""; // Posição de ataque no campo Sul
    public string campoSDefPos = ""; // Posição de defesa no campo Sul

    // Campo Leste
    public string campoLAtkPos = ""; // Posição de ataque no campo Leste
    public string campoLDefPos = ""; // Posição de defesa no campo Leste
    
    // Campo Oeste
    public string campoOAtkPos = ""; // Posição de ataque no campo Oeste
    public string campoODefPos = ""; // Posição de defesa no campo Oeste

    // Verificações de cartas invocadas
    public GameObject[] cSpawned; // 0,1 = N, 2,3 = L, 4,5 = S, 6,7 = O
    public Transform[] cPos; // 0,1 = N, 2,3 = L, 4,5 = S, 6,7 = O
    public bool[] cAlive; // 0 = N, 1 = L, 2 = S, 3 = O
    public Camera[] cameras; // 0 = N, 1 = L, 2 = S, 3 = O, 4 = Top, 5 = AR

    public TextMeshProUGUI roundText; // Texto que exibe o número do round
    public TextMeshProUGUI turnText; // Texto que exibe a direção do turno

    private void FixedUpdate() 
    {
        roundText.text = "Round: " + round; // Atualiza o texto do round
        switch(turn)
        {
            case 0:
                if(cAlive[0])
                {
                    turnText.text = "Turn: Norte"; // Atualiza o turno para "Norte"
                }
                else {turn++;}
                break;
            case 1:
                if(cAlive[1])
                {
                    turnText.text = "Turn: Leste"; // Atualiza o turno para "Leste"
                }
                else {turn++;}
                break;
            case 2:
                if(cAlive[2])
                {
                    turnText.text = "Turn: Sul"; // Atualiza o turno para "Sul"
                }
                else {turn++;}
                break;
            case 3:
                if(cAlive[3])
                {
                    turnText.text = "Turn: Oeste"; // Atualiza o turno para "Oeste"
                }
                else {turn = 0;}
                break;
            default:
                turn = 10;
            break;
        }
    }

    public void ShuffleTurn()
    {
        // Gira aleatoriamente o turno
        turn = Random.Range(0, 4);
    }

    public void setCampoNAlive()
    {
        cAlive[0] = true;
    }
    public void setCampoLAlive()
    {
        cAlive[1] = true;
    }
    public void setCampoSAlive()
    {
        cAlive[2] = true;
    }
    public void setCampoOAlive()
    {
        cAlive[3] = true;
    }
    public void setCampoNDead()
    {
        cAlive[0] = false;
    }
    public void setCampoLDead()
    {
        cAlive[1] = false;
    }
    public void setCampoSDead()
    {
        cAlive[2] = false;
    }
    public void setCampoODead()
    {
        cAlive[3] = false;
    }
}
