using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

   
    // Start is called before the first frame update
    void Start()
    {
        
        currentHealth = maxHealth;
        
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void Die()
    {
        // Aqui você pode adicionar qualquer comportamento que deseja quando o jogador morrer.
        // Por exemplo, você pode reproduzir uma animação de morte, exibir uma tela de Game Over, etc.
        Debug.Log("Player died!");
        // Para este exemplo, vamos apenas desativar o GameObject do jogador.
        gameObject.SetActive(false);
    }
}
