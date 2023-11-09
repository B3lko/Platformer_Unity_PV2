using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoHorizontal : MonoBehaviour
{
    // Variables a configurar desde el editor
    private PerfilJugador perfilJugador;
     [SerializeField] private ParticleSystem RunParticle;

    // Variables de uso interno en el script
    private float moverHorizontal;
    //private Vector2 direccion;

    // Variable para referenciar otro componente del objeto
    private Rigidbody2D miRigidbody2D;
    private Animator miAnimator;
    private SpriteRenderer miSpriteRenderer;
    bool ShiftPressed = false;
    private float Speed;

    // Codigo ejecutado cuando el objeto se activa en el nivel
    private void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
        miAnimator = GetComponent<Animator>();
        miSpriteRenderer = GetComponent<SpriteRenderer>();
        perfilJugador = GetComponent<Player>().perfilJugador;
    }

    private void Start(){
        Speed =  perfilJugador.WalkSpeed1;
    }
    // Codigo ejecutado en cada frame del juego (Intervalo variable)
    private void Update(){
       if(Input.GetKey(KeyCode.LeftShift)){
            ShiftPressed = true;
        }
        else{
            ShiftPressed = false;
        }
        if(ShiftPressed){
            Speed = perfilJugador.RunSpeed1;
        }
        else{
           Speed = perfilJugador.WalkSpeed1;
        }
        if(this.GetComponent<Lifes>().EstasVivo()){
            float moverHorizontal = Input.GetAxis("Horizontal");
            Vector2 newVelocity = miRigidbody2D.velocity;
            newVelocity.x = moverHorizontal * Speed;
            miRigidbody2D.velocity = newVelocity;

            if(!miSpriteRenderer.flipX && newVelocity.x < 0){
               miSpriteRenderer.flipX = true;
            }
            if(miSpriteRenderer.flipX && newVelocity.x > 0){
                miSpriteRenderer.flipX = false;
            }
            float Nvx = (int)newVelocity.x;
            int Vx = (int)Nvx;
            miAnimator.SetInteger("Speed", Vx);
        }
    }
    private void FixedUpdate(){
        if(this.GetComponent<Lifes>().EstasVivo()){
            if(ShiftPressed){
                miAnimator.SetBool("Shift",true);
                RunParticle.Play();
            }
            else{
                miAnimator.SetBool("Shift",false);
            }   
        }
    }
}