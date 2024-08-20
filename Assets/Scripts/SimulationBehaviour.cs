using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SimulationBehaviour : MonoBehaviour
{
    int round = 0; // Número do round atual
    [SerializeField] int turn = 0; // 0 = N, 1 = L, 2 = S, 3 = O
    
    // Campo Norte
    public CardAttributes campoNAtkPos; // Posição de ataque no campo Norte
    public CardAttributes campoNDefPos; // Posição de defesa no campo Norte

    // Campo Sul
    public CardAttributes campoSAtkPos; // Posição de ataque no campo Sul
    public CardAttributes campoSDefPos; // Posição de defesa no campo Sul

    // Campo Leste
    public CardAttributes campoLAtkPos; // Posição de ataque no campo Leste
    public CardAttributes campoLDefPos; // Posição de defesa no campo Leste
    
    // Campo Oeste
    public CardAttributes campoOAtkPos; // Posição de ataque no campo Oeste
    public CardAttributes campoODefPos; // Posição de defesa no campo Oeste

    // Verificações de cartas invocadas
    public TextMeshProUGUI[] cPosLivesText; // 0,1 = N, 2,3 = L, 4,5 = S, 6,7 = O
    public bool[] cAlive; // 0 = N, 1 = L, 2 = S, 3 = O
    public int[] cLives; // 0 = N, 1 = L, 2 = S, 3 = O
    public TextMeshProUGUI[] cLivesText; // 0 = N, 1 = L, 2 = S, 3 = O
    public TextMeshProUGUI roundText; // Texto que exibe o número do round
    public TextMeshProUGUI turnText; // Texto que exibe a direção do turno
    int attksPerRound = 0; // Número de ataques por round

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

    public GameObject regS = null;
    public void OpenCloseR() 
    {
        if (regS.activeSelf)
        {
            regS.SetActive(false);
        }
        else
        {
            regS.SetActive(true);
        }
    }

    public GameObject newTurnR = null;
    public void NextTurn()
    {
        string campoAtacadoS = "";
        switch(campoAtacado)
        {
            case 0:
                campoAtacadoS = "Norte";
                break;
            case 1:
                campoAtacadoS = "Leste";
                break;
            case 2:
                campoAtacadoS = "Sul";
                break;
            case 3:
                campoAtacadoS = "Oeste";
                break;
            default:
                campoAtacadoS = "Nenhum";
                break;
        }
        int danoCausado = 0;
        campoAtacado = 5;

        string atkPosT = "";
        string defPosT = "";
        string turnS = "";
        switch(turn)
        {
            case 0:
                turnS = "Norte";
                if(campoNAtkPos == null) {atkPosT = "Nenhuma";} else {atkPosT = campoNAtkPos.getCardName(); if(campoAtacadoS != "Nenhum"){danoCausado = campoNAtkPos.getDamage();} }
                if(campoNDefPos == null) {defPosT = "Nenhuma";} else {defPosT = campoNDefPos.getCardName(); }
                break;
            case 1:
                turnS = "Leste";
                if(campoLAtkPos == null) {atkPosT = "Nenhuma";} else {atkPosT = campoLAtkPos.getCardName(); if(campoAtacadoS != "Nenhum"){danoCausado = campoLAtkPos.getDamage();} }
                if(campoLDefPos == null) {defPosT = "Nenhuma";} else {defPosT = campoLDefPos.getCardName();}
                break;
            case 2:
                turnS = "Sul";
                if(campoSAtkPos == null) {atkPosT = "Nenhuma";} else {atkPosT = campoSAtkPos.getCardName(); if(campoAtacadoS != "Nenhum"){danoCausado = campoSAtkPos.getDamage();} }
                if(campoSDefPos == null) {defPosT = "Nenhuma";} else {defPosT = campoSDefPos.getCardName();}
                break;
            case 3:
                turnS = "Oeste";
                if(campoOAtkPos == null) {atkPosT = "Nenhuma";} else {atkPosT = campoOAtkPos.getCardName(); if(campoAtacadoS != "Nenhum"){danoCausado = campoOAtkPos.getDamage();} }
                if(campoODefPos == null) {defPosT = "Nenhuma";} else {defPosT = campoODefPos.getCardName();}
                break;
            default:
                atkPosT = "Nenhuma";
                defPosT = "Nenhuma";
                break;
        }

        GameObject lastTurn = Instantiate(newTurnR);
        lastTurn.transform.SetParent(newTurnR.transform.parent);
        RectTransform parentRectTransform = lastTurn.transform.parent.GetComponent<RectTransform>();
        parentRectTransform.sizeDelta = new Vector2(parentRectTransform.sizeDelta.x, parentRectTransform.sizeDelta.y + 200);
        lastTurn.transform.SetSiblingIndex(0);

        lastTurn.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = 
        "Turno: " + turnS + " | Round: " + round.ToString() + "\n" +
        "Carta no ataque: " + atkPosT + "\n" +
        "Carta na defesa: " + defPosT + "\n" +
        "Campo atacado: " + campoAtacadoS + " | Dano causado = " + danoCausado + "\n" +
        "Habilidades usadas: " + "Nenhuma" + "\n" +
        "Vidas: " + "N - " + cLives[0] + "| S - " + cLives[2] + "| L - " + cLives[1] + "| O - " + cLives[3] + "\n";

        lastTurn.SetActive(true);
        turn++;
        round++;
        if(turn > 3)
        {
            turn = 0;
        }

        switch(turn)
        {
            case 0:
                if(campoNAtkPos) {attksPerRound = campoNAtkPos.getApr();}
                break;
            case 1:
                if(campoLAtkPos) {attksPerRound = campoLAtkPos.getApr();}
                break;
            case 2:
                if(campoSAtkPos) {attksPerRound = campoSAtkPos.getApr();} 
                break;
            case 3:
                if(campoOAtkPos) {attksPerRound = campoOAtkPos.getApr();} 
                break;
            default:
                break;
        }
    }

    public GameObject atS = null;
    public void AtkScreen()
    {
        if(attksPerRound > 0)
        {   
            if (atS.activeSelf)
            {
                atS.SetActive(false);
            }
            else
            {
                atS.SetActive(true);
            }

            switch(turn)
            {
                case 0:
                    atS.transform.GetChild(0).gameObject.SetActive(false);
                    atS.transform.GetChild(1).gameObject.SetActive(true);
                    atS.transform.GetChild(2).gameObject.SetActive(true);
                    atS.transform.GetChild(3).gameObject.SetActive(true);
                    break;
                case 1:
                    atS.transform.GetChild(0).gameObject.SetActive(true);
                    atS.transform.GetChild(1).gameObject.SetActive(true);
                    atS.transform.GetChild(2).gameObject.SetActive(false);
                    atS.transform.GetChild(3).gameObject.SetActive(true);
                    break;
                case 2:
                    atS.transform.GetChild(0).gameObject.SetActive(true);
                    atS.transform.GetChild(1).gameObject.SetActive(false);
                    atS.transform.GetChild(2).gameObject.SetActive(true);
                    atS.transform.GetChild(3).gameObject.SetActive(true);
                    break;
                case 3:
                    atS.transform.GetChild(0).gameObject.SetActive(true);
                    atS.transform.GetChild(1).gameObject.SetActive(true);
                    atS.transform.GetChild(2).gameObject.SetActive(true);
                    atS.transform.GetChild(3).gameObject.SetActive(false);
                    break;
                default:
                    break;
            }
        }
    }

    int campoAtacado = 5;
    public void Atacar(int who)
    {
        int dano = 0;
        switch(turn)
        {
            case 0:
                if(campoNAtkPos){dano = campoNAtkPos.getDamage();} 
                break;
            case 1:
                if(campoLAtkPos){dano = campoLAtkPos.getDamage();} 
                break;
            case 2:
                if(campoSAtkPos){dano = campoSAtkPos.getDamage();} 
                break;
            case 3:
                if(campoOAtkPos){dano = campoOAtkPos.getDamage();} 
                break;
            default:
                break;
        }

        switch(who)
        {
            case 0:
                if(campoNAtkPos || campoNDefPos)
                {
                    if(campoNAtkPos){campoNAtkPos.setCurrentLife(campoNAtkPos.getCurrentLife() - dano); dano = dano - campoNAtkPos.getLife(); 
                        if (dano < 0) {dano = 0;} else {campoNAtkPos.setCurrentLife(0);}
                        cPosLivesText[0].text = campoNAtkPos.getCurrentLife().ToString();
                    } 
                    
                    if(campoNDefPos){campoNDefPos.setCurrentLife(campoNDefPos.getCurrentLife() - dano); dano = dano - campoNDefPos.getLife();
                        if (dano < 0) {dano = 0; Counter(0,turn);} else {campoNDefPos.setCurrentLife(0);}
                        cPosLivesText[1].text = campoNDefPos.getCurrentLife().ToString();
                    } 
                    
                    if(dano > 0) {cLives[0]--; cLivesText[0].text = cLives[0].ToString();}
                }
                else 
                {
                    cLives[0]--;
                    cLivesText[0].text = cLives[0].ToString();
                }
                break;
            case 1:
                if(campoLAtkPos || campoLDefPos)
                {
                    if(campoLAtkPos){campoLAtkPos.setCurrentLife(campoLAtkPos.getCurrentLife() - dano); dano = dano - campoLAtkPos.getLife(); 
                        if (dano < 0) {dano = 0;} else {campoLAtkPos.setCurrentLife(0);}
                        cPosLivesText[2].text = campoLAtkPos.getCurrentLife().ToString();
                    } 
                    
                    if(campoLDefPos){campoLDefPos.setCurrentLife(campoLDefPos.getCurrentLife() - dano); dano = dano - campoLDefPos.getLife();
                        if (dano < 0) {dano = 0; Counter(1,turn);} else {campoLDefPos.setCurrentLife(0);}
                        cPosLivesText[3].text = campoLDefPos.getCurrentLife().ToString();
                    } 

                    if (dano > 0){cLives[1]--; cLivesText[1].text = cLives[1].ToString();}
                }
                else 
                {
                    cLives[1]--;
                    cLivesText[1].text = cLives[1].ToString();
                }
                break;
            case 2:
                if(campoSAtkPos || campoSDefPos)
                {
                    if(campoSAtkPos){campoSAtkPos.setCurrentLife(campoSAtkPos.getCurrentLife() - dano); dano = dano - campoSAtkPos.getLife(); 
                        if (dano < 0) {dano = 0;} else {campoSAtkPos.setCurrentLife(0);}
                        cPosLivesText[4].text = campoSAtkPos.getCurrentLife().ToString();
                    } 
                    
                    if(campoSDefPos){campoSDefPos.setCurrentLife(campoSDefPos.getCurrentLife() - dano); dano = dano - campoSDefPos.getLife();
                        if (dano < 0) {dano = 0; Counter(2,turn);} else {campoSDefPos.setCurrentLife(0);}
                        cPosLivesText[5].text = campoSDefPos.getCurrentLife().ToString();
                    } 
                    
                    if (dano > 0){cLives[2]--; cLivesText[2].text = cLives[2].ToString();}
                }
                else 
                {
                    cLives[2]--;
                    cLivesText[2].text = cLives[2].ToString();
                }
                break;
            case 3:
                if(campoOAtkPos || campoODefPos)
                {
                    if(campoOAtkPos){campoOAtkPos.setCurrentLife(campoOAtkPos.getCurrentLife() - dano); dano = dano - campoOAtkPos.getLife(); 
                        if (dano < 0) {dano = 0;} else {campoOAtkPos.setCurrentLife(0);}
                        cPosLivesText[6].text = campoOAtkPos.getCurrentLife().ToString();
                    } 
                    
                    if(campoODefPos){campoODefPos.setCurrentLife(campoODefPos.getCurrentLife() - dano); dano = dano - campoODefPos.getLife();
                        if (dano < 0) {dano = 0; Counter(3,turn);} else {campoODefPos.setCurrentLife(0);}
                        cPosLivesText[7].text = campoODefPos.getCurrentLife().ToString();
                    } 

                    if (dano > 0){cLives[3]--; cLivesText[3].text = cLives[3].ToString();}
                }
                else 
                {
                    cLives[3]--;
                    cLivesText[3].text = cLives[3].ToString();
                }
                break;
            default:
                break;
        }
        campoAtacado = who;
        atS.SetActive(false);
        attksPerRound--;
    }

    public void Counter(int countera, int counterado)
    {
        int dano = 0;
        switch(countera)
        {
            case 0:
                if(campoNDefPos){dano = campoNDefPos.getDamage();} 
                break;
            case 1:
                if(campoLDefPos){dano = campoLDefPos.getDamage();} 
                break;
            case 2:
                if(campoSDefPos){dano = campoSDefPos.getDamage();} 
                break;
            case 3:
                if(campoODefPos){dano = campoODefPos.getDamage();} 
                break;
            default:
                break;
        }

        switch(counterado)
        {
            case 0:
                if(campoNAtkPos){campoNAtkPos.setCurrentLife(campoNAtkPos.getCurrentLife() - dano); dano = dano - campoNAtkPos.getLife(); 
                    if (dano < 0) {dano = 0;} else {campoNAtkPos.setCurrentLife(0);}
                    cPosLivesText[0].text = campoNAtkPos.getCurrentLife().ToString();
                } 
                
                if(campoNDefPos){campoNDefPos.setCurrentLife(campoNDefPos.getCurrentLife() - dano); dano = dano - campoNDefPos.getLife();
                    if (dano < 0) {dano = 0; Counter(0,turn);} else {campoNDefPos.setCurrentLife(0);}
                    cPosLivesText[1].text = campoNDefPos.getCurrentLife().ToString();
                } 
                
                if(dano > 0) {cLives[0]--; cLivesText[0].text = cLives[0].ToString();}
                break;
            case 1:
                if(campoLAtkPos){campoLAtkPos.setCurrentLife(campoLAtkPos.getCurrentLife() - dano); dano = dano - campoLAtkPos.getLife(); 
                    if (dano < 0) {dano = 0;} else {campoLAtkPos.setCurrentLife(0);}
                    cPosLivesText[2].text = campoLAtkPos.getCurrentLife().ToString();
                } 
                
                if(campoLDefPos){campoLDefPos.setCurrentLife(campoLDefPos.getCurrentLife() - dano); dano = dano - campoLDefPos.getLife();
                    if (dano < 0) {dano = 0; Counter(1,turn);} else {campoLDefPos.setCurrentLife(0);}
                    cPosLivesText[3].text = campoLDefPos.getCurrentLife().ToString();
                } 

                if (dano > 0){cLives[1]--; cLivesText[1].text = cLives[1].ToString();}
                break;
            case 2:
                if(campoSAtkPos){campoSAtkPos.setCurrentLife(campoSAtkPos.getCurrentLife() - dano); dano = dano - campoSAtkPos.getLife(); 
                    if (dano < 0) {dano = 0;} else {campoSAtkPos.setCurrentLife(0);}
                    cPosLivesText[4].text = campoSAtkPos.getCurrentLife().ToString();
                } 
                
                if(campoSDefPos){campoSDefPos.setCurrentLife(campoSDefPos.getCurrentLife() - dano); dano = dano - campoSDefPos.getLife();
                    if (dano < 0) {dano = 0; Counter(2,turn);} else {campoSDefPos.setCurrentLife(0);}
                    cPosLivesText[5].text = campoSDefPos.getCurrentLife().ToString();
                } 
                
                if (dano > 0){cLives[2]--; cLivesText[2].text = cLives[2].ToString();}
                break;
            case 3:
                if(campoOAtkPos){campoOAtkPos.setCurrentLife(campoOAtkPos.getCurrentLife() - dano); dano = dano - campoOAtkPos.getLife(); 
                    if (dano < 0) {dano = 0;} else {campoOAtkPos.setCurrentLife(0);}
                    cPosLivesText[6].text = campoOAtkPos.getCurrentLife().ToString();
                } 
                
                if(campoODefPos){campoODefPos.setCurrentLife(campoODefPos.getCurrentLife() - dano); dano = dano - campoODefPos.getLife();
                    if (dano < 0) {dano = 0; Counter(3,turn);} else {campoODefPos.setCurrentLife(0);}
                    cPosLivesText[7].text = campoODefPos.getCurrentLife().ToString();
                } 

                if (dano > 0){cLives[3]--; cLivesText[3].text = cLives[3].ToString();}
                break;
            default:
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
