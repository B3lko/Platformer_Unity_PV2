using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseController : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            canvas.SetActive(!canvas.activeSelf);
            if(canvas.activeSelf){
                Time.timeScale = 0.0f;
            }
            else{
                Time.timeScale = 1.0f;
            }
        }
    }

    public void GotoMainMenu(){
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }

    public void ResumeGame(){
        Time.timeScale = 1.0f;
        canvas.SetActive(false);
    }

    
}
