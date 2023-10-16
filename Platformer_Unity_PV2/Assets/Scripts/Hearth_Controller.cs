using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Hearth_Controller : MonoBehaviour
{
    private bool isFull = true;
    [SerializeField] private Sprite Full;
    [SerializeField] private Sprite Empty;
    private Image image;

    void OnEnable(){
        image = GetComponent<Image>();
    }

    public void ChangeState(bool State){
        isFull = State;
        if(isFull){
            image.sprite = Full;
        }
        else{
            image.sprite = Empty;
        }
    }

    public bool getState(){
        return isFull;
    }
}
