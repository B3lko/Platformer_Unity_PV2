using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetItem : MonoBehaviour
{
public GameObject item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void changeSprite(Sprite spr)
    {
        item.SetActive(true);
        item.GetComponent<Image>().sprite = spr; 
    }

    public string getName(){
        return item.GetComponent<Image>().sprite.name;
    }
    public void Drop(){
        item.SetActive(false);
    }
}
