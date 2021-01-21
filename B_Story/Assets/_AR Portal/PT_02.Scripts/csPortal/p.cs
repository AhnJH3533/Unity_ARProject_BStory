using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class p : MonoBehaviour {
    private GameObject spawnedPrefab = null;
    public GameObject Portal;
    public ARRaycastManager arRaycastmanager;
    private Vector2 touchPosition;
    private GameObject Anchor;
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private Camera arcamera;
    int cnt = 0;
    void Start() {
        arcamera = GameObject.Find("AR Camera").GetComponent<Camera>();
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
            }

        }
    }
}

