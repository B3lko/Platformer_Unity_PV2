using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] float puntos = 5f;
    //[SerializeField] private float fuerzaSalto = 5f;
    [SerializeField] private float WalkSpeed = 2;
    // Start is called before the first frame update

    private Rigidbody2D miRigidbody2D;
    //private GameObject player;
    private Transform playerTransform;
    Vector2 aux; //Poscion en x del jugador y en y del zombie
    private void OnEnable()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.GetComponent<Transform>();  
        miRigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        aux = new Vector2 (playerTransform.position.x,transform.position.x);
        transform.position = Vector2.MoveTowards(transform.position, aux, WalkSpeed * Time.deltaTime);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //miRigidbody2D.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        if (collision.gameObject.CompareTag("Player"))
        {
            Lifes jugador = collision.gameObject.GetComponent<Lifes>();
            jugador.ModificarVida(-puntos);
            Debug.Log(" PUNTOS DE DAÑO REALIZADOS AL JUGADOR "+ puntos);
        }
    }


}
