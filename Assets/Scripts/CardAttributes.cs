using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardAttributes : MonoBehaviour
{
    public Sprite img; // Imagem da carta
    public string cardName; // Nome da carta
    public string habilidadeEspecial; // Descrição da carta
    public int life; // Vida total
    public int damage; // Dano
    public int apr; // Número de ataques por round
    public int index; // Índice

    public int getLife()
    {
        return life;
    }

    public int getDamage()
    {
        return damage;
    }

    public string getCardName()
    {
        return cardName;
    }

    public string getHabilidadeEspecial()
    {
        return habilidadeEspecial;
    }

    public int getIndex()
    {
        return index;
    }

    public int getApr()
    {
        return apr;
    }

    public Sprite getImage()
    {
        return img;
    }
}
