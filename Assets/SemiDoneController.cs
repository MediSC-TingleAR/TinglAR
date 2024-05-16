using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using OpenCVForUnityExample;
using UnityEngine;

public class SemiDoneController : MonoBehaviour
{
    [SerializeField] private GameObject GJ;
    [SerializeField] private GameObject BossPopUp;
    [SerializeField] private GameObject Boss;

    void Start()
    {
        GJ.SetActive(false);
        BossPopUp.SetActive(false);
        StartCoroutine(StartBossGame());
    }
    IEnumerator StartBossGame()
    {
        yield return new WaitForSeconds(1);
        GJ.SetActive(true);
        StartCoroutine(StartBossGame());

        yield return new WaitForSeconds(2);
        GJ.SetActive(false);
        BossPopUp.SetActive(true);
        Boss.SetActive(true);

        yield return new WaitForSeconds(2);
        BossPopUp.SetActive(false);
    }
}
