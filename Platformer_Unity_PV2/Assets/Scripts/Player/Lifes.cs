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

    private int vidas;
    
    public int getLifes(){
        return vidas;
    }
    public void SubtractLife(int puntos){
        if(Time.time > perfilJugador.InmortalTime1 + InicioTime){

           
            InicioTime = Time.time;
            
            StartCoroutine(Parpadear());
            if(puntos > 0){
                Blood.Play();
            }
            vidas -= puntos;

            OnLivesChanged.Invoke(vidas);

            if(vidas <= 0 ){
                miAnimator.SetBool("Death",true);
            }
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

        vidas = perfilJugador.Vida;
            
        if(PersistenceManager.Instance.HasKey("Lifes")){
            vidas = PersistenceManager.Instance.GetInt("Lifes");
        }
    }
     public bool EstasVivo(){
        return vidas > 0;
    }
}