using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;

public class PZ_Succese : MonoBehaviour
{
    public int cnt = 0;
    bool i = true;
    public GameObject par;
    void Start()
    {
        
    }

    void Update()
    {
        if(!i || cnt < 6) {
            return;
        }
        else {
            par.SetActive(true);
        }
    }
}
