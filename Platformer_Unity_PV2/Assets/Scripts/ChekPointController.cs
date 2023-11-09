using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChekPointController : MonoBehaviour
{
    private bool isTrigger = false;
    [SerializeField] private GameObject Label;
    [SerializeField] private int CheckIndex;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject UI;
    private float degree = 0;

    Color Green = new Color(0.0f, 0.816f, 0.137f);
    Color Red = new Color(0.895f, 0f, 0.219f);


    // Start is called before the first frame update
    void Start()
    {
        if(PersistenceManager.Instance.GetInt("CheckIndex") == CheckIndex && PersistenceManager.Instance.GetInt("CheckIndex") != 0){
            Player.transform.position = new Vector3(transform.position.x, transform.position.y, Player.transform.position.z);
        }
    }

    void FixedUpdate() {
        Label.transform.position = new Vector3(Label.transform.position.x, Label.transform.position.y + Mathf.Sin(degree) * 0.0025f, Label.transform.position.z);
        degree += 0.08f;
    }

    // Update is called once per frame
    void Update()
    {
        if(isTrigger && Input.GetKeyDown(KeyCode.G)){
            PersistenceManager.Instance.SetInt("Lifes",Player.GetComponent<Lifes>().getLifes());
            PersistenceManager.Instance.SetInt("Xp",Player.GetComponent<Progression>().getXp());
            PersistenceManager.Instance.SetInt("Level",Player.GetComponent<Progression>().getLevel());
            PersistenceManager.Instance.SetInt("CheckIndex",CheckIndex);
            PersistenceManager.Instance.SetString("Slot1",UI.GetComponent<Slots_Controller>().GetContent(1));
            PersistenceManager.Instance.SetString("Slot2",UI.GetComponent<Slots_Controller>().GetContent(2));
            PersistenceManager.Instance.SetString("Slot3",UI.GetComponent<Slots_Controller>().GetContent(3));
            PersistenceManager.Instance.SetString("Slot4",UI.GetComponent<Slots_Controller>().GetContent(4));
            PersistenceManager.Instance.SetString("Slot5",UI.GetComponent<Slots_Controller>().GetContent(5));
            PersistenceManager.Instance.Save();
            Label.GetComponent<SpriteRenderer>().color = Green;
            Label.transform.GetChild(0).GetComponent<TextMeshPro>().text = "Progress has been saved";
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        isTrigger = true;
        Label.GetComponent<SpriteRenderer>().color = Red;
        Label.transform.GetChild(0).GetComponent<TextMeshPro>().text = "Press G to save";
        Label.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D other) {
        isTrigger = false;
        Label.SetActive(false);
    }
}
