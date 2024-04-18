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
    private GameObject FindSticker;
    private GameObject Enemies;
    private GameObject Done;
    private GameObject ARObj;
    void Start()
    {
        FreezeCntText = GameObject.Find("Canvas/freezeCount").GetComponent<TMP_Text>();
        Enemies = GameObject.Find("Enemies");
        FindSticker = GameObject.Find("Canvas/findSticker");
        Done = GameObject.Find("Canvas/Done");
        ARObj = GameObject.Find("ARGameObject");


        FreezeCntText.gameObject.SetActive(false);
        Done.SetActive(false);

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
            FinSubGame();
    }

    public void FreezeScore()
    {
        count += 1;
        Debug.Log($"{count}");
        FreezeCntText.text = $"죽인 횟수 : {count}";
    }

    public void StartSubGame() //스티커 인식되고 게임 시작 (ARGameObject.cs)
    {
        FreezeCntText.gameObject.SetActive(true);
        FindSticker.SetActive(false);
        Enemies.SetActive(true);

    }

    public void FinSubGame()
    {
        Done.SetActive(true);
        ARObj.SetActive(false);
        FreezeCntText.gameObject.SetActive(false);
        Enemies.SetActive(false);

    }

    
}
