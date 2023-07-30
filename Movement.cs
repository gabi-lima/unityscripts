using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
   private float inputX;
   private float inputY;

   private CharacterController characterController;
   private Animator animator;

   private int inputXHash = Animator.StringToHash("inputX");
   private int inputYHash = Animator.StringToHash("inputY");


   private void Awake(){
    characterController = GetComponent<CharacterController>();
    animator = GetComponent<Animator>();
    
   }
   void Update(){
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

        animator.SetFloat(inputXHash, inputX);
        animator.SetFloat(inputYHash, inputY);

        characterController.Move(transform.TransformDirection(new Vector3(inputX, -1,inputY)).normalized * Time.deltaTime*3);
       
    }
}
