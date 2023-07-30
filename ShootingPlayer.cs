using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPlayer : MonoBehaviour
{
    public float fireRate = 0.5f; // Tempo mínimo entre os tiros (em segundos)
    public AudioClip[] gunshotSounds; // Array contendo os sons de tiro
    public int maxBullets = 15; // Limite de balas
    public float reloadTime = 1.5f; // Tempo de recarga em segundos

    private bool isAim;
    private int currentBullets; // Quantidade de balas atualmente
    private AudioSource audioSource;
    private bool canShoot = true;

    public ParticleSystem fogoEfeito; // Referência ao sistema de partículas do efeito de fogo


    void Start()
    {
        currentBullets = maxBullets;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
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

        if (isAim && Input.GetButtonDown("Fire1") && canShoot && currentBullets > 0)
        {
            // Inicia a corrotina de disparo
            StartCoroutine(Shoot());
            fogoEfeito.Play();
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;

        // Reduz o número de balas disponíveis
        currentBullets--;

        // Escolhe um som de tiro aleatoriamente e reproduz
        if (gunshotSounds.Length > 0)
        {
            int randomIndex = Random.Range(0, gunshotSounds.Length);
            audioSource.clip = gunshotSounds[randomIndex];
            audioSource.Play();
        }

        // Faz o Raycast a partir da posição e direção do objeto do jogador para determinar se atingiu algo
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitinfo, 100f))
        {
            if (hitinfo.collider.CompareTag("atingivel"))
            {
                // Se o Raycast atingiu algo com a tag "atingivel", causa dano ao inimigo
                EnemyController enemyController = hitinfo.collider.GetComponent<EnemyController>();
                if (enemyController != null)
                {
                    enemyController.TakeDamage(20);
                }
            }
            else
            {
                // Caso contrário, se não for um inimigo, imprima um Debug.Log indicando que você errou o alvo.
                Debug.Log("Errou");
            }
        }

        // Espera o tempo do rate de disparo antes de poder atirar novamente
        yield return new WaitForSeconds(fireRate);
        canShoot = true;

        // Verifica se é necessário recarregar as balas
        if (currentBullets <= 0)
        {
            StartCoroutine(Reload());
        }
    }

    IEnumerator Reload()
    {
        canShoot = false;

        // Aguarda o tempo de recarga
        yield return new WaitForSeconds(reloadTime);

        // Recarrega as balas
        currentBullets = maxBullets;
        canShoot = true;
    }
}