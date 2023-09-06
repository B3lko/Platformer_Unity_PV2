using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoHorizontal : MonoBehaviour
{
    // Variables a configurar desde el editor
    [Header("Configuracion")]
    [SerializeField] float WalkSpeed = 5f;
    [SerializeField] float RunSpeed = 10f;
    float Speed;
     [SerializeField] private ParticleSystem RunParticle;

    // Variables de uso interno en el script
    private float moverHorizontal;
    private Vector2 direccion;

    // Variable para referenciar otro componente del objeto
    private Rigidbody2D miRigidbody2D;
    private Animator miAnimator;
    private SpriteRenderer miSpriteRenderer;
    bool ShiftPressed = false;

    // Codigo ejecutado cuando el objeto se activa en el nivel
    private void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
        miAnimator = GetComponent<Animator>();
        miSpriteRenderer = GetComponent<SpriteRenderer>();
    }

private void Start()
{
    Speed = WalkSpeed;
}
    // Codigo ejecutado en cada frame del juego (Intervalo variable)
    private void Update()
    {
       if(Input.GetKey(KeyCode.LeftShift)){
            ShiftPressed = true;
            Speed = RunSpeed;
        }
        else{
            ShiftPressed = false;
            Speed = WalkSpeed;
        }

        moverHorizontal = Input.GetAxis("Horizontal");
        direccion = new Vector2(moverHorizontal, 0f);

        int VelocidadX = (int)miRigidbody2D.velocity.x;

        if(!miSpriteRenderer.flipX && VelocidadX < 0){
            miSpriteRenderer.flipX = true;
        }
        if(miSpriteRenderer.flipX && VelocidadX > 0){
            miSpriteRenderer.flipX = false;
        }
        miAnimator.SetInteger("Speed", VelocidadX);
    }
    private void FixedUpdate()
    {
        if(this.GetComponent<Lifes>().EstasVivo()){
            if(ShiftPressed && (miRigidbody2D.velocity.x > 1.5 || miRigidbody2D.velocity.x < -1.5)){
                miAnimator.SetBool("Shift",true);
                RunParticle.Play();
            }
            else miAnimator.SetBool("Shift",false);
            if(miRigidbody2D.velocity.x < 10 && miRigidbody2D.velocity.x > -10)
            miRigidbody2D.AddForce(direccion * Speed);
        }
    }
}