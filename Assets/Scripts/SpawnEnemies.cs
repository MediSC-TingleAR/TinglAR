using System.Collections;
using System.Collections.Generic;
using NRKernal.NRExamples;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject[] SpawnObjects; // 생성될 오브젝트

    private int maxCount = 15; //씬에 생성되는 오브젝트 최대 개수
    public int spawnCount = 0; //현재 생성된 오브젝트의 개수
    private int setFirstSpawnCount = 10;
    private Vector3 cameraPosi;
    private Quaternion cameraRott;
    private bool isSpawning = false;

    private Transform cameraInfo;
    public GameObject cam;

    void Start()
    {
        cameraInfo = cam.transform;
        FirstSpawn();
        gameObject.SetActive(false);
    }
    void Update()
    {
        if (gameObject.activeSelf && !isSpawning)
        {
            cameraPosi = cameraInfo.position;
            cameraRott = cameraInfo.rotation;
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

            Camera mainCamera = Camera.main;

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

            Camera mainCamera = Camera.main;

            spawnCount += 1;

            Debug.Log("Printing");
            yield return new WaitForSeconds(3);
        }

        isSpawning = false;
    }

    Vector3 GetRandomSpawnPosition()
    {
        float xPos = Random.Range(-1f, 1f); 
        float yPos = Random.Range(-0.5f, 0.5f);

        float xPos_n = cameraPosi.x + xPos;
        float yPos_n = cameraPosi.y + yPos;
        return new Vector3(xPos_n, yPos_n, 0);
    }

    Quaternion GetRandomSpawnRotation()
    {
        float xRot = 0f;
        float yRot = 180f;

        float xRot_n = cameraRott.x + xRot;
        float yRot_n = cameraRott.y + yRot;
        Quaternion randomRotation = Quaternion.Euler(xRot_n, yRot_n, 0);

        return randomRotation;
    }
}
