using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PZ_csPicese : MonoBehaviour {
    private Vector3 RightPosition;
    public bool isRightPosition;
    public bool Selected;
    public GameObject WinObject;
    public int cnt = 0;
    private AudioSource audioSource;
    public AudioClip FitSound;

    int soundplay = 0;
    void Start() {
        audioSource = this.GetComponent<AudioSource>();

        RightPosition = this.transform.position;
        this.transform.position = new Vector3(Random.Range(0.5f, 1f), Random.Range(-0.5f, 0.5f), this.transform.position.z);
    }

    void Update() {
        if (Vector3.Distance(transform.position, RightPosition) < 0.4f) {
            if (!Selected) {
                transform.position = RightPosition;
                isRightPosition = true;
                cnt = 1;
                soundplay += 1;
            }
        }
        if (soundplay == 1) {
            audioSource.clip = FitSound;
            audioSource.Play();
            this.transform.parent.GetComponent<PZ_Succese>().cnt += 1;
        }

    }

}
