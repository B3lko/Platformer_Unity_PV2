using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] int puntos = 5;
    [SerializeField] private float WalkSpeed = 2;
    [SerializeField] private AudioClip BiteSFX;
    private AudioSource miAudioSource;
    bool AuxOnce = false;
    private Animator miAnimator;
    private Rigidbody2D miRigidbody2D;
    private Transform playerTransform;
    private SpriteRenderer miSpriteRenderer;
    private BoxCollider2D miBoxCollider2D;
    Vector2 aux; //Poscion en x del jugador y en y del zombie
    private void OnEnable()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.GetComponent<Transform>();  
        miRigidbody2D = GetComponent<Rigidbody2D>();
        miSpriteRenderer = GetComponent<SpriteRenderer>();
        miAudioSource = GetComponent<AudioSource>();
        miAnimator = GetComponent<Animator>();
        miBoxCollider2D = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        aux = new Vector2 (playerTransform.position.x,transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, aux, WalkSpeed * Time.deltaTime);

        if(aux.x < transform.position.x){
            miSpriteRenderer.flipX = true;
        }
        if(aux.x > transform.position.x){
            miSpriteRenderer.flipX = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Player")){
            miAudioSource.PlayOneShot(BiteSFX);
            Lifes jugador = collision.gameObject.GetComponent<Lifes>();
            jugador.SubtractLife(puntos);
            miAnimator.SetBool("CEnter",true);
        }
    }
    private void OnCollisionStay2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Player")){
            Lifes jugador = collision.gameObject.GetComponent<Lifes>();
            AnimatorClipInfo[] clipInfo = miAnimator.GetCurrentAnimatorClipInfo(0);
            if(clipInfo[0].clip.name == "Attack" && AuxOnce){
                miAudioSource.PlayOneShot(BiteSFX);
                jugador.SubtractLife(puntos);
                AuxOnce = false;
            }
            if(clipInfo[0].clip.name != "Attack"){
                AuxOnce = true;
            }
        }
    }  
    private void OnCollisionExit2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Player")){
            miAnimator.SetBool("CEnter",false);
        }
    }  
}
