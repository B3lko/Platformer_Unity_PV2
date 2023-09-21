using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBoxController : MonoBehaviour
{
    public GameObject Prefab;
    Vector3 PosBox1;
    Vector3 PosBox2;
      
    // Start is called before the first frame update
    void Start()
    {
        PosBox1 = new Vector3(26.0f,39.0f,0.0f);
      PosBox2 = new Vector3(33.0f,39.0f,0.0f);
    }

    private void OnTriggerStay2D(Collider2D collision){
        if (collision.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E)){
            Instantiate(Prefab, PosBox1, transform.rotation); 
            Instantiate(Prefab, PosBox2, transform.rotation); 
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
