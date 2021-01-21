using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MM_BGMManager : MonoBehaviour {

    public AudioSource audioSource;
    public AudioClip _mainMenuBGM, _walkBGM1, _walkBGM2, _walkBGM3, 
        _voiceGuideBGM, _portalBGM, _treasureBGM, _quizBGM, _puzzleBGM;
    public float vol = 0.8f;

    public AudioSource btnAudio;

    void Start() {

    }
    public void StartBGM() {
        audioSource.Play();
    }
    public void StopBGM() {
        audioSource.Stop();
    }
    public IEnumerator Crescendo() {
        audioSource.Play();
        while (audioSource.volume <= vol) {
            audioSource.volume += 0.01f;
            yield return new WaitForSeconds(0.06f);
        }
        audioSource.volume = vol;
    }
    public IEnumerator DeCrescendo() {
        while(audioSource.volume >= 0.03f) {
            audioSource.volume -= 0.02f;
            yield return new WaitForSeconds(0.05f);
        }
        audioSource.volume = 0.0f;
        audioSource.Stop();
    }
    public void MainMenuBGM() {
        audioSource.clip = _mainMenuBGM;
        StartCoroutine(Crescendo());
    }
    public void WalkBGM1() {
        audioSource.clip = _walkBGM1;
        StartCoroutine(Crescendo());
    }
    public void WalkBGM2() {
        audioSource.clip = _walkBGM2;
        StartCoroutine(Crescendo());
    }
    public void WalkBGM3() {
        audioSource.clip = _walkBGM3;
        StartCoroutine(Crescendo());
    }
    public void VoiceGuideBGM() {
        audioSource.clip = _voiceGuideBGM;
        StartCoroutine(Crescendo());
    }
    public void PortalBGM() {
        audioSource.clip = _portalBGM;
        StartCoroutine(Crescendo());
    }
    public void TreasureBGM() {
        audioSource.clip = _treasureBGM;
        StartCoroutine(Crescendo());
    }
    public void QuizBGM() {
        audioSource.clip = _quizBGM;
        StartCoroutine(Crescendo());
    }
    public void PuzzleBGM() {
        audioSource.clip = _puzzleBGM;
        StartCoroutine(Crescendo());
    }

    public void BtnClickSound() {
        btnAudio.Play();
    }
}
