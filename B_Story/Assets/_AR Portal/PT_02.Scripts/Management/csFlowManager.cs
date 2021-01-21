using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class csFlowManager : MonoBehaviour
{
    int pCnt = 0;
    int tCnt = 0;
    int qCnt = 0;
    public GameObject PortalManager;
    public GameObject PortalStart;
    public GameObject TreasureStart;
    public GameObject QuizStart;
    //public GameObject QuizManager;

    void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.name)
        {
            case "Point (0)":
                pCnt += 1;
                if (pCnt == 1)
                {
                    QuizStart.SetActive(true);
                    //QuizManager.SetActive(true);
                    //PortalStart.SetActive(true);
                }

                break;
            case "Point (1)":
                tCnt += 1;
                if (tCnt == 1)
                {
                    TreasureStart.SetActive(true);
                }

                break;
            case "Point (2)":
                qCnt += 1;
                if (qCnt == 1)
                {
                    /*  QuizStart.SetActive(true);
                      QuizManager.SetActive(true);*/
                    PortalStart.SetActive(true);
                }


                break;

        }

    }
}
