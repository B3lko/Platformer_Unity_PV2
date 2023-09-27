using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifes : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] private float vida = 5f;
    [SerializeField] private ParticleSystem Blood;
    [SerializeField] private float InmortalTime;
    private float InicioTime = 0;
    private Animator miAnimator;
    
    public void ModificarVida(float puntos){
        if(Time.time > InmortalTime + InicioTime){
            InicioTime = Time.time;
            if(puntos < 0){
                Blood.Play();
            }
            vida += puntos;
            if(vida <= 0 ){
                miAnimator.SetBool("Death",true);
                Debug.Log("PERDISTE");
            }
            Debug.Log("Vidas: " + vida);
        }
    }

    private void OnEnable(){
        miAnimator = GetComponent<Animator>();
    }

    public bool EstasVivo(){
        return vida > 0;
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (!collision.gameObject.CompareTag("Meta")) { return; }
        Debug.Log("GANASTE");
    }
}