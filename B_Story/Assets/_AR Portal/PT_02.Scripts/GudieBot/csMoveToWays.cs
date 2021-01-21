using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class csMoveToWays : MonoBehaviour {
    public Camera arcamera;
    public Transform[] points;
    public Text Txt_ObjPos, Txt_ObjLot, Txt_Distance, Txt_WayNum;
    bool canMove = false;
    public float speed = 1f;
    public float damping = 2f;
    public Transform tr;
    public int nextIdx = 1;
    public static bool WaitMove = true;

    void Start() {
        tr = GetComponent<Transform>();
        GameObject wayGroup = GameObject.Find("WayGroup");
        if (wayGroup != null) {
            points =
                wayGroup.GetComponentsInChildren<Transform>();
        }

/*        Txt_ObjPos = GameObject.Find("ObjPos").GetComponent<Text>();
        Txt_ObjLot = GameObject.Find("ObjLot").GetComponent<Text>();
        Txt_Distance = GameObject.Find("Txt_Distance").GetComponent<Text>();
        Txt_WayNum = GameObject.Find("Txt_WayNum").GetComponent<Text>();*/
        arcamera = GameObject.Find("AR Camera").GetComponent<Camera>();

    }

    void Update() {
        //SetPos();
        MoveWayPoint();
    }

/*    void SetPos() {
        Txt_ObjPos.text = $"X : {this.transform.position.x}\n" +
                $"Y : {this.transform.position.y}\n" +
                $"Z : {this.transform.position.z}";
        Txt_ObjLot.text = $"X : {this.transform.rotation.eulerAngles.x}\n" +
            $"Y : {this.transform.rotation.eulerAngles.y}\n" +
            $"Z : {this.transform.rotation.eulerAngles.z}";
        Txt_Distance.text = $"카메라랑 거리 : \n" +
            Vector3.Distance(this.transform.position, arcamera.transform.position);
        Txt_WayNum.text = "WayNum : " + nextIdx;
    }
*/
    void MoveWayPoint() {

        if (Vector3.Distance(arcamera.transform.position, this.transform.position) < 5f && canMove&& WaitMove) {
            Vector3 direction = points[nextIdx].position - tr.position;
            Quaternion rot = Quaternion.LookRotation(direction);
            tr.rotation = Quaternion.Slerp(tr.rotation, rot,
                                           Time.deltaTime * damping);
            tr.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        else {
            canMove = false;
            Vector3 direction = arcamera.transform.position - tr.position;
            Quaternion rot = Quaternion.LookRotation(direction);
            tr.rotation = Quaternion.Slerp(tr.rotation, rot,
                                           Time.deltaTime * damping);
            if (Vector3.Distance(arcamera.transform.position, this.transform.position) < 2f) {
                canMove = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("WAY_POINT"))
        {
            WaitMove = false;
            nextIdx = (++nextIdx >= points.Length) ? 1 : nextIdx;
        }
    }
}
