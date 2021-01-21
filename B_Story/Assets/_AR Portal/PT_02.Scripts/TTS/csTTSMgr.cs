using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csTTSMgr : MonoBehaviour
{
    static csTTSMgr _instance = null;
    public static csTTSMgr getInstance()
    {
        return _instance;
    }

    void Start()
    {
        if(_instance == null)
        {
            _instance = this;
        }
    }

    public void PlayTTS(AudioClip clip)
    {
        GetComponent<AudioSource>().PlayOneShot(clip);
    }
}
