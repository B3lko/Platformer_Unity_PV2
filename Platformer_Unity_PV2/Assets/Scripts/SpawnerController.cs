using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;

    [SerializeField]
    [Range(0.5f,5f)]
    private float TiempoEspera;

    public void SpawnObject(){
        Instantiate(objectPrefab, transform.position, Quaternion.identity);
    }
}
