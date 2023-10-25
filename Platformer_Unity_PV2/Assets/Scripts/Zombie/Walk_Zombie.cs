using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk_Zombie : MonoBehaviour
{
    [SerializeField] private float WalkSpeed = 2;
    Vector2 aux; //Poscion en x del jugador y en y del zombi
    private Transform playerTransform;
    private SpriteRenderer miSpriteRenderer;

    void OnEnable() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.GetComponent<Transform>();  
        miSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update(){
        UpdatePlayerX();
        MoveZombie();
        FlipXZombie();
    }

    private void UpdatePlayerX(){
        aux = new Vector2 (playerTransform.position.x,transform.position.y);
    }

    private void MoveZombie(){
        transform.position = Vector2.MoveTowards(transform.position, aux, WalkSpeed * Time.deltaTime);
    }

    private void FlipXZombie(){
        if(aux.x < transform.position.x){
            miSpriteRenderer.flipX = true;
        }
        if(aux.x > transform.position.x){
            miSpriteRenderer.flipX = false;
        }   
    }
}
