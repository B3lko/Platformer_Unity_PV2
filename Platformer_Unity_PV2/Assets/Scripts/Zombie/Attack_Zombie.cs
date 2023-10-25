using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Zombie : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] int puntos = 5;
    
    [SerializeField] private AudioClip BiteSFX;
    private AudioSource miAudioSource;
    bool AuxOnce = false;
    private Animator miAnimator;
    private Rigidbody2D miRigidbody2D;
    
    private SpriteRenderer miSpriteRenderer;
    private BoxCollider2D miBoxCollider2D;
    
    private void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
        miSpriteRenderer = GetComponent<SpriteRenderer>();
        miAudioSource = GetComponent<AudioSource>();
        miAnimator = GetComponent<Animator>();
        miBoxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Player")){
            miAudioSource.PlayOneShot(BiteSFX);
            SetState("CEnter",true);
            SubtractLife(collision);
        }
    }

    
    private void OnCollisionStay2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Player")){
            AnimatorClipInfo[] clipInfo = miAnimator.GetCurrentAnimatorClipInfo(0);
            if(clipInfo[0].clip.name == "Attack" && AuxOnce){
                miAudioSource.PlayOneShot(BiteSFX);
                AuxOnce = false;
                SubtractLife(collision);
            }
            if(clipInfo[0].clip.name != "Attack"){
                AuxOnce = true;
            }
        }
    }  

    private void SubtractLife(Collision2D collision){
        Lifes jugador = collision.gameObject.GetComponent<Lifes>();
        jugador.SubtractLife(puntos);
    }

    private void SetState(string name, bool state){
        miAnimator.SetBool(name,state);
    }

    private void OnCollisionExit2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Player")){
            SetState("CEnter",false);
        }
    }  
}
