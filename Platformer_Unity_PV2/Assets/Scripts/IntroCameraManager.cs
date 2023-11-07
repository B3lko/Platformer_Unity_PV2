using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCameraManager : MonoBehaviour
{
    [SerializeField] private GameObject MainCamera;
    [SerializeField] private GameObject IntroCamera;
    [SerializeField] private GameObject IntroAnimation;
    // Start is called before the first frame update
    void Start()
    {
        if(PersistenceManager.Instance.HasKey("Xp")){
            MainCamera.SetActive(true);
            IntroCamera.SetActive(false);
            IntroAnimation.SetActive(false);
        }
        else{
            MainCamera.SetActive(false);
            IntroCamera.SetActive(true);
            IntroAnimation.SetActive(true);
        }
    }

}
