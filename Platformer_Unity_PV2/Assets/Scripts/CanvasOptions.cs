using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CanvasOptions : MonoBehaviour
{
    [SerializeField] private GameObject CanvasMain;
    [SerializeField] private GameObject btnBck;
    public Toggle toggle;

    public TMP_Dropdown resolucionesDropDown;
    Resolution[] resoluciones;


    public void setMain(){
        CanvasMain.SetActive(true);
        gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start(){
        if(Screen.fullScreen) toggle.isOn = true;
        else toggle.isOn = false;
        RevisarResoluciones();
    }

    public void setFullScreen(bool state){
        Screen.fullScreen = state;
    }

    public void RevisarResoluciones(){
        resoluciones = Screen.resolutions;
        resolucionesDropDown.ClearOptions();
        List<string> opciones = new List<string>();
        int resolucionActual = 0;

        for(int i = 0; i < resoluciones.Length; i++){
            string opcion = resoluciones[i].width + " X " + resoluciones[i].height;
            opciones.Add(opcion);

            if(Screen.fullScreen && resoluciones[i].width == Screen.currentResolution.width &&
            resoluciones[i].height == Screen.currentResolution.height){
                resolucionActual = i;
            }
        }
        resolucionesDropDown.AddOptions(opciones);
        resolucionesDropDown.value = resolucionActual;
        resolucionesDropDown.RefreshShownValue();
    }

    public void ChangeResolution(int indexResolution){
        PersistenceManager.Instance.SetInt("indexResolution",indexResolution);
        Resolution resolucion = resoluciones[indexResolution];
        Screen.SetResolution(resolucion.width,resolucion.height,Screen.fullScreen);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
