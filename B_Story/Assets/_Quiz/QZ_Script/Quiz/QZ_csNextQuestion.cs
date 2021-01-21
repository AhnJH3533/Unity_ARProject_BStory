using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QZ_csNextQuestion : MonoBehaviour
{
    public GameObject Timer;
    float cnt = 10;
    public Canvas canvasQ1;
    public Canvas canvasQ2;
    public Canvas canvasQ3;

    public GameObject Qmanager;
    public GameObject OX;
    public Text cntText;
    public Button NextQ1;
    public Button NextQ2;
    public Button NextQ3;

    GameObject ox;
    public void ShowQ1()
    {
        OX.SetActive(false);
        canvasQ1.gameObject.SetActive(true);
        Timer.SetActive(true);
        StartCoroutine(Count(1,true));
        
    }

    public void ShowQ2()
    {
        canvasQ1.gameObject.SetActive(false);
        canvasQ2.gameObject.SetActive(true);
        Timer.SetActive(true);
        StartCoroutine(Count(2,true));
    }

    public void ShowQ3()
    {
        canvasQ1.gameObject.SetActive(false);
        canvasQ2.gameObject.SetActive(false);
        canvasQ3.gameObject.SetActive(true);
        Timer.SetActive(true);
        StartCoroutine(Count(3,true));
    }
    public void ExitQ()
    {
        canvasQ1.gameObject.SetActive(false);
        canvasQ2.gameObject.SetActive(false);
        canvasQ3.gameObject.SetActive(false);
        Qmanager.SetActive(false);
        ox = GameObject.Find("KKC_OX(Clone)");
        ox.transform.FindChild("Particle_").gameObject.SetActive(true);
        ox.SetActive(true);
    }

    IEnumerator Count(int num,bool start)
    {
        while (start)
        {
            cntText.text = "" + cnt;
            yield return new WaitForSeconds(1f);
            cnt -= 1;
            if (cnt <= 0)
            {
                start = !start;
                Timer.SetActive(false);
                this.GetComponent<QZ_csTouchMgr2>().Answer(num);
                cnt = 10;
                switch (num)
                {
                    case 1:
                        NextQ1.gameObject.SetActive(true);
                        break;
                    case 2:
                        NextQ2.gameObject.SetActive(true);
                        break;
                    case 3:
                        NextQ3.gameObject.SetActive(true);
                        break;
                }
            }
        }
      
    }
   
}

