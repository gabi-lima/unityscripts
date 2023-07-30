using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Mirar : MonoBehaviour
{
    [SerializeField] private Animator rigAnimator;
    [SerializeField] public CinemachineVirtualCamera activeCam;
    
    private int mirarHash = Animator.StringToHash("mirar");
    void Start(){
        
        
    }
    void Update()
{
    // Verifica se o botão direito do mouse foi pressionado para entrar no modo de mira
    if (Input.GetKeyDown(KeyCode.Mouse1))
    {
        rigAnimator.SetBool(mirarHash, true);
        activeCam.Priority = 2;
    }

    // Verifica se o botão esquerdo do mouse foi pressionado e a mira está ativada para atirar
    if (Input.GetKeyDown(KeyCode.Mouse0) && rigAnimator.GetBool(mirarHash))
    {
        rigAnimator.SetBool("atirar", true);
    }

    // Verifica se o botão direito do mouse foi solto para sair do modo de mira
    if (Input.GetKeyUp(KeyCode.Mouse1))
    {
        rigAnimator.SetBool(mirarHash, false);
        activeCam.Priority = 0;
    }

    // Verifica se o botão esquerdo do mouse foi solto para parar de atirar
    if (Input.GetKeyUp(KeyCode.Mouse0))
    {
        rigAnimator.SetBool("atirar", false);
    }
}
}
