using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QZ_csButtonManager : MonoBehaviour
{
    public GameObject QuizManager;
    public GameObject QuizStart;
    public GameObject OX;
    
    public void qCheck()
    {
        GameManager.Instance.BGM.BtnClickSound();
        QuizStart.SetActive(false);
        QuizManager.SetActive(true);
        OX.SetActive(true);
    }

}
