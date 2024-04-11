using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.EventSystems;

public class GoToNextScene : MonoBehaviour
{
    private int nextsceneIndex; //다음 씬 인덱스 저장
    private GameObject nextSceneBtn;
    private int currentSceneIndex;

    void Start()
    {   
        nextSceneBtn = gameObject;
        // 다음 씬 유동적으로 계산
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        nextsceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
    }

    public void onClickNextBtn() {
        SceneManager.LoadScene(nextsceneIndex);
    }
}
