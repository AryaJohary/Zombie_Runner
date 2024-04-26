using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCount : MonoBehaviour
{
    WinHandler handlingwin;
    public int zombiecount = 4;
    private void Start() {
        handlingwin = GetComponent<WinHandler>();
    }
    void Update()
    {
        //Debug.Log("current zombie count = "+ zombiecount);
        if(zombiecount<=0){
            handlingwin.didWin = true;
        } 
    }
}
