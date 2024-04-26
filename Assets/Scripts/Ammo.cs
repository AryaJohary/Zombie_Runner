using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;
    [System.Serializable]
    private class AmmoSlot{
        public AmmoType ammoType;
        public int ammoCount;
    }
    public int GetCurrentAmmo(AmmoType ammoType){
        return GetAmmoSlot(ammoType).ammoCount;
    }
    public void ReduceCurrentAmmo(AmmoType ammoType){
        GetAmmoSlot(ammoType).ammoCount--;
    }
    public void IncreaseAmmo(AmmoType PickupAmmoType, int PickupAmmoCount){
        GetAmmoSlot(PickupAmmoType).ammoCount += PickupAmmoCount;
        //Debug.Log("increase ammo worked");
    }
    private AmmoSlot GetAmmoSlot(AmmoType ammoType){
        foreach(AmmoSlot slot in ammoSlots){
            if(slot.ammoType == ammoType){
                return slot;
            }
        }
        return null;
    }
}
