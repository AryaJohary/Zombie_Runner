using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int ammoAmount = 5;
    [SerializeField] AmmoType ammoType;
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag=="Player"){
            Debug.Log(ammoType+" Picked Up");
            Destroy(gameObject);
            FindObjectOfType<Ammo>().IncreaseAmmo(ammoType, ammoAmount);
        }
    }
}
