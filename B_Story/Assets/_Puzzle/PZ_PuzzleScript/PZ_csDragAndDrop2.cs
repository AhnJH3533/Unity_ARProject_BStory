using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
public class PZ_csDragAndDrop2 : MonoBehaviour
{
    //public GameObject SelectedPiece;
    public Text txtName;
    private ARRaycastManager aRRaycastManager;
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    GameObject gObj = null;
    Plane objPlane;
    Vector3 mP;
    private AudioSource audioSource;
    public AudioClip touchSound;

    Ray GenerateMouseRay()
    {
        Vector3 mousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
        Vector3 mousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
        Vector3 mousePosF = Camera.main.ScreenToWorldPoint(mousePosFar);
        Vector3 mousePosN = Camera.main.ScreenToWorldPoint(mousePosNear);

        Ray mr = new Ray(mousePosN, mousePosF - mousePosN);
        return mr;

    }
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        
        aRRaycastManager = GameObject.FindWithTag("AR_SESSION").GetComponent<ARRaycastManager>();
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray mouseRay = GenerateMouseRay();
            RaycastHit hit;

            if (Physics.Raycast(mouseRay.origin, mouseRay.direction, out hit))
            {
                if (hit.transform.CompareTag("Puzzle"))
                {
                    if (!hit.collider.gameObject.GetComponent<PZ_csPicese>().isRightPosition)
                    {
                        audioSource.clip = touchSound;
                        audioSource.Play();
                        gObj = hit.transform.gameObject;
                        objPlane = new Plane(Camera.main.transform.forward*1, gObj.transform.position);
                        Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                        float rayDistance;
                        objPlane.Raycast(mRay, out rayDistance);
                        mP = gObj.transform.position - mRay.GetPoint(rayDistance);
                        this.GetComponent<PZ_csPicese>().Selected = true;
                    }

                }
            }

        }
        else if (Input.GetMouseButton(0) && gObj)
        {
            Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            float rayDistance;
            if (objPlane.Raycast(mRay, out rayDistance))
            {
                gObj.transform.position = mRay.GetPoint(rayDistance) + mP;
            }
        }
        else if (Input.GetMouseButtonUp(0) && gObj)
        {
            gObj = null;
            this.GetComponent<PZ_csPicese>().Selected = false;
        }


    }

}

