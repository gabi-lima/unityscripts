using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPlayer : MonoBehaviour
{
    private bool isAim;
    void Update(){
        {
            
            // Verifica se o botão direito do mouse foi pressionado para entrar no modo de mira
            if (Input.GetButtonDown("Fire2"))
            {
                isAim = true;
            }

            // Verifica se o botão direito do mouse foi solto para sair do modo de mira
            if (Input.GetButtonUp("Fire2"))
            {
                isAim = false;
            }

            if (isAim && Input.GetButtonDown("Fire1"))
            {
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitinfo, 20f))
                {
                    // Se o Raycast atingiu algo, verifique se é um inimigo com uma tag específica (por exemplo, "Enemy").
                    if (hitinfo.collider.CompareTag("atingivel"))
                    {
                        // Aqui você pode adicionar a lógica para causar dano ao inimigo (por exemplo, reduzir 20 de vida).
                        // Supondo que o inimigo tenha um componente com uma variável de vida (por exemplo, HealthController).
                        EnemyController enemyController = hitinfo.collider.GetComponent<EnemyController>();
                        if (enemyController != null)
                        {
                            Debug.Log("ATINGIU");
                            enemyController.TakeDamage(20);
                        }
                    }
                    else
                    {
                        // Caso contrário, se não for um inimigo, imprima um Debug.Log indicando que você errou o alvo.
                        Debug.Log("Errou");
                    }
                }
            }
        }
    }
        
}