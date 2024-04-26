using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Canvas ZoomedInCanvas;
    [SerializeField] Camera fpsCamera;
    [SerializeField] FirstPersonController fpsController;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFOV = 20f;
    [SerializeField] float zoomedInSenstivity = 0.5f;
    [SerializeField] float zoomedOutSenstivity = 2f;
    
    bool ZoomedInToggle = false;
    private void OnDisable() {
        ZoomOut();
    }
    void Start()
    {
        ZoomedInCanvas.enabled = false;
        fpsCamera.fieldOfView = zoomedOutFOV;
        fpsController = GetComponentInParent<FirstPersonController>();
    }
    void Update(){
        if(Input.GetMouseButtonDown(1)){
            if(ZoomedInToggle==false){
                ZoomIn();
            }
            else{
                ZoomOut();
            }
        }
    }
    void ZoomIn(){
        ZoomedInToggle = true;
        fpsCamera.fieldOfView = zoomedInFOV;
        ZoomedInCanvas.enabled = true;
        //fpsController.mouseLook.XSensitivity = zoomedInSenstivity;
        //fpsController.mouseLook.YSensitivity = zoomedInSenstivity;
    }
    public void ZoomOut(){
        ZoomedInToggle = false;
        fpsCamera.fieldOfView = zoomedOutFOV;
        ZoomedInCanvas.enabled = false;
        //fpsController.mouseLook.XSensitivity = zoomedOutSenstivity;
        //fpsController.mouseLook.YSensitivity = zoomedOutSenstivity;
    }
}
