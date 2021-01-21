using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

//[RequireComponent(typeof(ARTrackedImageManager))]
public class Tracked : MonoBehaviour
{
    public UnityEvent OnTargetFound;

    public ARTrackedImageManager m_TrackedImageManager;
    public GameObject traking;
    public Camera arcamera;

    private void Start()
    {
        traking = GameObject.Find("Tracking");
        arcamera = GameObject.Find("AR Camera").GetComponent<Camera>();

    }

    private void OnEnable()
    {
        m_TrackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    private void OnDisable()
    {
        m_TrackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    public void UpdateInfo(ARTrackedImage trackedImage)
    {
        if(trackedImage.trackingState != TrackingState.None)
        {
            traking.transform.position = arcamera.transform.position;
            OnTargetFound.Invoke();            
        }
    }

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach(var trackedImage in eventArgs.added)
        {
            UpdateInfo(trackedImage);
        }

        foreach(var trackedImage in eventArgs.updated)
        {
            UpdateInfo(trackedImage);
        }
    }
}
