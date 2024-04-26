using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour
{
    float currentX;
    float currentY;
    float currentZ;
    [SerializeField] float CrouchHeight = 0.5f;
    private void Start() {
        currentX = this.transform.localScale.x;
        currentY = this.transform.localScale.y;
        currentZ = this.transform.localScale.z;
    }
    private void Update() {
        if(Input.GetKey(KeyCode.LeftShift)){
            
            this.transform.localScale = new Vector3(currentX, CrouchHeight, currentZ);
        }else{
            this.transform.localScale = new Vector3(currentX, currentY, currentZ);
        }
    }
}
