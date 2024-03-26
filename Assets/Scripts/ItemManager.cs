using System.Collections;
using System.Collections.Generic;
using NRKernal;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ItemManager : MonoBehaviour, IPointerClickHandler
{
    private EndGame endGameInstance;

    public void Start()
    {
        endGameInstance = GameObject.FindGameObjectWithTag("endgame").GetComponent<EndGame>();

        NRInput.AddClickListener(ControllerHandEnum.Right, ControllerButton.APP, () =>
            {
                Debug.Log("ResetWorldMatrix");
                var poseTracker = NRSessionManager.Instance.NRHMDPoseTracker;
                poseTracker.ResetWorldMatrix();
            });
    }

    public void Update()
    {
        if(endGameInstance.getItemCount() == 6)
        {
            endGameInstance.endGame();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
            endGameInstance.countScore();
    }
}
