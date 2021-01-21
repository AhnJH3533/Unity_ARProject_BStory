using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class PT_csPortalController : MonoBehaviour {

    private GameObject spawnedPrefab = null;
    public GameObject Portal;
    public ARRaycastManager arRaycastmanager;
    private Vector2 touchPosition;
    private GameObject Anchor;
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private Camera arcamera;

    public Button PortalNextStage;
    public GameObject Canvas;

    // 바닥 지우기
    bool isPlacedObj = true;
    public ARPlaneManager arPlaneManager; //ARPlaneManager 가져오기
    public ARSessionOrigin arSessionOrigin;

    int cnt = 0;
    void Start() {
        arcamera = GameObject.Find("AR Camera").GetComponent<Camera>();
        arPlaneManager.planesChanged += PlaneChanged;
    }
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
    bool TryGetTouchPosition(out Vector2 touchPosition) {
        if (Input.touchCount > 0) {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        touchPosition = default;
        return false;
    }

    void Update() {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
            return;
        if (arRaycastmanager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon)) {

            if (spawnedPrefab == null) {
                var hitPose = hits[0].pose;
                spawnedPrefab = Instantiate(Portal, hitPose.position, hitPose.rotation);
                var rot = Quaternion.LookRotation(arcamera.transform.position - hitPose.position);
                spawnedPrefab.transform.rotation = Quaternion.Euler(arcamera.transform.position.x, rot.eulerAngles.y, arcamera.transform.position.z);
                PortalNextStage.gameObject.SetActive(true);
                Canvas.SetActive(false);
                isPlacedObj = false;
            }

        }
    }
}
