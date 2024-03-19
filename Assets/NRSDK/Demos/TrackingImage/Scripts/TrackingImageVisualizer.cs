using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NRKernal;

public class TrackingImageVisualizer : MonoBehaviour
{
    public NRTrackableImage image;
    public GameObject wand;

    void Update()
    {
        Debug.Log("HELLO");
        if(image == null)
        {
            wand.SetActive(false);
            return;
        }
        var center = image.GetCenterPose();
        transform.position = center.position;
        transform.rotation = center.rotation;
        wand.SetActive(true);
    }
}