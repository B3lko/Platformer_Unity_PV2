using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioClip MetaSound;
    private AudioSource miAudioSource;

    private void OnEnable(){
        miAudioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision){
         if (!collision.gameObject.CompareTag("Player")) { return; }
         miAudioSource.PlayOneShot(MetaSound);
    }
}
