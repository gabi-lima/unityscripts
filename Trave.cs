using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trave : MonoBehaviour
{
    AudioSource audioData;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
{
    // Verifica se a bola colidiu com o goleiro
    if (collision.gameObject.CompareTag("Bola"))
    {
        audioData = GetComponent<AudioSource>();                
        audioData.Play(0);}
}
}