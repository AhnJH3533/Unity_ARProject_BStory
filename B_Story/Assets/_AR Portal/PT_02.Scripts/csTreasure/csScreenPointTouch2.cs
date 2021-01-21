using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csScreenPointTouch2 : MonoBehaviour
{
    public Camera arCamera;
    int cnt = 5;
    bool check = false;
    public GameObject treasureText;
    public GameObject treasureManager;
    private void Start()
    {
        arCamera = GameObject.Find("AR Camera").GetComponent<Camera>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 0) return;

            Touch touch = Input.GetTouch(0);
     
            RaycastHit hit;
            Ray ray = arCamera.ScreenPointToRay(Input.mousePosition);


            //마우스 왼클릭 했을 때
            //if (Input.GetButtonUp("Fire1"))

            //마우스 왼클릭한 지점으로 레이 정보를 만든다
            /*     Ray ray = arCamera.ScreenPointToRay(Input.mousePosition);
                 RaycastHit hit;*/

            //레이캐스팅을 이용해 충돌체를 찾는다
            if (Physics.Raycast(ray, out hit))

            { //충돌체의 태그 정보가 Treasure인지 확인한다
                if (hit.transform.tag.Equals("Treasure"))
                {
                    cnt -= 1;
                    Debug.Log("***************** 오브젝트 삭제됨");
                    //Destroy(hit.collider.gameObject);
                    DestroyImmediate(hit.collider.gameObject);

                    //퍼블릭선언된 외부게임오브젝트의 스크립트 컴포넌트에 대한 변수를 선언하고, 값을 연결한다
                    //AutoPlacementOfObjects autoPlacementOfObjects = hit.transform.GetComponent<AutoPlacementOfObjects>();

                    //if (autoPlacementOfObjects != null)
                    //{
                    //    autoPlacementOfObjects.Destroy(); //연결한 외부 스크립트의 퍼블릭 메서드를 호출한다
                    //}
                }
            }
        if (cnt == 0)
        {
            treasureText.SetActive(true);
        }
    
    }



    public void nextstage()
    {
        treasureText.SetActive(false);
        treasureManager.SetActive(false);
        csMoveToWays.WaitMove = true;
    }
        

}


