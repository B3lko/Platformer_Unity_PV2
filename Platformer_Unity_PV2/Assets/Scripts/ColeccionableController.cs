using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColeccionableController : MonoBehaviour
{
    private float startTime;
    public float tiempoLimite = 5000.0f;  
    private bool isPickable = true;
    // Start is called before the first frame update

    public void setPickable(bool pick){
        isPickable = pick;
        startTime = Time.time;
    }

    public bool getPickable(){
        return isPickable;
    }
    // Update is called once per frame
    void Update()
    {
        float tiempoTranscurrido = Time.time - startTime;
        if (tiempoTranscurrido >= tiempoLimite){
            isPickable = true;
        }
    }
}
