using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player; // Referência ao transform do jogador
    public float attackDistance = 1.5f; // Distância para iniciar o ataque
    public float movementSpeed = 2f; // Velocidade de movimento do inimigo

    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    private Animator animator;
    private bool isAttacking = false;

    void Start()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        //animator = GetComponent<//Animator>();
    }

    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer > attackDistance)
            {
                // O inimigo está longe do jogador, então vamos persegui-lo
                navMeshAgent.SetDestination(player.position);
                navMeshAgent.speed = movementSpeed;
                //animator.SetBool("isWalking", true);
                //animator.SetBool("isAttacking", false);
                isAttacking = false;
            }
            else
            {
                // O inimigo está perto o suficiente para atacar
                navMeshAgent.SetDestination(transform.position);
                navMeshAgent.speed = 0f;
                //animator.SetBool("isWalking", false);

                if (!isAttacking)
                {
                    // Inicia a animação de ataque e causa dano ao jogador
                    //animator.SetBool("isAttacking", true);
                    isAttacking = true;
                    PlayerController playerController = player.GetComponent<PlayerController>();
                    if (playerController != null)
                    {
                        playerController.TakeDamage(20); // Ajuste o valor do dano conforme necessário
                    }
                }
            }
        }
    }
}