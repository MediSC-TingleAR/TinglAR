using System.Collections;
using System.Collections.Generic;
using NRKernal;
using UnityEngine;
using UnityEngine.EventSystems;

public class CountScore : MonoBehaviour, IPointerClickHandler
{
    private SubGameManager subGameManager;
    private Animator attack_anim;
    void Start()
    {
        attack_anim = GetComponent<Animator>();
        subGameManager = GameObject.Find("subGameManager").GetComponent<SubGameManager>();

        NRInput.AddClickListener(ControllerHandEnum.Right, ControllerButton.APP, () =>
            {
                Debug.Log("ResetWorldMatrix");
                var poseTracker = NRSessionManager.Instance.NRHMDPoseTracker;
                poseTracker.ResetWorldMatrix();
            });
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        // attack_anim.StopPlayback();
        subGameManager.FreezeScore();
        // Invoke("RestartAnim",3f);
    }

    void RestartAnim()
    {
        attack_anim.StartPlayback();
    }
}
