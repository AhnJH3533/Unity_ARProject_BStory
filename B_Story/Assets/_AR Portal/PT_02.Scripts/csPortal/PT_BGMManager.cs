using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_BGMManager : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.BGM.PortalBGM();
    }
}
