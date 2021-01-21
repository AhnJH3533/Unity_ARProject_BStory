using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GB_VoiceGuideManager : MonoBehaviour {
    public GameObject KongG;
    public GameObject canvas;
    void Start() {
        KongG = GameObject.Find("KongG(Clone)");
        GameManager.Instance.BGM.VoiceGuideBGM();
    }

    public void VoiceGuideStart() {
        GameManager.Instance.BGM.BtnClickSound();
        canvas.SetActive(false);
        KongG.GetComponent<GB_VoiceGuide>().VoiceGuide();
    }
}
