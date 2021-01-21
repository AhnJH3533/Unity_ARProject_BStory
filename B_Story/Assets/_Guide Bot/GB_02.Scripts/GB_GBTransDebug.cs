using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GB_GBTransDebug : MonoBehaviour {
    public Text Txt_ObjPos, Txt_ObjLot, Txt_Distance, Txt_WayNum;
    public Camera arcamera;
    int nextIdx;
    void Start() {
        SetAct();
    }

    void Update() {
        SetPos();
    }
    void SetAct() {
        GameObject obj = GameObject.Find("GB_Pos_Canvas");

        obj.transform.Find("Obj Pos Tittle").gameObject.SetActive(true);
        obj.transform.Find("Txt_Distance").gameObject.SetActive(true);
        obj.transform.Find("Txt_WayNum").gameObject.SetActive(true);

        arcamera = GameObject.Find("AR Camera").GetComponent<Camera>();

        Txt_ObjPos = GameObject.Find("ObjPos").GetComponent<Text>();
        Txt_ObjLot = GameObject.Find("ObjLot").GetComponent<Text>();
        Txt_Distance = GameObject.Find("Txt_Distance").GetComponent<Text>();
    }

    void SetPos() {
        Txt_ObjPos.text = $"X : {this.transform.position.x}\n" +
                $"Y : {this.transform.position.y}\n" +
                $"Z : {this.transform.position.z}";
        Txt_ObjLot.text = $"X : {this.transform.rotation.eulerAngles.x}\n" +
            $"Y : {this.transform.rotation.eulerAngles.y}\n" +
            $"Z : {this.transform.rotation.eulerAngles.z}";
        Txt_Distance.text = $"카메라랑 거리 : \n" +
            Vector3.Distance(this.transform.position, arcamera.transform.position);
        nextIdx = this.GetComponent<GB_csMoveToWays>().nextIdx;
        Txt_WayNum.text = "WayNum : " + nextIdx;
    }
}
