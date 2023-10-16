using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUIController : MonoBehaviour
{
    public void LoadNextScene(){
        int actualIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(actualIndex + 1);
    }
    
}
