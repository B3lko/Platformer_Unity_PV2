using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Script : MonoBehaviour
{
    [SerializeField] private int Lifes = 10;
    private int estadoActual;
    private const int InvokeZombies = 1;
    private Animator miAnimator;
    //private const int 

    // Start is called before the first frame update
    private void OnEnable()
    {
        miAnimator = GetComponent<Animator>();
    }

    //private IEnumerator Boss_Behavior(){
       /* while(true){
            switch(estadoActual){
                case InvokeZombies:
                case 
            }
        }
    }

    {
        
        yield return null;
    }*/
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.CompareTag("Box")){
            Lifes--;
            if(Lifes<=0){
            miAnimator.SetBool("Death",true);
            }
            Debug.Log(Lifes);
        }
    }
}
