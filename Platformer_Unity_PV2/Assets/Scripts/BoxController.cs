using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    private GameObject SB;
    void OnEnable() {
        SB = GameObject.FindGameObjectWithTag("SwitchBox");  
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= 30 && this != null){
            SB.GetComponent<SwitchBoxController>().BoxDestroy();
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Boss")){
             SB.GetComponent<SwitchBoxController>().BoxDestroy();
            Destroy(gameObject);
        }
    }
}
