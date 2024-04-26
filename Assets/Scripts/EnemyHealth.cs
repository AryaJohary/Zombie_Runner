using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float HitPoints = 100f;
    bool isDead = false;
    public EnemyCount EnemyCountScript;
    public void EnemyTakeDamage(float damage){
        BroadcastMessage("EnemyTookDamage",damage);
        HitPoints -= damage;
        if(HitPoints <= damage && (isDead==false)){
            isDead = true;
            Die();
        } 
    }
    public void Die(){
        GetComponent<Animator>().SetTrigger("Die");
        if(EnemyCountScript.zombiecount>0){
            EnemyCountScript.zombiecount--;
        }
        GetComponent<EnemyAI>().enabled = false;
    }
}
