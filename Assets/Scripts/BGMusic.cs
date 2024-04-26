using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusic : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioSource BackGroundMusic;
    void Start()
    {
        BackGroundMusic.Play();
    }
}
