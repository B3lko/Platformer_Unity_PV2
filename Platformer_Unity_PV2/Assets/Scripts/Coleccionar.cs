using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coleccionar : MonoBehaviour
{
    [SerializeField] private List<GameObject> colleccionables;
    [SerializeField] private GameObject bolsa;
    private Progression progresionJugador;
    [SerializeField] private int Xp;
    [SerializeField] private Canvas cv;
    private int index = 1;
    private int aux;
    
    void Awake(){
        colleccionables = new List<GameObject>();
        progresionJugador = GetComponent<Progression>();
    }


    void OnTriggerEnter2D(Collider2D other) {
        if(!other.gameObject.CompareTag("Coleccionable")){return;}
        if(!other.gameObject.GetComponent<ColeccionableController>().getPickable()){return;}


        GameObject nuevoColeccionable = other.gameObject;
        nuevoColeccionable.SetActive(false);

        colleccionables.Add(nuevoColeccionable);

        nuevoColeccionable.transform.SetParent(bolsa.transform);
        progresionJugador.ModXp(Xp);
        cv.GetComponent<Slots_Controller>().SetContent(nuevoColeccionable.GetComponent<SpriteRenderer>().sprite.name);
    }


    // Update is called once per frame
    void Update(){

        //Segun la tecla presionada se cambia el indice
        if(Input.GetKeyDown(KeyCode.Alpha1)){index = 1;}
        else if(Input.GetKeyDown(KeyCode.Alpha2)){index = 2;}
        else if(Input.GetKeyDown(KeyCode.Alpha3)){index = 3;}
        else if(Input.GetKeyDown(KeyCode.Alpha4)){index = 4;}
        else if(Input.GetKeyDown(KeyCode.Alpha5)){index = 5;}

        //Se envia el indice a los slots para actualizar el selector
        cv.GetComponent<Slots_Controller>().setIndex(index);

        //Si presionamos la Q y existe un objeto en ese slot se dropea y se le avisa al slot que oculte la imagen
        if(Input.GetKeyDown(KeyCode.Q)){
            string colecAux = cv.GetComponent<Slots_Controller>().GetContent(index);
            int auxindex = -1;
            for(int i = 0; i < colleccionables.Count;i++){
                if(colleccionables[i].GetComponent<SpriteRenderer>().sprite.name == colecAux){
                    auxindex = i;
                }
            }
            if(auxindex != -1){
                UsarInventario(colleccionables[auxindex]);
                cv.GetComponent<Slots_Controller>().Drop(index);
            }
            
        }
    }

    private void UsarInventario(GameObject Item){
        Item.transform.SetParent(null);
        Item.transform.position = transform.position;
        Item.SetActive(true);
        Item.GetComponent<ColeccionableController>().setPickable(false);
    }
}
