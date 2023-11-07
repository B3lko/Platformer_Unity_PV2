using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Progression : MonoBehaviour
{
    private PerfilJugador perfilJugador;
    private int level = 1;
    private int Xp = 0;
    [SerializeField] private GameObject TextLevel;
    [SerializeField] private GameObject TextExp;



public int getXp(){
    return Xp;
}

public int getLevel(){
    return level;
}
void OnEnable()
{
    perfilJugador = GetComponent<Player>().perfilJugador;
    if(PersistenceManager.Instance.HasKey("Xp")){
        level = PersistenceManager.Instance.GetInt("Level");
        Xp = PersistenceManager.Instance.GetInt("Xp");
    }
    TextLevel.GetComponent<TextMeshProUGUI>().text = "Level: " + level;
    TextExp.GetComponent<TextMeshProUGUI>().text = "Exp: " + Xp;
}

    public void ModXp(int newXP){
        Xp += newXP;
        TextExp.GetComponent<TextMeshProUGUI>().text = ("Exps: " + Xp);
        if(Xp >= level*perfilJugador.ScaleXp){LevelUp();}
    }

    private void LevelUp(){
        Xp -= level*perfilJugador.ScaleXp;
        level++;
        TextLevel.GetComponent<TextMeshProUGUI>().text = "Level: " + level;
        TextExp.GetComponent<TextMeshProUGUI>().text = ("Exps: " + Xp);
    }
}
