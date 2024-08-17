using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SimulationBehaviour : MonoBehaviour
{
    bool isChanging = false; // Variável que indica se a animação de mudança está ocorrendo
    int round = 0; // Número do round atual
    [SerializeField] int turn = 0; // 0 = N, 1 = L, 2 = S, 3 = O

    [SerializeField] GameObject[] allCardsModels; // Array com os modelos de todas as cartas
    
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

    public void EndedChanging()
    {
        if(isChanging)
        {
            cameras[5].enabled = false; // Desativa a câmera de AR
            cameras[4].enabled = true; // Ativa a câmera de cima
            StartCoroutine(SpawnAnimation());
        }
    }

    IEnumerator SpawnAnimation()
    {
        yield return new WaitForSeconds(2);
        cameras[4].enabled = false; // Desativa a câmera de cima
        cameras[turn].enabled = true; // Ativa a câmera da direção do turno atual
        yield return new WaitForSeconds(1);
        foreach(GameObject card in allCardsModels)
            {
                if((card.name == campoNAtkPos) && (!cSpawned[0]))
                {
                    GameObject newCard = Instantiate(card, cPos[0].position, card.transform.rotation * Quaternion.Euler(0, 180,0));
                    newCard.transform.GetChild(1).transform.localRotation = Quaternion.Euler(
                        newCard.transform.GetChild(1).transform.localRotation.eulerAngles.x,
                        newCard.transform.GetChild(1).transform.localRotation.eulerAngles.y,
                        180);
                    newCard.transform.GetChild(1).transform.localPosition += new Vector3(0.1f, 0f, 3f);
                    cSpawned[0] = newCard;
                }
                else if (campoNAtkPos == "" && cSpawned[0] != null)
                {
                    Destroy(cSpawned[0]);
                    cSpawned[0] = null;
                }
                
                if((card.name == campoNDefPos) && (!cSpawned[1]))
                {
                    GameObject newCard = Instantiate(card, cPos[1].position, card.transform.rotation * Quaternion.Euler(0, 180,0));
                    newCard.transform.GetChild(1).transform.localRotation = Quaternion.Euler(
                    newCard.transform.GetChild(1).transform.localRotation.eulerAngles.x,
                    newCard.transform.GetChild(1).transform.localRotation.eulerAngles.y,
                    180);
                    newCard.transform.GetChild(1).transform.localPosition += new Vector3(0.1f, 0f, 3);
                    cSpawned[1] = newCard;
                }
                else if (campoNDefPos == "" && cSpawned[1] != null)
                {
                    Destroy(cSpawned[1]);
                    cSpawned[1] = null;
                }   
                
                if((card.name == campoLAtkPos) && (!cSpawned[2]))
                {
                    GameObject newCard = Instantiate(card, cPos[2].position, card.transform.rotation * Quaternion.Euler(0, 270,0));
                    newCard.transform.GetChild(1).transform.localRotation = Quaternion.Euler(
                    newCard.transform.GetChild(1).transform.localRotation.eulerAngles.x,
                    newCard.transform.GetChild(1).transform.localRotation.eulerAngles.y,
                    270);
                    newCard.transform.GetChild(1).transform.position += new Vector3(-2.5f, 0f, -2.5f);
                    cSpawned[2] = newCard;
                }
                else if (campoLAtkPos == "" && cSpawned[2] != null)
                {
                    Destroy(cSpawned[2]);
                    cSpawned[2] = null;
                }
                
                if((card.name == campoLDefPos) && (!cSpawned[3]))
                {
                    GameObject newCard = Instantiate(card, cPos[3].position, card.transform.rotation * Quaternion.Euler(0, 270,0));
                    newCard.transform.GetChild(1).transform.localRotation = Quaternion.Euler(
                    newCard.transform.GetChild(1).transform.localRotation.eulerAngles.x,
                    newCard.transform.GetChild(1).transform.localRotation.eulerAngles.y,
                    270);
                    newCard.transform.GetChild(1).transform.position += new Vector3(-2.5f, 0f, -2.5f);
                    cSpawned[3] = newCard;
                }
                else if (campoLDefPos == "" && cSpawned[3] != null)
                {
                    Destroy(cSpawned[3]);
                    cSpawned[3] = null;
                }
                
                if((card.name == campoSAtkPos) && (!cSpawned[4]))
                {
                    GameObject newCard = Instantiate(card, cPos[4].position, card.transform.rotation * Quaternion.Euler(0, 0,0));
                    newCard.transform.GetChild(1).transform.localPosition += new Vector3(0f, 0f, 3.4f);
                    cSpawned[4] = newCard;
                }
                else if (campoSAtkPos == "" && cSpawned[4] != null)
                {
                    Destroy(cSpawned[4]);
                    cSpawned[4] = null;
                }
                
                if((card.name == campoSDefPos) && (!cSpawned[5]))
                {
                    GameObject newCard = Instantiate(card, cPos[5].position, card.transform.rotation * Quaternion.Euler(0, 0,0));
                    newCard.transform.GetChild(1).transform.localPosition += new Vector3(0f, 0f, 3.4f);
                    cSpawned[5] = newCard;
                }
                else if (campoSDefPos == "" && cSpawned[5] != null)
                {
                    Destroy(cSpawned[5]);
                    cSpawned[5] = null;
                }
                
                if((card.name == campoOAtkPos) && (!cSpawned[6]))
                {
                    GameObject newCard = Instantiate(card, cPos[6].position, card.transform.rotation * Quaternion.Euler(0, 90,0));
                    newCard.transform.GetChild(1).transform.localRotation = Quaternion.Euler(
                    newCard.transform.GetChild(1).transform.localRotation.eulerAngles.x,
                    newCard.transform.GetChild(1).transform.localRotation.eulerAngles.y,
                    90);
                    newCard.transform.GetChild(1).transform.localPosition += new Vector3(-1.8f, 0f, 1.7f);
                    cSpawned[6] = newCard;
                }
                else if (campoOAtkPos == "" && cSpawned[6] != null)
                {
                    Destroy(cSpawned[6]);
                    cSpawned[6] = null;
                }
                
                if((card.name == campoODefPos) && (!cSpawned[7]))
                {
                    GameObject newCard = Instantiate(card, cPos[7].position, card.transform.rotation * Quaternion.Euler(0, 90,0));
                    newCard.transform.GetChild(1).transform.localRotation = Quaternion.Euler(
                    newCard.transform.GetChild(1).transform.localRotation.eulerAngles.x,
                    newCard.transform.GetChild(1).transform.localRotation.eulerAngles.y,
                    90);
                    newCard.transform.GetChild(1).transform.localPosition += new Vector3(-1.8f, 0f, 1.7f);
                    cSpawned[7] = newCard;
                }
                else if (campoODefPos == "" && cSpawned[7] != null)
                {
                    Destroy(cSpawned[7]);
                    cSpawned[7] = null;
                }                
            }
        yield return new WaitForSeconds(4);
        cameras[turn].enabled = false; // Desativa a câmera da direção do turno atual
        cameras[5].enabled = true; // Ativa a câmera de AR
        turn++;
        if(turn >= 4){turn = 0;}
        round++;
        isChanging = false;
    }

    public void StartChanging()
    {
        if(!isChanging)
        {
            isChanging = true;
        }
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
