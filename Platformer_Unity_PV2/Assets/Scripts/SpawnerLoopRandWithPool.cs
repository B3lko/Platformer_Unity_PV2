using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerLoopRandWithPool : MonoBehaviour
{
    
    [SerializeField] private GameObject[] objectPrefab; //Se agrega [] porque es un arreglo
    [SerializeField] private int poolSize;
    [SerializeField] private List<GameObject> PrefabList;
    [SerializeField]
    [Range(0.5f,5f)]
    private float TiempoEspera;

    [SerializeField]
    [Range(0.5f,5f)]
    private float TiempoIntervalo;

    // Start is called before the first frame update
    void Start()
    {
        AddObjectsToPool(poolSize);
    }

    private void OnBecameInvisible()
    {
        CancelInvoke(nameof(SpawnObject));
    }
    void OnBecameVisible() {
        InvokeRepeating(nameof(SpawnObject), TiempoEspera, TiempoIntervalo);
    }

    private void AddObjectsToPool(int amount){
        for(int i=0; i<amount ;i++){
            int indexAleatorio = Random.Range(0,objectPrefab.Length); //Obtenemos un indice aleatorio
            GameObject PrefabAleatorio = objectPrefab[indexAleatorio]; //Obtenemos la referencia del array con el indice
            GameObject object_aux = Instantiate(PrefabAleatorio, transform.position, Quaternion.identity); //Intsnaciamos
            object_aux.SetActive(false);
            PrefabList.Add(object_aux);
            object_aux.transform.parent = transform;
        }
    }

    private void SpawnObject(){
        for(int i=0;i<PrefabList.Count;i++){
            if(!PrefabList[i].activeSelf){
                PrefabList[i].SetActive(true);
                PrefabList[i].GetComponent<Lifes_Zombie>().SetLifes(10);
                PrefabList[i].transform.position = transform.position;
                return;
            }
        }
    }
}
