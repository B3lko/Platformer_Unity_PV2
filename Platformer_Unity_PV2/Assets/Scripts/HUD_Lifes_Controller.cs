using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD_Controller : MonoBehaviour
{
    [SerializeField] private GameObject Hearth;
    [SerializeField] private GameObject ContenedorVidas;
    [SerializeField] private int cantVidas;

    [SerializeField] private GameObject Player;
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
            if(Player.GetComponent<Lifes>().getLifes() < i+1){
                Hearths[i].GetComponent<Hearth_Controller>().ChangeState(false);
            }
        }

    }

    public void setLife(int Life){
        for(int i = 0; i<Hearths.Count; i++){
            if(i+1>Life){
                Hearths[i].GetComponent<Hearth_Controller>().ChangeState(false);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
