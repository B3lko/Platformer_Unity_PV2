using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coleccionar : MonoBehaviour
{
    [SerializeField] private List<GameObject> colleccionables;
    private Dictionary<string, GameObject> inventario;
    [SerializeField] private GameObject bolsa;
    private bool presionado = false;
    private Progression progresionJugador;
    [SerializeField] private int Xp;
    [SerializeField] private Canvas cv;
    //private ScriptA CvS;
    private int index = 1;
    private int aux;
    
    void Awake(){
        colleccionables = new List<GameObject>();
        inventario = new Dictionary<string,GameObject>();
        progresionJugador = GetComponent<Progression>();
       
    }


    void OnTriggerEnter2D(Collider2D other) {
        if(!other.gameObject.CompareTag("Coleccionable")){return;}
        if(inventario.ContainsKey(other.gameObject.name)){return;}

        GameObject nuevoColeccionable = other.gameObject;
        nuevoColeccionable.SetActive(false);

        inventario.Add(nuevoColeccionable.name, nuevoColeccionable);


        colleccionables.Add(nuevoColeccionable);
        if(nuevoColeccionable.name == "Coleccionable_Skull"){aux = 1;}
        if(nuevoColeccionable.name == "Coleccionable_Hearth"){aux = 2;}
        if(nuevoColeccionable.name == "Coleccionable_Chest"){aux = 3;}
        if(nuevoColeccionable.name == "Coleccionable_Brain"){aux = 4;}
        if(nuevoColeccionable.name == "Coleccionable_Teeth"){aux = 5;}
        cv.GetComponent<Slots_Controller>().SetContent(aux);

        nuevoColeccionable.transform.SetParent(bolsa.transform);
        progresionJugador.ModXp(Xp);
    }


    // Start is called before the first frame update
    void Start(){
    }

    // Update is called once per frame
    void Update(){

        if(Input.GetKeyDown(KeyCode.Alpha1) && colleccionables[index] != null){index = 1;}
        if(Input.GetKeyDown(KeyCode.Alpha2)){index = 2;}
        if(Input.GetKeyDown(KeyCode.Alpha3)){index = 3;}
        if(Input.GetKeyDown(KeyCode.Alpha4)){index = 4;}
        if(Input.GetKeyDown(KeyCode.Alpha0)){index = 5;}
        if(Input.GetKeyDown(KeyCode.Q)){
            UsarInventario(colleccionables[index-1]);
        }
    }

    private void UsarInventario(GameObject Item){
        Item.transform.SetParent(null);
        Item.transform.position = transform.position;
        Item.SetActive(true);
    }
}
