using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float ChaseRange = 3f;
    [SerializeField] float TurnSpeed = 2f;
    public AudioSource ZombieChaseMusic;
    //[SerializeField] float IgnoreRange = 6f;
    NavMeshAgent navMeshAgent;
    float distancetotarget = Mathf.Infinity;
    bool isProvoked = false;
    bool isChaseMusicPlaying = false;
    Transform target;
    void Start()
    {
        target = FindObjectOfType<PlayerHealth>().transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,ChaseRange);
    }

    void Update()
    {
        distancetotarget = Vector3.Distance(target.position, transform.position);
        if(isProvoked){
            EngageTarget();
        }
        else if(distancetotarget <= ChaseRange ){
            isProvoked = true;          
        }
    }
    void EngageTarget(){
        FaceTarget();
        if(distancetotarget<=navMeshAgent.stoppingDistance){
            AttackTarget();
        }
        else{
            ChaseTarget();
        }
    }
    void AttackTarget(){
        GetComponent<Animator>().SetBool("isAttacking",true);
    }

    public void EnemyTookDamage(){
        isProvoked = true;
    }
    void ChaseTarget(){
        if(isChaseMusicPlaying==false){
            ZombieChaseMusic.Play();
            isChaseMusicPlaying = true;
        }
        navMeshAgent.SetDestination(target.position);   
        GetComponent<Animator>().SetBool("isAttacking",false); 
        GetComponent<Animator>().SetTrigger("isMoving");   
    }
    void FaceTarget(){
        Vector3 direction = (target.position- transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation,lookRotation,Time.deltaTime*TurnSpeed);
    }
    public void PauseMusic(){
        ZombieChaseMusic.volume = 0f;
    }
}
