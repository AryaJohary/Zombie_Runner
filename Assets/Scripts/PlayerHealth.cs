using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Slider PlayerHealthBarSlider;
    [SerializeField] float PlayerHitpoints = 100f;
    //public AudioSource backgroundMusic;
    private void Start() {
        PlayerHealthBarSlider.value = 1;
        //backgroundMusic.Play();
    }
    public void PlayerTakeDamage(float damage){
        if(PlayerHitpoints<=0f){
            PlayerHealthBarSlider.value = 0f;
            GetComponent<DeathHandler>().HandleDeath();
        }
        PlayerHitpoints -= damage;
        if(PlayerHitpoints>0f){
            //Debug.Log("remaining health = "+PlayerHitpoints);
            PlayerHealthBarSlider.value = Mathf.Clamp01(PlayerHitpoints / 100 / 0.9f);
        }
    }

}
