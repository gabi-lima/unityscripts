using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoleiroController : MonoBehaviour

  {
    AudioSource audioData;

    public Transform bola; // Referência à transformada da bola
    public float alturaPulo = 5f; // Altura do pulo do goleiro
    public float velocidadeMovimento = 2f; // Velocidade de movimento do goleiro
    public float distanciaMaximaDoGol = 0.5f; // Distância máxima que o goleiro pode se afastar do gol
    public float distanciaParaMover = 4f; // Distância a partir da qual o goleiro começará a se mover
    public bool estaInteressadoNaBola;

    public bool bolaEsquerda = false;
    public bool bolaDireita = false;
    [SerializeField] private Animator animator;
    private void Start(){
        estaInteressadoNaBola = true;
        animator.SetBool("interesseBola", true);

    }
    void Update()
    {
        // Verifica se a bola está em movimento
        if (bola != null && bola.GetComponent<Rigidbody>().velocity.magnitude > 0.1f && estaInteressadoNaBola)
        {
            
            TentarDefenderBola();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            animator.Rebind();
            animator.Update(0f);
            estaInteressadoNaBola = true;
            animator.SetBool("interesseBola", true);
            
        }
        if (bola.position.x < transform.position.x && bola.GetComponent<Rigidbody>().velocity.magnitude > 1f && estaInteressadoNaBola)
        {
            

            // Atribui o valor da variável bolaEsquerda ao parâmetro do animator
            animator.SetBool("bolaEsquerda", true);
        }
            // Verifica se a bola está vindo da direita
        else if (bola.position.x > transform.position.x && bola.GetComponent<Rigidbody>().velocity.magnitude > 1f && estaInteressadoNaBola)
        {
           

            // Atribui o valor da variável bolaDireita ao parâmetro do animator
            animator.SetBool("bolaDireita", true);
        }

       
        
    }

   
    void TentarDefenderBola()
    {
        // Calcula a distância entre o goleiro e a bola
        float distanciaParaBola = Vector3.Distance(transform.position, bola.position);

        // Verifica se a bola está próxima o suficiente para começar a se mover
        if (distanciaParaBola < distanciaParaMover)
        {
            // Calcula a direção para a bola
            Vector3 direcaoBola = (bola.position - transform.position).normalized;

            // Calcula a posição destino mantendo o goleiro perto do gol
            Vector3 posicaoDestino = new Vector3(Mathf.Clamp(bola.position.x, transform.position.x - distanciaMaximaDoGol, transform.position.x + distanciaMaximaDoGol),
                                                transform.position.y,
                                                bola.position.z);

            // Move o goleiro em direção à posição destino
            transform.position = Vector3.MoveTowards(transform.position, posicaoDestino, velocidadeMovimento * Time.deltaTime);

            // Pula para tentar bloquear a bola
            Pular();

            
        }
    }

    void Pular()
    {
        // Aplica uma força para simular o pulo
        GetComponent<Rigidbody>().AddForce(Vector3.up * alturaPulo, ForceMode.Impulse);
    }
    void OnCollisionEnter(Collision collision)
    {
        // Verifica se a bola colidiu com o goleiro
        if (collision.gameObject.CompareTag("Bola"))
        {
            audioData = GetComponent<AudioSource>();
            audioData.Play(0);
            // Define a variável booleana para false
            estaInteressadoNaBola = false;
            animator.SetBool("interesseBola", false);

        }
    }
}


