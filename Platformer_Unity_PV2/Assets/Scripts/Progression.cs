using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progression : MonoBehaviour
{
    private PerfilJugador perfilJugador;


void OnEnable()
{
    perfilJugador = GetComponent<Player>().perfilJugador;
}
    public void ModXp(int newXP){
        perfilJugador.XP += newXP;
        Debug.Log("EXP:" + perfilJugador.XP);
        if(perfilJugador.XP >= perfilJugador.XPNextLevel){LevelUp();}
    }

    private void LevelUp(){
        perfilJugador.level++;
        perfilJugador.XP -= perfilJugador.XPNextLevel;
        perfilJugador.XPNextLevel += perfilJugador.ScaleXp;
        Debug.Log("Nuevo nivel: " + perfilJugador.level);
    }
}
