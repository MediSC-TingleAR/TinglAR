using System.Collections;
using System.Collections.Generic;
using NRKernal.NRExamples;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject[] SpawnObjects; // 생성될 오브젝트
    
    [SerializeField]
    private int maxCount = 30; //씬에 생성되는 오브젝트 최대 개수
    public int spawnCount; //현재 생성된 오브젝트의 개수
    private CameraSmoothFollow cameraposition;

    void Start()
    {
        StartCoroutine(StartSpawning());
        cameraposition = GameObject.Find("Canvas").GetComponent<CameraSmoothFollow>();
    }
    void Update()
    {
        if (gameObject.activeSelf)
            StartCoroutine(StartSpawning());
    }

    IEnumerator StartSpawning()
    {
        while (spawnCount < maxCount)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();
            
            int randomIndex = Random.Range(0, SpawnObjects.Length);

            GameObject spawnedObject = Instantiate(SpawnObjects[randomIndex],transform);
            spawnedObject.transform.localPosition = spawnPosition;
            spawnedObject.transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
            spawnedObject.SetActive(true);

            Camera mainCamera = Camera.main;

            spawnCount += 1;

            yield return new WaitForSeconds(3);
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        float xPos = Random.Range(-1.3f, 1.3f); 
        float yPos = Random.Range(-1f, 1f);

        xPos = cameraposition.cameraPosi.x + xPos;
        yPos = cameraposition.cameraPosi.y + yPos;

        return new Vector3(xPos, yPos, 0);
    }
}
