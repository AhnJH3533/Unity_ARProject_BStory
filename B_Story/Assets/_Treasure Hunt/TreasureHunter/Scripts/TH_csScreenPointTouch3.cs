using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TH_csScreenPointTouch3 : MonoBehaviour
{
    private Camera arCamera;
    private GameObject DestroyBox;
    //public GameObject treasureCnt;
    public Text txtCnt;
    int cnt = 5;
    public GameObject ParDestroy;
    public GameObject soundObj;
    public RawImage paper;
    public Button btnNext;
    //private GameObject g ;
    bool check = false;

    // 게임 끝나고 파티클 효과
    public GameObject particle;
    private void Start()
    {
        arCamera = GameObject.Find("AR Camera").GetComponent<Camera>();
        txtCnt.color = new Color(255, 255, 255, 255);
        txtCnt.alignment = TextAnchor.UpperCenter;
        txtCnt.text = cnt + " / 5개\r\n " +
                               "주위를 둘러보며 보물을 터치해보세요.";
    }

    IEnumerator destroyDelay(GameObject gameObject) {
        check = true;
        Instantiate(soundObj, ParDestroy.transform.position, Quaternion.identity);
        DestroyBox = Instantiate(ParDestroy);
        cnt--;
        if(cnt == 0) {
            StartCoroutine(coParticle(ParDestroy));
        }
        Destroy(gameObject);
        check = false;
        yield return new WaitForFixedUpdate();
    }
    IEnumerator coParticle(GameObject g) {
        yield return new WaitForSeconds(1f);
        Instantiate(particle, g.transform.position, Quaternion.identity);
    }
    void Update()
    {
        if (cnt != 0) {
            //txtCnt = gameObject.GetComponent<Text>();

            //txtCnt.font = new Font("HMFMPYUN");
            // txtCnt.fontSize=new font

            txtCnt.text = cnt + " / 5개\r\n " +
                                "주위를 둘러보며 보물을 터치해보세요.";
        }

        if (cnt == 0) {
            txtCnt.color = new Color(0, 0, 0, 255);
            txtCnt.alignment = TextAnchor.LowerCenter;
            paper.gameObject.SetActive(true);
            txtCnt.text = "모든 보물을 찾았습니다.\r\n\r\n" +
                          "1696년 1월 일본내 논의 결과, \r\n" +
                          "“지리적으로 조선과 더 가깝기 때문에 \r\n" +
                          "조선의 지계임을 의심할 여지가 없다”. \r\n" +
                          "즉, 안용복 사건을 계기로\r\n" +
                          "한일간의 독도 영유권 문제는\r\n" +
                          "이미 결론이 난 문제랍니다.";
            btnNext.gameObject.SetActive(true);
        }

        Touch touch = Input.GetTouch(0);

        if (Input.touchCount == 0) return;


        //마우스 왼클릭한 지점으로 레이 정보를 만든다
        Ray ray = arCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;


        //레이캐스팅을 이용해 충돌체를 찾는다
        if (Physics.Raycast(ray, out hit))
        {
            //충돌체의 태그 정보가 Treasure인지 확인한다
            if (hit.transform.tag.Equals("Treasure"))
            {

                ParDestroy.transform.position = hit.collider.gameObject.transform.position;
                //DestroyBox = Instantiate(ParDestroy);

                //g = hit.collider.gameObject;
                //g.GetComponent<TH_csSound>().SoundStart();
                if (!check) {
                    StartCoroutine(destroyDelay(hit.collider.gameObject));
                }
                //Destroy(hit.collider.gameObject);
            }
        }
    }

}
