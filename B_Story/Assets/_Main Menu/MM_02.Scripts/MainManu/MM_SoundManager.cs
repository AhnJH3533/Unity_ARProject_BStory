using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MM_SoundManager : MonoBehaviour {
    public AudioSource audio;
    void Start() {
        GameManager.Instance.BGM.MainMenuBGM();
    }
    public void ButtonSound() {
        audio.Play();
    }
}
