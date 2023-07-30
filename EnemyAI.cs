using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player; // Referência ao transform do jogador
    public float attackDistance = 1.5f; // Distância para iniciar o ataque
    public float movementSpeed = 2f; // Velocidade de movimento do inimigo
    public EnemyController controlador;
    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    private Animator animator;


    private GameObject enemyHand;
    void Start()
    {
        enemyHand = GameObject.FindWithTag("hand");
        enemyHand.SetActive(false);
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponent<Animator>(); // Descomente esta linha para obter o componente Animator
        controlador =  GetComponent<EnemyController>();
    }

    void Update()
    {
        if (controlador.isDead == false){
        navMeshAgent.destination = player.transform.position;
        navMeshAgent.speed = movementSpeed;
        // Ativa a animação de movimento
        animator.SetBool("isWalking", true);
        }
        if (Vector3.Distance(transform.position, player.transform.position) < attackDistance){
            enemyHand.SetActive(true);
                // O inimigo está perto o suficiente para atacar
                navMeshAgent.SetDestination(transform.position);
                navMeshAgent.speed = 0f;

                // Ativa a animação de ataque
                animator.SetBool("isAttacking", true);
                animator.SetBool("isWalking", false);

                StartCoroutine("ataque");
        }
}
    IEnumerator ataque(){
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("isAttacking", false);
        yield return new WaitForSeconds(2.8f);
        enemyHand.SetActive(false);
        navMeshAgent.speed = movementSpeed;

    }
}