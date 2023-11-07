using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaController : MonoBehaviour
{
    [SerializeField] private AudioClip MetaSound;
    [SerializeField] private GameObject Winner;
    private AudioSource miAudioSource;

    private void OnEnable(){
        miAudioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (!collision.gameObject.CompareTag("Player")) { return; }
        miAudioSource.PlayOneShot(MetaSound);
        Winner.SetActive(true);
    }
}
