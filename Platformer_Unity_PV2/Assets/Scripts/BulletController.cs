using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool isGoingLeft = false;
    private SpriteRenderer miSpriteRenderer;
    // Start is called before the first frame update
    void OnEnable() {
        miSpriteRenderer = GetComponent<SpriteRenderer>();
    }

  
    // Update is called once per frame
    void FixedUpdate() {
        if(isGoingLeft){
            transform.position = new Vector2(transform.position.x + speed,transform.position.y);
        }
        else{
            transform.position = new Vector2(transform.position.x - speed,transform.position.y);
        }
        
    }
    void Update(){
    
    }

    void OnTriggerEnter2D(Collider2D other) {
        gameObject.SetActive(false);
    }

      public void setDir(bool dir){
        isGoingLeft = dir;
        if(!dir){
            miSpriteRenderer.flipX = true;
        }
        else{
            miSpriteRenderer.flipX = false;
        }
    }
}