using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class csTimer : MonoBehaviour
{
    Image fillImg;
    float time;
    float timeamount = 10;
    void Start()
    {
        fillImg = this.GetComponent<Image>();
        time = timeamount;
    }

    // Update is called once per frame
    void Update()
    {
        if(time>0)
        {
            time -= Time.deltaTime;
            fillImg.fillAmount = time / timeamount;
        }
        if (time <= 0) time = 10;
           
    }
}
