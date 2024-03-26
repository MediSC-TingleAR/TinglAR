using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NRKernal;

public class TrackingImageVisualizer : MonoBehaviour
{
    public NRTrackableImage image;
    public GameObject wand;
    public GameObject notDetect;

    void Update()
    {
        if(image!=null) {
        var center = image.GetCenterPose();
        transform.position = center.position;
        transform.rotation = center.rotation;
        wand.SetActive(true);
        }
    }
}