using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TH_csSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip getSound;
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        audioSource.clip = getSound;
    }

    public void SoundStart()
    {
        audioSource.Play();
    }
}
