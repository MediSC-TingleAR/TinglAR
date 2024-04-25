using System.Collections;
using System.Collections.Generic;
using NRKernal.NRExamples;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject[] SpawnObjects;
    public int setFirstSpawnCount = 5;
    private int maxCount = 5;
    public float spawnRadiusX = 1.5f;
    public float spawnRadiusY = 0.4f;
    public float spawnInterval = 2f; // Spawn 간격
    public int maxAttempts = 10; // 충돌 체크를 위한 최대 시도 횟수

    public int spawnCount = 0;
    private bool isSpawning = false;
    
    private Vector3 GetSafeSpawnPosition()
    {
        Vector3 spawnPosition;
        int attempts = 0;

        do
        {
            spawnPosition = GetRandomSpawnPosition();
            attempts++;
        } while (Physics.CheckSphere(spawnPosition, 0.3f) && attempts < maxAttempts);

        return spawnPosition;
    }

    private void SpawnObject()
    {
        Vector3 spawnPosition = GetSafeSpawnPosition();
        Quaternion spawnRotation = GetRandomSpawnRotation();

        int randomIndex = Random.Range(0, SpawnObjects.Length);

        GameObject spawnedObject = Instantiate(SpawnObjects[randomIndex], transform);

        spawnedObject.transform.localPosition = spawnPosition;
        spawnedObject.transform.localRotation = spawnRotation;
        spawnedObject.SetActive(true);

        spawnCount++;
    }

    void Start()
    {
        for (int i = 0; i < setFirstSpawnCount; i++)
        {
            SpawnObject(); // 처음에 지정된 수만큼 스폰
        }

        gameObject.SetActive(false); // 스폰 후 비활성화
    }

    void Update()
    {
        if (gameObject.activeSelf && !isSpawning)
        {
            StartCoroutine(StartSpawning());
        }
    }

    IEnumerator StartSpawning()
    {
        isSpawning = true;

        while (spawnCount < maxCount)
        {
            SpawnObject(); // 객체 생성
            yield return new WaitForSeconds(spawnInterval); // 스폰 간격
        }

        isSpawning = false;
    }

    public Vector3 GetRandomSpawnPosition()
    {
        float xPos = transform.position.x + Random.Range(-spawnRadiusX, spawnRadiusX); //1.5
        float yPos = transform.position.y + Random.Range(-spawnRadiusY, spawnRadiusY); //0.4
        
        return new Vector3(xPos, yPos, 0);
    }

    public Quaternion GetRandomSpawnRotation()
    {
        float xRot = 0f;
        float yRot = 180f;

        return Quaternion.Euler(xRot, yRot, 0);
    }
}
