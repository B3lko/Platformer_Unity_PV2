using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD_Controller : MonoBehaviour
{
    [SerializeField] private GameObject Hearth;
    [SerializeField] private GameObject ContenedorVidas;
    [SerializeField] private int cantVidas;
    private List<GameObject> Hearths;

    // Start is called before the first frame update
    void OnEnable()
    {
        Hearths = new List<GameObject>();
    }
    void Start()
    {
        if(isHearthsEmpty()){
            CargarContenedor(cantVidas);
        }
    }
    private bool isHearthsEmpty(){
        return ContenedorVidas.transform.childCount == 0;
    }

    void CargarContenedor(int cantVidas){
        for(int i = 0; i<cantVidas; i++){
            Hearths.Add(Instantiate(Hearth,ContenedorVidas.transform));
        }
    }

    public void setDamage(int Damage){
        Debug.Log("LLego: " + Damage);
        for(int i = 0; i<Damage;i++){
            if(Hearths[i]){
                if(Hearths[i].GetComponent<Hearth_Controller>().getState()){
                    Hearths[i].GetComponent<Hearth_Controller>().ChangeState(false);
                }
                else{
                     Damage++;
                }
            }
            else{
                return;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
