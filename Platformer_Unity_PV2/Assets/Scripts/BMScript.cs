using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BMScript : MonoBehaviour
{
    [SerializeField] private GameObject Boss;
    [SerializeField] private GameObject Tile;
    //[SerializeField] private 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        Boss.SetActive(true);
        Tile.SetActive(true);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
