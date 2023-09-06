using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    // Variables a configurar desde el editor
    [Header("Configuracion")]
    [SerializeField] private float fuerzaSalto = 5f;
    [SerializeField] private AudioClip JumpSFX;
    [SerializeField] private AudioClip CollisionSFX;
    [SerializeField] private ParticleSystem Grass;
     [SerializeField] private ParticleSystem JumpParticle;

    // Variables de uso interno en el script
    private bool puedoSaltar = true;
    private bool saltando = false;

    // Variable para referenciar otro componente del objeto
    private Rigidbody2D miRigidbody2D;
    private AudioSource miAudioSource;
    private Animator miAnimator;

    // Codigo ejecutado cuando el objeto se activa en el nivel
    private void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
        miAudioSource = GetComponent<AudioSource>();
        miAnimator = GetComponent<Animator>();
    }

    // Codigo ejecutado en cada frame del juego (Intervalo variable)
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && puedoSaltar && this.GetComponent<Lifes>().EstasVivo()){
            puedoSaltar = false;
        }
    }

    private void FixedUpdate()
    {
        if (!puedoSaltar && !saltando)
        {
            miAnimator.SetBool("JumpMax",false);
            miAnimator.SetBool("EndJump",false);
            miAnimator.SetBool("JumpStart",true);
            miRigidbody2D.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            saltando = true;
            JumpParticle.Play();
            if(miAudioSource.isPlaying){
                return;
            }
            miAudioSource.PlayOneShot(JumpSFX);
            
        }
        if(saltando && miRigidbody2D.velocity.y > 0){
            miAnimator.SetBool("JumpMax",true);
        }
    }

    // Codigo ejecutado cuando el jugador colisiona con otro objeto
    private void OnCollisionEnter2D(Collision2D collision){
        GameObject GO = collision.gameObject;
        if(GO.tag == "Floor"){
            if(saltando){
                miAnimator.SetBool("EndJump",true);
            }
            miAnimator.SetBool("JumpStart",false);
            puedoSaltar = true;
            saltando = false;
            miAudioSource.PlayOneShot(CollisionSFX);
            Grass.Play();
        }
    }
}