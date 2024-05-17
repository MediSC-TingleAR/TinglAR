using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    SpawnEnemies spawns;

    void Start()
    {
        spawns = GameObject.Find("Enemies").GetComponent<SpawnEnemies>();

        spawns.SpawnObject();
    }
}
