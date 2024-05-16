using NRKernal;
using UnityEngine;
using TMPro;
using NRKernal.NRExamples;
using UnityEngine.Timeline;


public class SubGameManager : MonoBehaviour
{
    [HideInInspector]public int count = 0;
    private GameObject FindSticker;
    private CameraSmoothFollow Enemies;
    private GameObject Done;
    private GameObject ARObj;
    private GameObject Boss;
    private GameObject SemiDone;
    void Start()
    {
        Enemies = GameObject.Find("Enemies").GetComponent<CameraSmoothFollow>();
        FindSticker = GameObject.Find("Canvas/findSticker");
        Done = GameObject.Find("Canvas/Done");
        ARObj = GameObject.Find("ARGameObject");
        Boss = GameObject.Find("Boss");
        SemiDone = GameObject.Find("Canvas/Semi_Done");

        Done.SetActive(false);
        SemiDone.SetActive(false);
        Boss.SetActive(false);

        NRInput.AddClickListener(ControllerHandEnum.Right, ControllerButton.APP, () =>
            {
                Debug.Log("ResetWorldMatrix");
                var poseTracker = NRSessionManager.Instance.NRHMDPoseTracker;
                poseTracker.ResetWorldMatrix();
            });
    }
    void Update()
    {
        if (count == 10)
            SemiFinSubGame();
    }

    public void StartSubGame(float posx, float posy) //스티커 인식되고 게임 시작 (ARGameObject.cs)
    {
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

    }

    public void SemiFinSubGame()
    {
        SemiDone.SetActive(true);
        Enemies.gameObject.SetActive(false);


    }

    
}
