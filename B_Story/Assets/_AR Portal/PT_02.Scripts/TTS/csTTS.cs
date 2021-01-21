
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csTTS : MonoBehaviour
{
    public AudioClip STclip;    // 시작
    public AudioClip[] Mclip;   // 멈췄을 때
    //public AudioClip[] Sclip;   // 움직일 때    

    int cnt = 0;
        
    void Start()
    {
        Debug.Log("1");
        //csTTSMgr.getInstance().PlayTTS(STclip);
        Debug.Log("2");
    }

    void StopMove()
    {
        csTTSMgr.getInstance().PlayTTS(Mclip[cnt]);
    }
        
    void Moving()
    {
        //csTTSMgr.getInstance().PlayTTS(Sclip[cnt]);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("WAY_POINT"))
        {
            StopMove();
            cnt++;
        }
    }
}