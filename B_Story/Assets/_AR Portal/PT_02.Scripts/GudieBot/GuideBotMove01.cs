using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class GuideBotMove01 : MonoBehaviour {
    public GameObject GuideObj;

    private GameObject spawnedObj;
    private ARRaycastManager aRRaycastManager;
    private Vector2 touchPos;
    private bool isTouched;

    public Material mBlue;
    public Material mRed;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    public Camera arcamera;

    private void Awake() {
        aRRaycastManager = GetComponent<ARRaycastManager>();
        isTouched = false;
    }

    bool TryGetTouchPosition(out Vector2 touchPos) {
        if (Input.touchCount > 0) {
            touchPos = Input.GetTouch(0).position;
            return true;
        }
        touchPos = default;
        return false;
    }

    void Update() {

        if (!isTouched) { // 터치 한번 할때까지
            if (!TryGetTouchPosition(out Vector2 touchPos)) // 터치안하면
                return;
            if (aRRaycastManager.Raycast(touchPos, hits, TrackableType.PlaneWithinPolygon)) {
                var hitPose = hits[0].pose;
                hitPose.position.y += GuideObj.transform.localScale.y;
                if (spawnedObj == null) {
                    spawnedObj = Instantiate(GuideObj, hitPose.position, hitPose.rotation);
                }
/*                else
                {
                    spawnedObj.transform.position = hitPose.position;
                }*/
                spawnedObj.GetComponent<MeshRenderer>().material = mBlue;

                Debug.Log("만들었습니당 헤헤");
            }
            else {
                if (spawnedObj != null) {
                    spawnedObj.GetComponent<MeshRenderer>().material = mRed;
                }
            }
        } // end Touch
    }
}
