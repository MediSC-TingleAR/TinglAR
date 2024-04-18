using System.Collections;
using System.Collections.Generic;
using NRKernal.NRExamples;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject[] SpawnObjects; // 생성될 오브젝트

    private int maxCount = 10; //씬에 생성되는 오브젝트 최대 개수
    public int spawnCount = 0; //현재 생성된 오브젝트의 개수
    private int setFirstSpawnCount = 5;
    private bool isSpawning = false;

    void Start()
    {
        FirstSpawn();
        gameObject.SetActive(false);
    }
    void Update()
    {
        if (gameObject.activeSelf && !isSpawning)
        {
            StartCoroutine(StartSpawning());
        }
            
    }
    void FirstSpawn()
    {
        while (spawnCount < setFirstSpawnCount)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();
            Quaternion spawnRotation = GetRandomSpawnRotation();

            int randomIndex = Random.Range(0, SpawnObjects.Length);

            GameObject spawnedObject = Instantiate(SpawnObjects[randomIndex],transform);

            spawnedObject.transform.localPosition = spawnPosition;
            spawnedObject.transform.localRotation = spawnRotation;
            spawnedObject.SetActive(true);

            spawnCount += 1;
            
        }
    }

    IEnumerator StartSpawning()
    {
        isSpawning = true;

        while (spawnCount < maxCount)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();
            Quaternion spawnRotation = GetRandomSpawnRotation();
            
            int randomIndex = Random.Range(0, SpawnObjects.Length);

            GameObject spawnedObject = Instantiate(SpawnObjects[randomIndex],transform);
            spawnedObject.transform.localPosition = spawnPosition;
            spawnedObject.transform.localRotation = spawnRotation;
            spawnedObject.SetActive(true);

            spawnCount += 1;

            yield return new WaitForSeconds(3);
        }

        isSpawning = false;
    }

    Vector3 GetRandomSpawnPosition()
    {
        float xPos = transform.position.x + Random.Range(-1f, 1f); 
        float yPos = transform.position.y + Random.Range(-0.5f, 0.5f);

        return new Vector3(xPos, yPos, 0);
    }

    Quaternion GetRandomSpawnRotation()
    {
        float xRot = 0f;
        float yRot = 180f;

        Quaternion randomRotation = Quaternion.Euler(xRot, yRot, 0);

        return randomRotation;
    }
}
