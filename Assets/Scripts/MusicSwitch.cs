using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitch : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clip;

    private void Start()
    {
       // = gameObject.AddComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {                 
        audioSource.clip = clip;
        audioSource.Play();  
    }
}
