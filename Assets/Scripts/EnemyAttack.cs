using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] Canvas BloodScatter;
    [SerializeField] float bloodImpactDuration = 0.3f;
    [SerializeField] float damage = 40f;
    public AudioSource ZombieAttackMusic;
    void Start()
    {
        BloodScatter.enabled = false;
        target = FindObjectOfType<PlayerHealth>();   
    }

    public void AttackHitEvent(){
        if(target == null){
            return;
        }
        ZombieAttackMusic.Play();
        ShowDamageImpact();
        target.GetComponent<PlayerHealth>().PlayerTakeDamage(damage);
    }
    private void ShowDamageImpact()
    {
        StartCoroutine(ShowBlood());
    }
    IEnumerator ShowBlood(){
        BloodScatter.enabled = true;
        yield return new WaitForSeconds(bloodImpactDuration);
        BloodScatter.enabled = false;
    }
}
