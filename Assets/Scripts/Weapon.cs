using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float Range = 100f;
    [SerializeField] float WeaponDamage = 20f;
    [SerializeField] ParticleSystem muzzleflash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] TextMeshProUGUI AmmoCountText;
    
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] AudioSource ShootSound;

    bool canShoot = true;
    
    [SerializeField] float timeBetweenShots = 0.5f;
    private void OnEnable() {
        canShoot = true;
    }
    void Update()
    {
        DisplayAmmo();
        if(Input.GetMouseButtonDown(0) && (canShoot==true)){
            StartCoroutine(Shoot());
        }
    }

    private void DisplayAmmo()
    {
        AmmoCountText.text = ammoSlot.GetCurrentAmmo(ammoType).ToString();
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if(ammoSlot.GetCurrentAmmo(ammoType) > 0){
            ammoSlot.ReduceCurrentAmmo(ammoType);
            PlayMuzzleFlash();
            ShootSound.Play();
            ProcessRaycast();
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }
    private void PlayMuzzleFlash()
    {
        muzzleflash.Play();
    }
    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, Range))
        {
            //Debug.Log("Weapon script => I hit " + hit.transform.name);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            CreateHitImpact(hit);
            if (target == null)
            {
                return;
            }
            target.EnemyTakeDamage(WeaponDamage);
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact =  Instantiate(hitEffect,hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact,0.1f);
    }
}
