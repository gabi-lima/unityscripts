using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator animator;
    public int maxHealth = 100;
    private int currentHealth;
    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    public bool isDead;

  

    private void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        isDead = false;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log(this.currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {   
        Debug.Log("Boneco morreu!");
        animator.SetBool("isDead", true);
        isDead = true;
        Destroy(gameObject, 5f);
        
        // Obtém o componente Spawner e solicita a remoção do zumbi da lista
        Spawner spawner = FindObjectOfType<Spawner>();
        if (spawner != null)
        {
            spawner.RemoveZumbi(gameObject);
        }
        

    }

    
}
