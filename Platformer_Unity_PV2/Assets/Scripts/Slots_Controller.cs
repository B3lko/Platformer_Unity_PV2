using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slots_Controller : MonoBehaviour
{
    [SerializeField] private int Size;
    [SerializeField] private float SpaceBetween;
    [SerializeField] private GameObject Slot;
    [SerializeField] private GameObject Slotparent;
    [SerializeField] private GameObject Selector;
    [SerializeField] private GameObject bolsa;
    [SerializeField] private GameObject Coleccionables;


    private List<GameObject> Slots;
    private List<bool> SlotsContent;
    private List<Sprite> listaSprites;
    [SerializeField] private List<Sprite> Listspr;


    void OnEnable() {
        Slots = new List<GameObject>();
        SlotsContent = new List<bool>();
        listaSprites = new List<Sprite>();
    }


    void Start(){
        InstanciarObjetos();
        Selector.transform.SetParent(Slots[0].transform);
        Selector.transform.position = new Vector3(0,0,1);
        Selector.SetActive(true);
        Selector.transform.position = Slots[0].transform.position;
        LoadSlots();
    }

    private void LoadSlots(){
        for(int i = 0; i < Size; i++){
            if(PersistenceManager.Instance.GetString("Slot" + (1 + i)) != "Vacio" && PersistenceManager.Instance.HasKey("Slot" + (i + 1))){
                string spr = PersistenceManager.Instance.GetString("Slot" + (i + 1));
                SlotsContent[i] = true;
                for(int j = 0; j < Size; j++){
                    if(spr == Listspr[j].name){
                        Slots[i].GetComponent<SetItem>().changeSprite(Listspr[j]);
                        for(int k = 0; k < Coleccionables.transform.childCount; k++){
                            if(Coleccionables.transform.GetChild(k).GetComponent<SpriteRenderer>().sprite.name == spr){
                                GameObject GM = Coleccionables.transform.GetChild(k).gameObject;
                                GM.SetActive(false);
                                bolsa.transform.parent.GetComponent<Coleccionar>().Load(GM);
                                Coleccionables.transform.GetChild(k).transform.SetParent(bolsa.transform);
                            }
                        }
                    }
                }
                
            }    
           
        }
    }

    private void InstanciarObjetos(){
        for (int i = 0; i < Size; i++){
            Slots.Add(Instantiate(Slot,transform.position,transform.rotation));
            Slots[i].transform.SetParent(Slotparent.transform);
            Slots[i].transform.localScale= new Vector3(1,1,1);
            SlotsContent.Add(false);
        }
    }


//Colocar un objeto en el primer Slot disponible
    public void SetContent(string spr){
        int aux = 0; 
        for (int i = 0; i < Listspr.Count; i++){
            if(spr == Listspr[i].name){
                aux = i;
                for (int j = 0; j < SlotsContent.Count; j++){
                    if(!SlotsContent[j]){
                        SlotsContent[j] = true;
                        Sprite sprite = Listspr[aux];
                        Slots[j].GetComponent<SetItem>().changeSprite(sprite);
                        return;
                    }
                }
            }
        }
    }

//Retornar el nombre del objeto en el slot
    public string GetContent(int index){
        index--;
        if(SlotsContent[index]){
            return  Slots[index].GetComponent<SetItem>().getName();
        }
        else{
           return "Vacio";
        }
    }

//Dropear el objeto
    public void Drop(int index){
        index--;
        if(SlotsContent[index]){
            SlotsContent[index] = false;
            Slots[index].GetComponent<SetItem>().Drop();
        }
    }

//Actualizar el slot en el esta el selector
    public void setIndex(int index){
        Selector.transform.SetParent(Slots[index-1].transform);
        Selector.transform.position = Slots[index-1].transform.position;
    }
}
