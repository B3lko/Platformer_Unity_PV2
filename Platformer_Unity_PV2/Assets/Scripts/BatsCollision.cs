using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatsCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnParticleCollision(GameObject other){
        if(other.CompareTag("Player")){
            other.GetComponent<Lifes>().ModificarVida(-1);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
