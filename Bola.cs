using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bola : MonoBehaviour
{
    public LineRenderer trajetoriaRenderer; // Referência ao LineRenderer para desenhar a trajetória
    public float forcaInicial = 10f; // Força inicial do chute
    public float forcaMaxima = 50f;  // Força máxima que pode ser atingida
    public float distanciaMaxima = 5f; // Distância máxima permitida entre a bola e o jogador
    private Vector3 direcaoChute;    // Direção do chute definida pelo jogador
    private float tempoPressionado = 0f;
    private bool definindoTrajetoria = true;

    public Transform Goleiro;

    private GoleiroController controladorGoleiro;
    public GameObject hud;
    public Image barra;

    public PlayerController player;

   [SerializeField] private AudioSource audioData;


    void Start()
    {
        // Inicializa o LineRenderer
        trajetoriaRenderer.positionCount = 2;
        trajetoriaRenderer.enabled = true; 
        hud.SetActive(false);
    }

    void Update()
    {
        
        if (!EstaProximoDoJogador())
        {
            trajetoriaRenderer.enabled = false;

        }
        if (definindoTrajetoria && EstaProximoDoJogador())
        {   
            AtualizarTrajetoriaComMouse();

            // Verifica se o botão esquerdo do mouse está sendo pressionado
            if (Input.GetMouseButton(0))
            {
                // Incrementa o tempo pressionado enquanto o botão é mantido pressionado
                tempoPressionado += Time.deltaTime;

                // Atualiza a trajetória com base no movimento do mouse
                AtualizarTrajetoriaComMouse();
            }

            // Verifica se o botão esquerdo do mouse foi solto
            if (Input.GetMouseButtonUp(0))
            {
                definindoTrajetoria = false; // Altera para definir a força do chute
                
            }
        }
        else
        {


            // Verifica se o botão esquerdo do mouse está sendo pressionado
            if (Input.GetMouseButton(0))
            {
                hud.SetActive(true);
                // Incrementa o tempo pressionado enquanto o botão é mantido pressionado
                tempoPressionado += Time.deltaTime;
                AtualizarBarraDeProgresso();
            }

            // Verifica se o botão esquerdo do mouse foi solto
            if (Input.GetMouseButtonUp(0))
            {
                player.kick = true;
                // Verifica se a bola está próxima a um objeto com a tag "Player"
                if (EstaProximoDoJogador())
                {
                    // Chama a função Chutar passando a força proporcional ao tempo pressionado e a direção do chute
                    StartCoroutine (Chutar(forcaInicial + Mathf.Min(tempoPressionado, 1f) * (forcaMaxima - forcaInicial), direcaoChute));
                }

                tempoPressionado = 0f; // Reseta o tempo pressionado após o chute
                trajetoriaRenderer.enabled = false; // Desativa a trajetória quando o botão é solto
                definindoTrajetoria = true; // Altera para definir a trajetória no próximo clique
                hud.SetActive(false);
                ReiniciarBarraDeProgresso();
            }
        }
    }

    void AtualizarTrajetoriaComMouse()
    {
        // Ativa o LineRenderer para desenhar a trajetória
        trajetoriaRenderer.enabled = true;

        // Obtém a posição do mouse na tela
        Vector3 posicaoMouse = Input.mousePosition;

        // Converte a posição do mouse para um ponto no espaço 3D
        posicaoMouse.z = 20f; // Ajusta a profundidade para a distância da câmera
        Vector3 posicaoMundo = Camera.main.ScreenToWorldPoint(posicaoMouse);

        // Desenha a trajetória entre a posição atual da bola e a posição do mouse
        trajetoriaRenderer.SetPosition(0, transform.position);
        trajetoriaRenderer.SetPosition(1, posicaoMundo);

        // Atualiza a direção do chute com base no movimento do mouse
        direcaoChute = (posicaoMundo - transform.position).normalized;
    }

    bool EstaProximoDoJogador()
    {
        GameObject jogador = GameObject.FindGameObjectWithTag("Player");

        if (jogador != null)
        {
            float distancia = Vector3.Distance(transform.position, jogador.transform.position);
            return distancia <= distanciaMaxima;
        }

        return false;
    }

    IEnumerator Chutar(float forca, Vector3 direcao)
    {
        yield return new WaitForSeconds(0.8f);
        // Aplica a força ao Rigidbody da bola na direção calculada
        GetComponent<Rigidbody>().AddForce(direcao * forca, ForceMode.Impulse);
        player.kick = false;
        PlayAudio();

        

    }

    void AtualizarBarraDeProgresso()
    {
        // Atualiza a fillAmount da barra de progresso com base no tempo pressionado
        if (barra != null)
        {
            barra.fillAmount = tempoPressionado / 1f; // Normaliza para um intervalo de 0 a 1
        }
    }

    void ReiniciarBarraDeProgresso()
    {
        // Reinicia a fillAmount da barra de progresso
        if (barra != null)
        {
            barra.fillAmount = 0f;
        }
    }


    void OnCollisionEnter(Collision collision)
{
    // Verifica se a bola colidiu com o goleiro
    if (collision.gameObject.CompareTag("Goleiro"))
    {
        // Obtém a direção do goleiro
        Vector3 direcaoParaGoleiro = (Goleiro.transform.position - transform.position).normalized;

        // Calcula a direção refletida da bola
        Vector3 direcaoRefletida = Vector3.Reflect(direcaoChute, direcaoParaGoleiro);

        // Aplica uma força para desacelerar a bola
        GetComponent<Rigidbody>().AddForce(-direcaoRefletida * 10f, ForceMode.Impulse); // Aplica uma força de 10 Newtons na direção oposta à direção da bola
    }
    
}

    void PlayAudio(){
        audioData.Play(0);
    }
   
}