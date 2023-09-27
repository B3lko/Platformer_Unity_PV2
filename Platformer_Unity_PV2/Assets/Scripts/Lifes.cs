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
    private SpriteRenderer render;
    private Color colorOriginal;
    public float intervaloParpadeo = 0.5f;
    Color red = new Color(1f, 0f, 0f); // Color rojo puro
    
    public void ModificarVida(float puntos){
        if(Time.time > InmortalTime + InicioTime){
            InicioTime = Time.time;
            
            StartCoroutine(Parpadear());
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

     private IEnumerator Parpadear(){
        while (Time.time < InmortalTime + InicioTime){
            render.color = red; // Cambia el color a blanco.
            yield return new WaitForSeconds(intervaloParpadeo);

            render.color = colorOriginal; // Restaura el color original.
            yield return new WaitForSeconds(intervaloParpadeo);
        }
    }

    private void OnEnable(){
        miAnimator = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
        colorOriginal = render.color;
    }



    public bool EstasVivo(){
        return vida > 0;
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (!collision.gameObject.CompareTag("Meta")) { return; }
        Debug.Log("GANASTE");
    }
}