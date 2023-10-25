using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerControllerLoop : MonoBehaviour
{
    // Start is called before the first frame update
[SerializeField] private GameObject objectPrefab;

    [SerializeField]
    [Range(0.5f,5f)]
    private float TiempoEspera;

    [SerializeField]
    [Range(0.5f,5f)]
    private float TiempoIntervalo;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnObjectLoop), TiempoEspera, TiempoIntervalo);
    }

    void SpawnObjectLoop(){
        
        Instantiate(objectPrefab, transform.position, Quaternion.identity);
    }
}
