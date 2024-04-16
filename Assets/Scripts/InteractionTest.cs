using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NRKernal;
using UnityEngine.EventSystems;

public class InteractionTest : MonoBehaviour, IPointerClickHandler
{
    void Start() {
	NRInput.AddClickListener(ControllerHandEnum.Right, ControllerButton.APP, () =>
		{
			Debug.Log("ResetWorldMatrix");
			var poseTracker = NRSessionManager.Instance.NRHMDPoseTracker;
			poseTracker.ResetWorldMatrix();
		});
}

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("클릭함");
    }
}
