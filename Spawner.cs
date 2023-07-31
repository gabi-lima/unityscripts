using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject objetoParaInstanciar; // Prefab do objeto que será instanciado
    [SerializeField] private float taxaDeSpawn = 3f; // Tempo em segundos entre cada spawn
    [SerializeField] private int limiteZumbis = 15; // Limite máximo de zumbis em jogo

    private float contadorTempo = 0f;
    private List<GameObject> zumbisAtivos = new List<GameObject>(); // Lista para rastrear os zumbis ativos

    void Update()
    {
        // Conta o tempo decorrido
        contadorTempo += Time.deltaTime;

        // Verifica se é hora de spawnar um novo objeto e se ainda não atingiu o limite de zumbis ativos
        if (contadorTempo >= taxaDeSpawn && zumbisAtivos.Count < limiteZumbis)
        {
            SpawnObject();
            contadorTempo = 0f; // Reinicia o contador de tempo
        }
    }

    void SpawnObject()
    {
        // Instancia o objeto na posição do Spawner
        GameObject novoZumbi = Instantiate(objetoParaInstanciar, transform.position, Quaternion.identity);
        novoZumbi.SetActive(true);
        // Adiciona o zumbi à lista de zumbis ativos
        zumbisAtivos.Add(novoZumbi);
    }

    // Método para remover um zumbi da lista quando ele "morrer"
    public void RemoveZumbi(GameObject zumbi)
    {
        zumbisAtivos.Remove(zumbi);
    }
}
