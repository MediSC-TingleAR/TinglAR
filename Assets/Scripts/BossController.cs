using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NRKernal;
using UnityEngine.EventSystems;

public class BossController : MonoBehaviour
{
    private SubGameManager subGameManager;

    void Start()
    {
        subGameManager = GameObject.Find("subGameManager").GetComponent<SubGameManager>();
        NRInput.AddClickListener(ControllerHandEnum.Right, ControllerButton.APP, () =>
            {
                var poseTracker = NRSessionManager.Instance.NRHMDPoseTracker;
                poseTracker.ResetWorldMatrix();
            });
    }
}
