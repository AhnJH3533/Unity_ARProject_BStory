using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class GB_CreateGuideBotAndWay2 : MonoBehaviour {
    public GameObject gameManager;
    public GameObject GuideObj;
    public Camera arcamera;
    public GameObject wayGroup;
    public GameObject waypoint;

    private GameObject spawnedObj;
    private ARRaycastManager aRRaycastManager;
    private Vector2 touchPos;
    private bool isTouched;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private bool canTouch = true;

    public GameObject ment;

    // 바닥 지우기
    bool isPlacedObj = true;
    public ARPlaneManager arPlaneManager; //ARPlaneManager 가져오기
    public ARSessionOrigin arSessionOrigin;

    private void Awake() {
        aRRaycastManager = GetComponent<ARRaycastManager>();
        isTouched = false;
    }
    private void Start() {
        gameManager = GameObject.Find("GameManager");
        arPlaneManager.planesChanged += PlaneChanged;

        //테스트용 바로 생성
        //GameObject.Instantiate(GuideObj, Vector3.zero, Quaternion.identity).transform.parent = gameManager.transform;
    }

    bool TryGetTouchPosition(out Vector2 touchPos) {
        if (Input.touchCount > 0) {
            touchPos = Input.GetTouch(0).position;
            return true;
        }
        touchPos = default;
        return false;
    }

    // 바닥인식 지우기
    private void PlaneChanged(ARPlanesChangedEventArgs args) {// 객체가 같은지 비교하는 구조체를 매개변수로 담은 메서드
        /*  args.added != null => 인식된 Plane이 존재하느냐?  / isPlaceObj == false => 5개가 생성된 적이 없을 때 */
        if (args.updated != null && !isPlacedObj) {
            foreach (var plane in args.updated) // 처음 인식된 Plane
            {
                ARPlane arPlane = plane;
                StartCoroutine(coTimedelay(arPlane));
            }
        }
    }
    IEnumerator coTimedelay(object arObj) {
        ARPlane arPlane = (ARPlane)arObj;
        yield return new WaitForSeconds(3.0f);
        arPlaneManager.detectionMode = PlaneDetectionMode.None;
        arPlane.gameObject.SetActive(false);
        arSessionOrigin.GetComponent<ARPlaneManager>().enabled = false;
        arSessionOrigin.GetComponent<ARPointCloudManager>().enabled = false;
        Debug.Log("***************** 바닥 인식 Plane 비활성화");
    }

    void Update() {
        if (!canTouch) return;
        else {
            if (!isTouched && GameManager.Instance.isFirstGB) { // 터치 한번 할때까지
                if (!TryGetTouchPosition(out Vector2 touchPos)) // 터치안하면
                    return;
                if (aRRaycastManager.Raycast(touchPos, hits, TrackableType.PlaneWithinPolygon)) {
                    var hitPose = hits[0].pose;
                    //hitPose.position.y += GuideObj.transform.localScale.y;
                    //spawnedObj = Instantiate(GuideObj, hitPose.position, hitPose.rotation);
                    GameObject.Instantiate(GuideObj, hitPose.position, hitPose.rotation).transform.parent = gameManager.transform;
                    isPlacedObj = false;
                    GameManager.Instance.isFirstGB = false;
                    ment.SetActive(false);
                }
            } // end Touch
            canTouch = false;

        }
    }
}