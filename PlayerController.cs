using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class PlayerController : MonoBehaviour
{
    public bool kick;
    public bool podeChutar;
    private bool reiniciando;

    public bool fogo;

    public bool fogo2;
    
    public bool fogo3;

    [SerializeField] Animator animator;
    private void Start(){
        
        Cursor.lockState = CursorLockMode.Confined;
        kick = false;
        fogo = false;


        
    }
    private void Update(){
        if (Input.GetKeyDown(KeyCode.R)){
            animator.SetBool("Reiniciando", true);
            animator.SetBool("Kick", false);
            StartCoroutine(ResetAnim());
            Debug.Log("Fogo é: " + fogo);
            
        }

        if (kick && podeChutar){
            animator.SetBool("Kick", true);
        }
        if (!kick){
            animator.SetBool("Kick", false);
        }
        
    }

    IEnumerator ResetAnim(){ 
        yield return new WaitForSeconds(1f);
        reiniciando = false;
        animator.SetBool("Reiniciando", false);
        animator.SetBool("Kick", false);


    }
}