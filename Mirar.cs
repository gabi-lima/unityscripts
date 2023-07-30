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
        if (Input.GetKeyDown(KeyCode.Mouse1)){
            rigAnimator.SetBool(mirarHash, true);
            activeCam.Priority = 2;
        }
        if (Input.GetKeyUp(KeyCode.Mouse1)){
            rigAnimator.SetBool(mirarHash, false);  
            activeCam.Priority = 0;
        }
    }
}
