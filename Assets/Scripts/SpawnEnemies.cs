using System.Collections;
using System.Collections.Generic;
using NRKernal.NRExamples;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject[] SpawnObjects;
    public int enemySpawn = 5;
    [SerializeField] private int maxCount = 10;
    private int enemycount = 0;
    [HideInInspector] public int spawnCount = 0; //현재 화면에 떠있는 Enemy 수
    private float spawnRadiusX = 1.5f;
    private float spawnRadiusY = 0.4f;
    private float spawnInterval = 2f; // Spawn 간격
    private int maxAttempts = 10; // 충돌 체크를 위한 최대 시도 횟수
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
        enemycount = enemySpawn;
        for (int i = 0; i < enemySpawn; i++)
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

        while (spawnCount < enemySpawn && enemycount < maxCount)
        {
            SpawnObject(); // 객체 생성
            enemycount ++;
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
