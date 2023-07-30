using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OpacidadeCrosshair : MonoBehaviour
{
    public float opacity = 1f; // Valor de opacidade desejado (0 a 1)
    private Image image; // Referência ao componente de imagem

    void Start()
    {
        // Obtenha os componentes necessários
        image = GetComponent<Image>();
       
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (image != null)
        {
            Color currentColor = image.color;
            currentColor.a = opacity;
            image.color = currentColor;
        }
        }

        // Verifica se o botão direito do mouse foi solto para sair do modo de mira
        if (Input.GetButtonUp("Fire2"))
        {
            if (image != null)
        {
            Color currentColor = image.color;
            currentColor.a = 0f;
            image.color = currentColor;
        }
        }// Altera a opacidade do elemento de UI
    }
        
       
}