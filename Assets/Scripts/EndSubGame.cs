using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSubGame : MonoBehaviour
{
    public GameObject Done;
    private GameObject Enemies;
    private GameObject Count;
    void Start()
    {
        Count = GameObject.Find("Canvas/freezeCount");
        Enemies = GameObject.Find("Enemies");

        Done.SetActive(false);

    }

    public void FinSubGame()
    {
        Done.SetActive(true);
        Count.SetActive(false);
        Enemies.SetActive(false);
    }
}
