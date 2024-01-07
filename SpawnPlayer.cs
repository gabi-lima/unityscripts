using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    // Define as três áreas de spawn
    public Transform areaFacil;
    public Transform areaMedio;
    public Transform areaDificil;

    // Define a dificuldade do jogo

    // Define a largura e a altura da área de spawn
    public float larguraArea = 100;

    void Start()
    {
    }
    public void Spawn(){
        Transform area;
        int dificuldade = Random.Range(1, 3);
        if (dificuldade == 1) {
            area = areaFacil;
        } else if (dificuldade == 2) {
            area = areaMedio;
        } else {
            area = areaDificil;
        }
        transform.position = GetRandomPosition(area);
    }
    // Obtém uma posição aleatória dentro da área
   private Vector3 GetRandomPosition(Transform area)
{
    // Obtém a largura e a altura da área
    float largura = area.localScale.x;

    // Gera uma posição aleatória dentro da área
    float x = Random.Range(area.position.x - area.position.x, area.position.x);

    // Retorna a posição aleatória
    return new Vector3(x, 0.5f, 0);
}
}