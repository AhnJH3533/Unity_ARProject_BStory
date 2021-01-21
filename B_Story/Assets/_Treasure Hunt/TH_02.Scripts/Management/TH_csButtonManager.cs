using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TH_csButtonManager : MonoBehaviour
{
    public GameObject TreasureManager;
    public GameObject TreasureStart;
    


    public void THNextStage()
    {
        GameManager.Instance.BGM.BtnClickSound();
        TreasureManager.SetActive(false);
        TreasureStart.SetActive(false);
    }

}
