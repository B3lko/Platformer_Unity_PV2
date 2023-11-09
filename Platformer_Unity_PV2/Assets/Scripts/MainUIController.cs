using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUIController : MonoBehaviour
{
    [SerializeField] private GameObject btnCont;
    [SerializeField] private GameObject btnOpt;
    [SerializeField] private GameObject CanvasOpt;

    void OnEnable() {
        if(!PersistenceManager.Instance.HasKey("Lifes")){
            btnCont.SetActive(false);
        }
    }
    public void LoadNextScene(){
        int actualIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(actualIndex + 1);
    }

    public void ExitGame(){
        Application.Quit();
    }

    public void setOptions(){
        CanvasOpt.SetActive(true);
        gameObject.SetActive(false);
    }

    public void DeleteSaveGame(){
        PersistenceManager.Instance.DeleteKey("Slot1");               
        PersistenceManager.Instance.DeleteKey("Slot2");               
        PersistenceManager.Instance.DeleteKey("Slot3");               
        PersistenceManager.Instance.DeleteKey("Slot4");               
        PersistenceManager.Instance.DeleteKey("Slot5");                            
        PersistenceManager.Instance.DeleteKey("Lifes");               
        PersistenceManager.Instance.DeleteKey("Xp");               
        PersistenceManager.Instance.DeleteKey("Level");               
        PersistenceManager.Instance.DeleteKey("CheckIndex");                             
    }

    
}
