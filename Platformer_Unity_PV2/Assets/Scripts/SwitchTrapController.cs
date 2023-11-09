using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTrapController : MonoBehaviour
{
    public GameObject Prefab;
    public bool isDestroyed = false;
    // Start is called before the first frame update
    private Animator miAnimator;
    [SerializeField] private GameObject Label;
    //private const int 

    // Start is called before the first frame update
    private void OnEnable()
    {
        miAnimator = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision){
       // Debug.Log("Hopli");
        if (collision.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E)){
            miAnimator.SetBool("IsActive",true);
            Prefab.SetActive(false);
            isDestroyed = true;
        }
        else if(isDestroyed){
            //Instantiate(Prefab, Prefab.transform.position, transform.rotation); 
            Prefab.SetActive(true);
            miAnimator.SetBool("IsActive",false);
            isDestroyed = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other) {
        Label.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D other) {
        Label.SetActive(false);
    }
}
