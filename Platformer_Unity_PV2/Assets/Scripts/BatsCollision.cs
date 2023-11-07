using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatsCollision : MonoBehaviour
{
    void OnParticleCollision(GameObject other){
        if(other.CompareTag("Player")){
            other.GetComponent<Lifes>().SubtractLife(1);
        }
        
    }
}
