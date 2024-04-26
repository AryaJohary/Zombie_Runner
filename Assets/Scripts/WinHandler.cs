using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinHandler : MonoBehaviour
{
    [SerializeField] Canvas WinningCanvas;
    [SerializeField] float WinningPauseTime = 1.05f;
    public bool didWin;
    void Start(){
        WinningCanvas.enabled = false;
        didWin = false;
    }
    private void Update() {
        if(didWin==true){
            Invoke("HandleWin", WinningPauseTime);
        }
    }
    void HandleWin(){
        BroadcastMessage("PauseMusic");
        WinningCanvas.enabled = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
