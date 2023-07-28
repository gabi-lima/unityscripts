using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private CharacterController characterController;
    private Animator animator;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Obtem o input do jogador para movimento horizontal e vertical.
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calcula a magnitude do movimento (combinação do movimento horizontal e vertical).
        float movementMagnitude = new Vector2(horizontal, vertical).sqrMagnitude;

       

        // Verifica se o jogador está caminhando (a magnitude do movimento é maior que um valor mínimo).
        bool isWalking = movementMagnitude > 0.1f;

        // Define a variável "isWalking" do Animator com o valor adequado para controlar a animação de caminhar.
        animator.SetBool("isWalking", isWalking);

        // Movimenta o personagem usando o CharacterController.
        MoveCharacter(horizontal, vertical);
    }

    private void MoveCharacter(float horizontal, float vertical)
    {
        // Calcula a direção do movimento com base nas entradas de movimento horizontal e vertical.
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        // Aplica a movimentação ao CharacterController.
        characterController.Move(direction * moveSpeed * Time.deltaTime);

        // Rotaciona o modelo do jogador na direção do movimento, se estiver se movendo.
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}
