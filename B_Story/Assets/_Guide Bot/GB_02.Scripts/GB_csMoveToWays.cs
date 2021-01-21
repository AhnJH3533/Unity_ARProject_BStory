using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;

public class GB_csMoveToWays : MonoBehaviour {
    public Camera arcamera;
    public Transform[] points;
    bool canMove = false;
    bool isFirst = true;
    public float speed = 1f;
    public float damping = 3f;
    public Transform tr;
    public int nextIdx = 1;

    private Animator anim;
    public int animNum = 0;

    public AudioSource audio1;
    public AudioSource audio2;

    public GameObject BGMManager;

    public GB_VoiceGuide Voice;

    // 가이드봇 가만히 서있기
    public bool isDontMove = false;

    void Start() {
        tr = GetComponent<Transform>();
        GameObject wayGroup = GameObject.Find("WayGroup");

        BGMManager = GameObject.Find("GB_BGMManager");
        if (wayGroup != null) {
            points =
                wayGroup.GetComponentsInChildren<Transform>();
        }
        arcamera = GameObject.Find("AR Camera").GetComponent<Camera>();

        anim = GetComponent<Animator>();
        StartCoroutine(coStartParticle());
    }

    void Update() {
        arcamera = GameObject.Find("AR Camera").GetComponent<Camera>();
        if (!isFirst && !isDontMove) {
            MoveWayPoint();
        }
        if (nextIdx == 3) {
            isDontMove = true;
            anim.SetInteger("doing", 0);
        }
        if (isDontMove) {
            EndPointLookCam();
        }
        void EndPointLookCam() {
            float thisRotX = tr.rotation.x;
            Vector3 direction = arcamera.transform.position - tr.position;
            Quaternion rot = Quaternion.LookRotation(direction);
            tr.rotation = Quaternion.Slerp(tr.rotation, rot,
                                           Time.deltaTime * damping);
        }
    }

    void MoveWayPoint() {
        if (Vector3.Distance(arcamera.transform.position, this.transform.position) < 5f && canMove && !isFirst) {
            Vector3 direction = points[nextIdx].position - tr.position;
            Quaternion rot = Quaternion.LookRotation(direction);
            tr.rotation = Quaternion.Slerp(tr.rotation, rot,
                                           Time.deltaTime * damping);
            tr.Translate(Vector3.forward * Time.deltaTime * speed);
            animNum = 2;
            anim.SetInteger("doing", 2);
        }
        else {
            canMove = false;
            Vector3 direction = arcamera.transform.position - tr.position;
            Quaternion rot = Quaternion.LookRotation(direction);
            tr.rotation = Quaternion.Slerp(tr.rotation, rot,
                                           Time.deltaTime * damping);
            animNum = 0;
            anim.SetInteger("doing", 0);
            if (Vector3.Distance(arcamera.transform.position, this.transform.position) < 2f) {
                canMove = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (!isDontMove) {
            if (other.CompareTag("WAY_POINT"))
                nextIdx = (++nextIdx >= points.Length) ? 1 : nextIdx;
        }
    }
    IEnumerator coStartParticle() {
        GameObject g = transform.Find("GB_KongGGuide").gameObject;
        g.SetActive(false);
        yield return new WaitForSeconds(1.73f);
        StartCoroutine(coFirstHello());
    }
    IEnumerator coFirstHello() {
        GameObject g = transform.Find("GB_KongGGuide").gameObject;
        g.SetActive(true);
        this.transform.rotation = Quaternion.identity;
        Vector3 v = arcamera.transform.position;
        v.y = this.transform.position.y;
        this.transform.LookAt(v);
        yield return new WaitForSeconds(2f);
        animNum = 1;
        anim.SetInteger("doing", 1);
        Voice.Hello();
        yield return new WaitForSeconds(2f);
        animNum = 0;
        anim.SetInteger("doing", 0);
        yield return new WaitForSeconds(2f);
        yield return new WaitForSeconds(3f);
        GameManager.Instance.BGM.WalkBGM1();
        Destroy(audio1);
        Destroy(audio2);
        yield return new WaitForSeconds(3f);

        isFirst = false;
    }

    IEnumerator coHappyAnim() {
        yield return new WaitForSeconds(1f);
    }
}
