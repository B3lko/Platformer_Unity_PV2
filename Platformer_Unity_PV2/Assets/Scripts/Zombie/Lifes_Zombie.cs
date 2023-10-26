using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifes_Zombie : MonoBehaviour
{
    [SerializeField] private int Lifes;
    
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Bullet")){
            Lifes--;
            CheckLifes();
        }
    }

    private void CheckLifes(){
        if(Lifes <= 0){
            DestroyZombie();
        }
    }

    public void SetLifes(int lifes){
        Lifes = lifes;
    }

    private void DestroyZombie(){
        gameObject.SetActive(false);
    }

}
