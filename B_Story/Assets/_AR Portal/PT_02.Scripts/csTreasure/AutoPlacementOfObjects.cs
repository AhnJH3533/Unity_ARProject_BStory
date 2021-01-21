using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;



#pragma warning disable 67, CS0649 //쉼표로 연결 가능

//[RequireComponent(typeof(ARPlaneManager))]

public class AutoPlacementOfObjects : MonoBehaviour
{
    public Text txtIsPlaced;
    public GameObject welcomePanel;
    public Button findingButton;

    public GameObject placedPrefab;

    private GameObject[] placedObject;
    private bool isPlacedObj = false;

    private ARPlaneManager arPlaneManager;
    private ARSessionOrigin arSessionOrigin;
    //private Camera arCamera;
    


    private void Awake()
    {
        //findingButton.onClick.AddListener(FindObj);
        placedObject = new GameObject[5];
        


        arSessionOrigin = GameObject.Find("AR Session Origin").GetComponent<ARSessionOrigin>();
        arPlaneManager =GameObject.Find("AR Session Origin").GetComponent<ARPlaneManager>();
        //arCamera = GameObject.Find("AR Camera").GetComponent<Camera>();
        
    }

    //private void FindObj() => welcomePanel.SetActive(false);
    void Start()
    {
        arPlaneManager.planesChanged += PlaneChanged;
    }
    private void PlaneChanged(ARPlanesChangedEventArgs args)
    {
        if(args.updated !=null && isPlacedObj==false)
        //if (args.added != null && placedObject==null)
        {
            foreach (var plane in args.updated)
            {
                ARPlane arPlane = plane;

                txtIsPlaced.text = arPlane.size.ToString();
                string str = String.Format("***************** arPlane.size.x : {0}, arPlane.size.y : {1}", arPlane.size.x, arPlane.size.y);
                Debug.Log(str);

               
                    for (int i = 0; i < 5; i++)
                    {
                        
                        Vector3 pos = arPlane.center;
                        pos.x += UnityEngine.Random.Range(-1.5f, 1.5f);
                        //pos.y += UnityEngine.Random.Range(-0.03f, 0.03f);
                        pos.y = arPlane.transform.position.y;
                        pos.z += UnityEngine.Random.Range(-1.5f, 1.5f);
                        placedObject[i] = Instantiate(placedPrefab, pos, Quaternion.identity);
                    }
                    Debug.Log("***************** 오브젝트 생성됨");
                    isPlacedObj = true;
                    //StartCoroutine(coTimedelay(arPlane));
                    break;
                
            }
      
                     
        }
    }

/*       IEnumerator coTimedelay(object arObj)
       {
           ARPlane arPlane = (ARPlane)arObj;
           yield return new WaitForSeconds(3.0f);
           arPlaneManager.detectionMode = PlaneDetectionMode.None;
           arPlane.gameObject.SetActive(false);
           Debug.Log("***************** 바닥 인식 Plane 비활성화");
       }

*/
/*    void Update()
    {
        

    }*/
    /*    public void Destroy()
        {
            Destroy(transform.gameObject);
        }*/
}
