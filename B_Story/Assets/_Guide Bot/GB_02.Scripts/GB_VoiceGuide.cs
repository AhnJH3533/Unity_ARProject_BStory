using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GB_VoiceGuide : MonoBehaviour
{
    public AudioSource Voice;
    public AudioClip _hello, _guide;

    void Start()
    {
        
    }
    public void Hello() {
        Voice.clip = _hello;
        Voice.Play();
    }
    public void VoiceGuide() {
        Voice.clip = _guide;
        Voice.Play();
    }
}
