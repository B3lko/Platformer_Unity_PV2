using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progression : MonoBehaviour
{
    public int Level;
    public int xP;
    public int xPNextLevel;
    public int scaleXp;

    public void ModXp(int newXP){
        this.xP += newXP;
        Debug.Log("EXP:" + this.xP);
        if(xP >= xPNextLevel){LevelUp();}
    }

    private void LevelUp(){
        Level++;
        xP -= xPNextLevel;
        xPNextLevel += scaleXp;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
