using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BMScript : MonoBehaviour
{
    [SerializeField] private GameObject Boss;
    [SerializeField] private GameObject Tile;
    void OnTriggerEnter2D(Collider2D other) {
        Boss.SetActive(true);
        Tile.SetActive(true);
        Destroy(gameObject);
    }
}
