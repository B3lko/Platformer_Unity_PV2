using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Script : MonoBehaviour
{
    [SerializeField] private int Lifes = 10;
    [SerializeField] private int estadoActual;
    [SerializeField] private float tiempoActualEspera;
    [SerializeField] private float Tiempo_Moverse;
    [SerializeField] private float Tiempo_invocar_Zombies;
    [SerializeField] private float Tiempo_invocar_Bats;
    [SerializeField] private ParticleSystem Bats;
    [SerializeField] private GameObject[] Tumbas;
    [SerializeField] private GameObject Tile;
    [SerializeField] private float TimeDeath;
    [SerializeField] private ParticleSystem Blood;
    private float InicioDeath;
    private const int Move = 0;
    private const int InvokeZombies = 1;
    private const int InvokeBats = 2;
    private bool isDead = false;
    private Animator miAnimator;
    private Rigidbody2D miRigidbody2D;
    private int zombies = 0;

    [SerializeField] private float Tiempo_Embestida;
    [SerializeField] private float Velocidad_EmbestidaX;
    [SerializeField] private float Velocidad_EmbestidaY;
    //private const int 
     //player.GetComponent<Progression>();
    GameObject player;
    //GameObject playerProgresion = player.GetComponent<Progression>();  


    // Start is called before the first frame update
    private void OnEnable()
    {
        miAnimator = GetComponent<Animator>();
        miRigidbody2D = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");  
    }

    void Start(){
        estadoActual = Move;
        StartCoroutine(Boss_Behavior());
    }

    private IEnumerator Boss_Behavior(){
        while(Lifes > 0){
            switch(estadoActual){
                case Move:
                    StartCoroutine(MoveC());
                    tiempoActualEspera = Tiempo_Moverse;
                    break;
                case InvokeZombies:
                    StartCoroutine(InvokeZ());
                    tiempoActualEspera = Tiempo_invocar_Zombies;
                    break;
                case InvokeBats:
                    StartCoroutine(InvokeB());
                    tiempoActualEspera = Tiempo_invocar_Bats;
                    break;
            }
            yield return new WaitForSeconds(tiempoActualEspera);
            ActualizarEstado();
        }
    }

    private IEnumerator MoveC(){

        Vector2 posIncial = transform.position;
        Vector2 posObjetivo = new Vector2(transform.position.x - Velocidad_EmbestidaX, transform.position.y - Velocidad_EmbestidaY);
        Vector2 posObjetivo2= new Vector2(transform.position.x + Velocidad_EmbestidaX, transform.position.y - Velocidad_EmbestidaY);

        float tiempoInicio = Time.time;
        while (Time.time < tiempoInicio + Tiempo_Embestida){
            transform.position = Vector2.Lerp(posIncial,posObjetivo, (Time.time - tiempoInicio) / Tiempo_Embestida);
            yield return null;
        }

        tiempoInicio = Time.time;
        while (Time.time < tiempoInicio + Tiempo_Embestida){
            transform.position = Vector2.Lerp(posObjetivo,posObjetivo2, (Time.time - tiempoInicio) / Tiempo_Embestida);
            yield return null;
        }

        tiempoInicio = Time.time;
        while (Time.time < tiempoInicio + Tiempo_Embestida){
            transform.position = Vector2.Lerp(posObjetivo2,posIncial, (Time.time - tiempoInicio) / Tiempo_Embestida);
            yield return null;
        }
        yield return null;
    }

    private IEnumerator InvokeZ(){
        if(zombies == 0){
            zombies = 3;
            miAnimator.SetBool("isInvoking",true);
            for(int i=0;i<Tumbas.Length;i++){
                Tumbas[i].GetComponent<SpawnerController>().SpawnObject();
            }
            yield return new WaitForSeconds(5.0f);
        }
        else{
             yield return null;
        }
        
    }
    private IEnumerator InvokeB(){
        miAnimator.SetBool("isInvoking",true);
        Bats.Play();
        yield return new WaitForSeconds(5.0f);
        miAnimator.SetBool("isInvoking",false);
    }
    private void ActualizarEstado(){
        estadoActual = Random.Range(0,3);
    }    
        
    


    // Update is called once per frame
    void Update()
    {
        if(Lifes<=0 && Time.time > InicioDeath + TimeDeath){
            player.GetComponent<Progression>().ModXp(25);
            Destroy(gameObject);
        }
    }

    public void ZombieDead(){
        //player.GetComponent<Progression>();
         player.GetComponent<Progression>().ModXp(5);
        zombies -= 1;
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.CompareTag("Box") && !isDead){
            Lifes--;
            if(Lifes<=0){
                miAnimator.SetBool("Death",true);
                Tile.SetActive(false);
                Blood.Play();
                InicioDeath = Time.time;
            }
        }
        if (collision.gameObject.CompareTag("Player")){
            collision.GetComponent<Lifes>().SubtractLife(1);
        }
    }
}
