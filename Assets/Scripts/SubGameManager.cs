using System.Collections;
using System.Collections.Generic;
using NRKernal;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class SubGameManager : MonoBehaviour
{
    private int count = 0;
    private TMP_Text FreezeCntText;

    private EndSubGame endSubGame;
    void Start()
    {
        FreezeCntText = GameObject.Find("Canvas/freezeCount").GetComponent<TMP_Text>();
        endSubGame = GameObject.Find("subGameManager").GetComponent<EndSubGame>();

        NRInput.AddClickListener(ControllerHandEnum.Right, ControllerButton.APP, () =>
            {
                Debug.Log("ResetWorldMatrix");
                var poseTracker = NRSessionManager.Instance.NRHMDPoseTracker;
                poseTracker.ResetWorldMatrix();
            });
    }
    void Update()
    {
        if (count == 20)
        {
            if(FreezeCntText = null) Debug.Log ("FreezeCntText is null");
        if(endSubGame == null) Debug.Log ("endSubGame is null");
            endSubGame.FinSubGame();
        }
    }

    public void FreezeScore()
    {
        count += 1;
        Debug.Log($"{count}");
        FreezeCntText.text = $"Freeze Cnt : {count}";
    }
}
