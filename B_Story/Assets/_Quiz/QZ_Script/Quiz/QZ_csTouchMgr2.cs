using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class QZ_csTouchMgr2 : MonoBehaviour {
    AudioSource audioSource;
    public AudioClip[] OXSound;

    public GameObject placeObject;
    public GameObject oPlate;
    public GameObject xPlate;
    public ARRaycastManager raycastMgr;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private Camera arcamera;
    public GameObject OX;
    private GameObject gobj = null;
    bool isTouch = false;

    public Text firstQText;
    public Text secondQText;
    public Text thirdQText;
    public GameObject FirstAnswer;
    public GameObject SecondAnswer;
    public GameObject ThirdAnswer;
    public GameObject Question1;
    public GameObject Question2;
    public GameObject Question3;

    public Text QuizIntro;
    public GameObject pn;
    public Button firstQ;

    public Material ChangeColorO;
    public Material ChangeColorX;

    Color colorO;
    Color colorX;
    bool isPlacedObj = true;
    public ARPlaneManager arPlaneManager; //ARPlaneManager ��������
    public ARSessionOrigin arSessionOrigin;
    IEnumerator coTimedelay(object arObj) {
        ARPlane arPlane = (ARPlane)arObj;
        yield return new WaitForSeconds(3.0f);
        arPlaneManager.detectionMode = PlaneDetectionMode.None;
        arPlane.gameObject.SetActive(false);
        arSessionOrigin.GetComponent<ARPlaneManager>().enabled = false;
        arSessionOrigin.GetComponent<ARPointCloudManager>().enabled = false;
        Debug.Log("***************** �ٴ� �ν� Plane ��Ȱ��ȭ");
    }
    void Start() {
        audioSource = this.GetComponent<AudioSource>();
        colorO = new Vector4(0f, 0f, 1f, 1f);
        colorX = new Vector4(1f, 0f, 0f, 1f);
        arcamera = GameObject.Find("AR Camera").GetComponent<Camera>();
        //arPlaneManager = GameObject.Find("AR Session Origin").GetComponent<ARPlaneManager>();
        arPlaneManager.planesChanged += PlaneChanged;

        //�׽�Ʈ��
        //Instantiate(placeObject, Vector3.zero, Quaternion.identity);
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
        if (isTouch) {
            if (arcamera.transform.position.z <= gobj.transform.position.z + 0.6f &&
                arcamera.transform.position.z >= gobj.transform.position.z - 0.6f &&
                arcamera.transform.position.x < gobj.transform.position.x) {
                ChangeColorO.color = new Vector4(0f, 0f, 1f, 0.5f);
                ChangeColorX.color = colorX;
            }

            else if (arcamera.transform.position.z <= gobj.transform.position.z + 0.6f &&
                     arcamera.transform.position.z >= gobj.transform.position.z - 0.6f &&
                     arcamera.transform.position.x > gobj.transform.position.x) {
                ChangeColorX.color = new Vector4(1f, 0f, 0f, 0.5f);
                ChangeColorO.color = colorO;
            }

            else {
                ChangeColorO.color = colorO;
                ChangeColorX.color = colorX;
            }
        }
        // ��ġ �ѹ� �Ҷ�����
        if (!TryGetTouchPosition(out Vector2 touchPos)) // ��ġ���ϸ�
            return;

        if (raycastMgr.Raycast(touchPos, hits, TrackableType.PlaneWithinPolygon)) {

            if (gobj == null) {
                isTouch = true;
                // OX������ ����
                gobj = Instantiate(placeObject, hits[0].pose.position, hits[0].pose.rotation);
                var rot = Quaternion.LookRotation(arcamera.transform.position - hits[0].pose.position);
                placeObject.transform.rotation = Quaternion.Euler(arcamera.transform.position.x, rot.eulerAngles.y, arcamera.transform.position.z);

                QuizIntro.gameObject.SetActive(false);
                pn.SetActive(false);
                firstQ.gameObject.SetActive(true);
                isPlacedObj = false;
            }

        }
    }
    private void PlaneChanged(ARPlanesChangedEventArgs args) // ��ü�� ������ ���ϴ� ����ü�� �Ű������� ���� �޼���
    {
        /*  args.added != null => �νĵ� Plane�� �����ϴ���?  / isPlaceObj == false => 5���� ������ ���� ���� �� */
        if (args.updated != null && !isPlacedObj) {
            foreach (var plane in args.updated) // ó�� �νĵ� Plane
            {
                ARPlane arPlane = plane;
                StartCoroutine(coTimedelay(arPlane));
            }
        }
    }


    public void Answer(int num) {
        if (arcamera.transform.position.z <= gobj.transform.position.z + 0.6f &&
              arcamera.transform.position.z >= gobj.transform.position.z - 0.6f &&
              arcamera.transform.position.x < gobj.transform.position.x) {
            if (num == 2) audioSource.clip = OXSound[0];
            else audioSource.clip = OXSound[1];
            switch (num) {
                case 1:
                    Question1.SetActive(false);
                    FirstAnswer.SetActive(true);
                    audioSource.Play();
                    firstQText.text = "�����Դϴ�!.";
                    break;
                case 2:
                    Question2.SetActive(false);
                    SecondAnswer.SetActive(true);
                    audioSource.Play();
                    secondQText.text = "�� Ʋ�Ƚ��ϴ�.";
                    break;
                case 3:
                    Question3.SetActive(false);
                    ThirdAnswer.SetActive(true);
                    audioSource.Play();
                    thirdQText.text = "�����Դϴ�!.";
                    break;

            }
        }

        else if (arcamera.transform.position.z <= gobj.transform.position.z + 0.6f &&
                 arcamera.transform.position.z >= gobj.transform.position.z - 0.6f &&
                 arcamera.transform.position.x > gobj.transform.position.x) {
            if (num == 2) audioSource.clip = OXSound[1];
            else audioSource.clip = OXSound[0];

            switch (num) {
                case 1:
                    Question1.SetActive(false);
                    FirstAnswer.SetActive(true);
                    audioSource.Play();
                    firstQText.text = "�� Ʋ�Ƚ��ϴ�.";
                    break;
                case 2:
                    Question2.SetActive(false);
                    SecondAnswer.SetActive(true);
                    audioSource.Play();
                    secondQText.text = "�����Դϴ�!.";
                    break;
                case 3:
                    Question3.SetActive(false);
                    ThirdAnswer.SetActive(true);
                    audioSource.Play();
                    thirdQText.text = "�� Ʋ�Ƚ��ϴ�.";
                    break;

            }

        }
    }


}
