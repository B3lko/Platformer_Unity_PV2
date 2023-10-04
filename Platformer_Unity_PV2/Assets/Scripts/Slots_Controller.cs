using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slots_Controller : MonoBehaviour
{
    [SerializeField] private int Size;
    [SerializeField] private float SpaceBetween;
    [SerializeField] private GameObject Slot;
    private List<GameObject> Slots;
    private List<int> SlotsContent;
    private List<Sprite> listaSprites;
    [SerializeField] private GameObject Teeth;
    [SerializeField] private GameObject Hearth;
    [SerializeField] private GameObject Skull;
    [SerializeField] private GameObject Brain;
    [SerializeField] private GameObject Chest;

    void OnEnable() {
        Slots = new List<GameObject>();
        SlotsContent = new List<int>();
        listaSprites = new List<Sprite>();
    }


    void Start(){
        EscalarObjetos();
        InstanciarObjetos();
    }

    private void InstanciarObjetos(){
        for (int i = 0; i < Size; i++){
            Slots.Add(Slot);
             SlotsContent.Add(0);
        }
        Slots[0] = Instantiate(Slots[0], new Vector2(1,10), transform.rotation);
        Slots[0].transform.SetParent(gameObject.transform);
        Slots[0].transform.position = new Vector2(gameObject.transform.position.x - 10,gameObject.transform.position.y + 4);
        for (int i = 1; i < Size; i++){
            Slots[i] = Instantiate(Slots[i], new Vector2(Slots[i].transform.position.x + SpaceBetween,10), transform.rotation);
            Slots[i].transform.SetParent(gameObject.transform);
            Slots[i].transform.position = new Vector2(Slots[i-1].transform.position.x + SpaceBetween,Slots[i-1].transform.position.y);
        }
    }

    private void EscalarObjetos(){
        Hearth.transform.localScale = new Vector3(45.0f,45.0f,0.0f);
        Skull.transform.localScale = new Vector3(45.0f,45.0f,0.0f);
        Teeth.transform.localScale = new Vector3(45.0f,45.0f,0.0f);
        Chest.transform.localScale = new Vector3(45.0f,45.0f,0.0f);
        Brain.transform.localScale = new Vector3(45.0f,45.0f,0.0f);
    }

    public void SetContent(int n){
        n--;
        for (int i = 0; i < Size; i++){
            if(SlotsContent[i] == 0){
                SlotsContent[i] = n;
                switch(n){
                    case 0:
                        Skull.SetActive(true);
                        Skull.transform.SetParent(Slots[n].transform);
                        Skull.transform.position = new Vector2(Skull.transform.parent.transform.position.x,Skull.transform.parent.transform.position.y);break;
                    case 1:
                        Hearth.SetActive(true);
                        Hearth.transform.SetParent(Slots[n].transform);
                        Hearth.transform.position = new Vector2(Hearth.transform.parent.transform.position.x,Hearth.transform.parent.transform.position.y);break;
                    case 2:
                        Chest.SetActive(true);
                        Chest.transform.SetParent(Slots[n].transform);
                        Chest.transform.position = new Vector2(Chest.transform.parent.transform.position.x,Chest.transform.parent.transform.position.y);break;
                    case 3:
                        Brain.SetActive(true);
                        Brain.transform.SetParent(Slots[n].transform);
                        Brain.transform.position = new Vector2(Brain.transform.parent.transform.position.x,Brain.transform.parent.transform.position.y);break;
                    case 4:
                        Teeth.SetActive(true);
                        Teeth.transform.SetParent(Slots[n].transform);
                        Teeth.transform.position = new Vector2(Teeth.transform.parent.transform.position.x,Teeth.transform.parent.transform.position.y);break;
                }
                return;
            }
        }
    }


    void Update(){
    }

}
