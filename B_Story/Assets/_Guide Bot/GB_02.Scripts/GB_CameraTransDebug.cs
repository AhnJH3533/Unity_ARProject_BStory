using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GB_CameraTransDebug : MonoBehaviour {
    public Camera arcamera;

    public Text Txt_camPos;
    public Text Txt_camLot;

    public GameObject tObj;

    void Start() {
        tObj.SetActive(true);
    }

    void Update() {
        Txt_camPos.text = $"X : {arcamera.transform.position.x}\n" +
            $"Y : {arcamera.transform.position.y}\n" +
            $"Z : {arcamera.transform.position.z}";
        Txt_camLot.text = $"X : {arcamera.transform.rotation.eulerAngles.x}\n" +
            $"Y : {arcamera.transform.rotation.eulerAngles.y}\n" +
            $"Z : {arcamera.transform.rotation.eulerAngles.z}";
    }
}
