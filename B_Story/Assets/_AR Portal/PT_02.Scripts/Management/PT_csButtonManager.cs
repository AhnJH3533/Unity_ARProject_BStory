using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PT_csButtonManager : MonoBehaviour
{
    public GameObject PortalStart;
    public GameObject PortalManager;
    public Button PortalStartButton;
    public Button PortalNextStage;
    public GameObject Canvas;

    public void pCheck()
    {
        GameManager.Instance.BGM.BtnClickSound();
        PortalManager.SetActive(true);
        PortalStartButton.gameObject.SetActive(false);
        Canvas.SetActive(true);
    }
    public void pNextStage()
    {
        GameManager.Instance.BGM.BtnClickSound();
        PortalStart.SetActive(false);
        PortalManager.SetActive(false);
        csMoveToWays.WaitMove = true;
    }

}
