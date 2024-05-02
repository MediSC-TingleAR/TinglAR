using System.Collections;
using System.Collections.Generic;
using NRKernal;
using NRKernal.NREditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialBtnHandler : MonoBehaviour
{
    public GameObject[] tutorials; //튜토리얼 각 화면의 UI들
    public int currentIndex = 0;
    private ControllerHandEnum m_CurrentDebugHand = ControllerHandEnum.Right;

    public GameObject controllerClick;
    public GameObject Enemy;

    void Start()
    {
        for(int i=1; i<tutorials.Length; i++)
        {
            tutorials[i].SetActive(false);
        }
        Enemy.SetActive(false);   
    }

    void Update()
        {
            if (NRInput.GetAvailableControllersCount() < 2)
            {
                m_CurrentDebugHand = NRInput.DomainHand;
            }
            else
            {
                if (NRInput.GetButtonDown(ControllerHandEnum.Right, ControllerButton.TRIGGER))
                {
                    m_CurrentDebugHand = ControllerHandEnum.Right;
                }
                else if (NRInput.GetButtonDown(ControllerHandEnum.Left, ControllerButton.TRIGGER))
                {
                    m_CurrentDebugHand = ControllerHandEnum.Left;
                }
            }

            if (currentIndex != 4 && currentIndex < 7 && NRInput.GetButtonDown(m_CurrentDebugHand, ControllerButton.TRIGGER))
            {
                NextPanel();

            }
            else if (currentIndex == 4)
            {
                controllerClick.SetActive(false);
                Enemy.SetActive(true);

            }

        }

    public void NextPanel()
    {
        currentIndex ++;
        tutorials[currentIndex].SetActive(true);
        tutorials[currentIndex-1].SetActive(false);

    }
}

