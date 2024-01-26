using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GoalController : MonoBehaviour

    

{

    public bool marker1;
    public bool marker2;
    public bool marker3;

    [SerializeField] AudioSource audioGol;
    public TextMeshProUGUI textoPontos;  // Referência ao texto que exibirá os pontos
    [SerializeField] private int pontos = 0;   // Variável para armazenar os pontos

    void Start()
    {
        AtualizarTextoPontos();
        audioGol = GetComponent<AudioSource>();
        marker1 = false;
        marker2 = false;
        marker3 = false;
    }

    void Update(){
        
    }

    void OnTriggerEnter(Collider other)
    {
        // Verifica se a bola colidiu com o colisor do gol
        if (other.CompareTag("Bola"))
        {
            MarcarGol();
        }
    }

    void MarcarGol()
    {
        // Incrementa os pontos
        pontos++;
        
        // Atualiza o texto que exibe os pontos
        AtualizarTextoPontos();

        // Você pode adicionar aqui lógica adicional relacionada a marcar um gol
        audioGol.Play();
        audioGol.pitch += 0.02f;
    }

    void AtualizarTextoPontos()
    {
        // Atualiza o texto que exibe os pontos na tela
        if (textoPontos != null)
        {
            textoPontos.text = "golasso: " + pontos.ToString();
        }
    }
}
