using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistenceManager : MonoBehaviour
{
    public static PersistenceManager Instance {get; private set;}

    void Awake() {
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }

    public void SetFloat(string key, float value){
        PlayerPrefs.SetFloat(key,value);
    }

    public void SetInt(string key, int value){
        PlayerPrefs.SetInt(key,value);
    }
    public void SetString(string key, string value){
        PlayerPrefs.SetString(key,value);
    }

    public string GetString(string key){
        return PlayerPrefs.GetString(key);
    }

    public void DeleteKey(string key){
        PlayerPrefs.DeleteKey(key);
    }

    public void DeleteAll(){
        PlayerPrefs.DeleteAll();
    }
    public bool HasKey(string key){
        return PlayerPrefs.HasKey(key);
    }
    public int GetInt(string key){
        return PlayerPrefs.GetInt(key);
    }

    public void Save(){
        PlayerPrefs.Save();
    }

    public void SaveAndExit(){
        PlayerPrefs.Save();
        Application.Quit();
    }

    public void setFullScreen(bool state){
        PlayerPrefs.SetInt("FullScreen", state ? 1 : 0);
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
