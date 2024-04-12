using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EndSubGame : MonoBehaviour
{
    public GameObject Done;
    private GameObject Enemies;
    private GameObject Count;
    private GameObject ARObj;
    void Start()
    {
        Count = GameObject.Find("Canvas/freezeCount");
        Enemies = GameObject.Find("Enemies");
        ARObj = GameObject.Find("ARGameObject");

        Done.SetActive(false);

    }

    public void FinSubGame()
    {
        Done.SetActive(true);

        ARObj.SetActive(false);
        Count.SetActive(false);
        Enemies.SetActive(false);
    }
}
