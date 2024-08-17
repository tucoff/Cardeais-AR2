using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardAttributes : MonoBehaviour
{
    public Image healthBar; // Barra de vida
    public TextMeshProUGUI healthText; // Texto da vida
    public TextMeshProUGUI dmgText; // Texto do dano
    public int fullLife; // Vida total
    public int currentLife; // Vida atual
    public int damage; // Dano
    public int index; // Índice

    private void Start() 
    {
        currentLife = fullLife; // Define a vida atual como a vida total
        dmgText.text = damage.ToString(); // Define o texto do dano como uma string do valor do dano
    }

    private void FixedUpdate() {
        healthBar.fillAmount = Mathf.MoveTowards(healthBar.fillAmount, (float)currentLife / fullLife, 2f * Time.deltaTime); // Atualiza a barra de vida gradualmente
        healthText.text = currentLife.ToString(); // Atualiza o texto da vida
    }
}
