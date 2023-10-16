using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Lifes : MonoBehaviour
{
    [SerializeField] private ParticleSystem Blood;
    [SerializeField] private UnityEvent<int> OnLivesChanged;
    private PerfilJugador perfilJugador;
    private float InicioTime = 0;
    private Animator miAnimator;
    private SpriteRenderer render;
    private Color colorOriginal;
    Color red = new Color(1f, 0f, 0f); // Color rojo puro
    
    public void SubtractLife(int puntos){
        if(Time.time > perfilJugador.InmortalTime1 + InicioTime){

           
            InicioTime = Time.time;
            
            StartCoroutine(Parpadear());
            if(puntos > 0){
                Blood.Play();
            }
            perfilJugador.Vida -= puntos;

            OnLivesChanged.Invoke(puntos);

            if(perfilJugador.Vida <= 0 ){
                miAnimator.SetBool("Death",true);
                Debug.Log("PERDISTE");
            }

            Debug.Log("Vidas: " + perfilJugador.Vida);
        }
    }

     private IEnumerator Parpadear(){
        while (Time.time < perfilJugador.InmortalTime1 + InicioTime){
            render.color = red; // Cambia el color a blanco.
            yield return new WaitForSeconds(perfilJugador.IntervaloParpadeo);

            render.color = colorOriginal; // Restaura el color original.
            yield return new WaitForSeconds(perfilJugador.IntervaloParpadeo);
        }
    }

    private void OnEnable(){
        miAnimator = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
        colorOriginal = render.color;
        perfilJugador = GetComponent<Player>().perfilJugador;
        //OnLivesChanged.Invoke(perfilJugador.Vida);
    }



    public bool EstasVivo(){
        return perfilJugador.Vida > 0;
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (!collision.gameObject.CompareTag("Meta")) { return; }
        Debug.Log("GANASTE");
    }
}