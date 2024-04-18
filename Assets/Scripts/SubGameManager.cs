using System.Collections;
using System.Collections.Generic;
using NRKernal;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using NRKernal.NRExamples;
using System.Numerics;

public class SubGameManager : MonoBehaviour
{
    private int count = 0;
    private TMP_Text FreezeCntText;
    private GameObject FindSticker;
    private CameraSmoothFollow Enemies;
    private GameObject Done;
    private GameObject ARObj;
    void Start()
    {
        FreezeCntText = GameObject.Find("Canvas/freezeCount").GetComponent<TMP_Text>();
        Enemies = GameObject.Find("Enemies").GetComponent<CameraSmoothFollow>();
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

    public void StartSubGame(float posx, float posy) //스티커 인식되고 게임 시작 (ARGameObject.cs)
    {
        FreezeCntText.gameObject.SetActive(true);
        FindSticker.SetActive(false);
        CharacterPosition(posx,posy);
        Enemies.gameObject.SetActive(true);

    }

    public void CharacterPosition(float posx, float posy) //캐릭터의 포지션을 받아와서 Enemies 를 그 근처에 배치 시킴.
    {
        Enemies.gameObject.transform.position = new UnityEngine.Vector3(posx,posy,1);
    }

    public void FinSubGame()
    {
        Done.SetActive(true);
        ARObj.SetActive(false);
        FreezeCntText.gameObject.SetActive(false);
        Enemies.gameObject.SetActive(false);

    }

    
}
