using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class TH_csCreateTreasures3 : MonoBehaviour
{
    // UI 선언
    
    public GameObject IntroPanel;
    public Button btnStart;


    public GameObject placedPrefab; //보물 프리팹 가져오기

    private GameObject[] placedObject; //빈 게임오브젝트 배열 선언
    private bool isPlacedObj = false; //보물이 놓였는지 여부 확인

    private ARPlaneManager arPlaneManager; //ARPlaneManager 가져오기
    private ARSessionOrigin arSessionOrigin;
    public Camera ARCamera;


    private void Awake()
    {

       // btnStart.onClick.AddListener(FindObj); // 버튼 터치하면 FindObj 함수 실행하기

        
            placedObject = new GameObject[5]; // 빈 게임오브젝트 배열에 5개 생성하기
        

        arSessionOrigin = GameObject.Find("AR Session Origin").GetComponent<ARSessionOrigin>();
        arPlaneManager = GameObject.Find("AR Session Origin").GetComponent<ARPlaneManager>();
       // arPlaneManager = GetComponent<ARPlaneManager>(); // ARPlaneManager 실행하기
        
    }

    private void Start()
    {
        arPlaneManager.planesChanged += PlaneChanged; // 조건에 맞을 때 PlaneChanged를 호출하는 이벤트
    }

    public void FindObj()
    {
        GameManager.Instance.BGM.BtnClickSound();
        this.gameObject.SetActive(true);
        IntroPanel.SetActive(false);
        btnStart.gameObject.SetActive(false);
    }//FindObj가 호출되면 패널 비활성화 실행하기
/*    public void FindObj()
    {
        Debug.Log("111111111");
        IntroPanel.SetActive(false);
    }*/
    private void PlaneChanged(ARPlanesChangedEventArgs args) // 객체가 같은지 비교하는 구조체를 매개변수로 담은 메서드
    {
        /*  args.added != null => 인식된 Plane이 존재하느냐?  / isPlaceObj == false => 5개가 생성된 적이 없을 때 */
        if (args.updated != null && isPlacedObj == false)
        {
            foreach (var plane in args.updated) // 처음 인식된 Plane
            {
                
                    ARPlane arPlane = plane;
                    // ARPlane arPlane = args.added[0];        // 처음 인식된 Plane
                    string str = String.Format("***************** arPlane.size.x : {0}, arPlane.size.y : {1}", arPlane.size.x, arPlane.size.y);
                    Debug.Log(str);

                    // 적당한 크기(1.0, 1.0 이하)
                    if (arPlane.size.x < 2.0f && arPlane.size.x > 0.0f || arPlane.size.y < 2.0f && arPlane.size.y > 0.0f)
                    {
                        // 5개를 생성해라
                        for (int i = 0; i < 5; i++)
                        {
                            Vector3 pos = arPlane.center;  // 바닥의 중심 위치에 보물 생성하라
                            pos.x += UnityEngine.Random.Range(-2.0f, 2.0f); /*중심위치에서 좌우 양옆 1m내에*/
                            pos.y = arPlane.transform.position.y;
                            pos.z += UnityEngine.Random.Range(-2.0f, 2.0f); /*중심위치에서 전or후 1m내에*/
                            placedObject[i] = Instantiate(placedPrefab, pos, Quaternion.identity);
                        }
                        Debug.Log("***************** 오브젝트 생성됨");
                        isPlacedObj = true;
                        StartCoroutine(coTimedelay(arPlane));
                        break;
                    }
                
            }
        }
    }


    IEnumerator coTimedelay(object arObj)
    {
        ARPlane arPlane = (ARPlane)arObj;
        yield return new WaitForSeconds(3.0f);
        arPlaneManager.detectionMode = PlaneDetectionMode.None;
        arPlane.gameObject.SetActive(false);
        ARCamera.GetComponent<ARPlaneManager>().enabled = false;
        ARCamera.GetComponent<ARPointCloudManager>().enabled = false;
        Debug.Log("***************** 바닥 인식 Plane 비활성화");
    }

    
}
