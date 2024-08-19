using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Summon : MonoBehaviour
{
    CardAttributes cardAttributes;
    public Image i;
    public TextMeshProUGUI n;
    public TextMeshProUGUI h;
    public TextMeshProUGUI l;
    public TextMeshProUGUI d;

    void Start()
    {
        cardAttributes = GetComponent<CardAttributes>();
    }

    public void PassAtt()
    {
        i.sprite = cardAttributes.getImage();
        d.text = cardAttributes.getDamage().ToString();
        n.text = cardAttributes.getCardName();
        l.text = cardAttributes.getLife().ToString();
        h.text = cardAttributes.getHabilidadeEspecial();
    }
}
