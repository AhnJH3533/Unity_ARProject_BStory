using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csGameManager : MonoBehaviour
{
    public GameObject[] gObj = new GameObject[6];
    public GameObject WinText;
    int[] check = new int[6];
    //bool win = 0;
    // Start is called before the first frame update
    void Start()
    {

            
    }

    // Update is called once per frame
    void Update()
    {
        for(int i= 0;i<gObj.Length;i++)
        {
            check[i]=  gObj[i].GetComponent<PZ_csPicese>().cnt;
        }
        
        if(check[0]+check[1]+check[2]+check[3]+check[4]+check[5]==6)
        {
            WinText.SetActive(true);
        }
    }
}
