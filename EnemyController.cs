using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public int damageAmount = 20;

    private void Start()
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

    private void Die()
    {   
        Debug.Log("Boneco morreu!");
        // Aqui você pode adicionar qualquer comportamento que deseja quando o inimigo morrer.
        // Por exemplo, você pode reproduzir uma animação de morte, dar pontos ao jogador, etc.
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Se o inimigo colidir com o jogador, causar dano ao jogador.
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                Debug.Log("Dano!");
                player.TakeDamage(damageAmount);
            }
        }
    }
}
