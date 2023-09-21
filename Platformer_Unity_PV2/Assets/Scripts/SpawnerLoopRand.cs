using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerLoopRand : MonoBehaviour
{
    // Start is called before the first frame update
[SerializeField] private GameObject[] objectPrefab; //Se agrega [] porque es un arreglo

    [SerializeField]
    [Range(0.5f,5f)]
    private float TiempoEspera;

    [SerializeField]
    [Range(0.5f,5f)]
    private float TiempoIntervalo;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating(nameof(SpawnObjectLoop), TiempoEspera, TiempoIntervalo);
    }

    private void OnBecameInvisible()
    {
        CancelInvoke(nameof(SpawnObjectLoop));
    }
    void OnBecameVisible() {
        InvokeRepeating(nameof(SpawnObjectLoop), TiempoEspera, TiempoIntervalo);
    }

    void SpawnObjectLoop(){
        int indexAleatorio = Random.Range(0,objectPrefab.Length); //Obtenemos un indice aleatorio
        GameObject PrefabAleatorio = objectPrefab[indexAleatorio]; //Obtenemos la referencia del array con el indice
        Instantiate(PrefabAleatorio, transform.position, Quaternion.identity); //Intsnaciamos
    }
}
