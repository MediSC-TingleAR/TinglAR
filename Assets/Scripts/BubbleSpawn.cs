using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject SpawnObject; //Prefab으로 생성될 오브젝트
    public static int bubbleCount;
    public int score=0;

    public bool playingGame = true;
    public bool didInit = false;

    void Start()
    {
        StartCoroutine(StartSpawing());
    }

    private void FixedUpdate()
    {
        if (bubbleCount < 20 && didInit)
            StartCoroutine(StartSpawing());
    }

    IEnumerator StartSpawing()
    {  
            while (bubbleCount < 20) // 총 5개씩 생성
            {
                Vector3 spawnPosition = GetRandomSpawnPosition();

                // Prefab 오브젝트를 인스턴스화
                GameObject spawnedObject = Instantiate(SpawnObject, transform);
                spawnedObject.transform.localPosition = spawnPosition;
                spawnedObject.transform.localRotation = Quaternion.identity; // (복제할 대상, 위치, 방향)
                spawnedObject.SetActive(true);

                // Debug.Log($"=========enemyCount: {bubbleCount}");

                // // 위치 정보 로그 출력
                // Debug.Log($"=========Object spawned at position: {spawnPosition}");

                // 메인 카메라의 위치 및 방향 정보 로그 출력
                Camera mainCamera = Camera.main;
                // if (mainCamera != null)
                // {
                //     Debug.Log($"=========Main Camera position: {mainCamera.transform.position}");
                //     Debug.Log($"=========Main Camera forward direction: {mainCamera.transform.forward}");
                // }

            bubbleCount += 1;
            score += 1;
            // Debug.Log("CURRENT SCORE " + score);

            yield return new WaitForSeconds(2); // 4초 기준으로 생성

            }

        didInit = true;
    }

    Vector3 GetRandomSpawnPosition()
    {
        float xPos = Random.Range(-0.3f, 0.3f); // Position X축 -2~ 4 사이의 랜덤 범위 생성
        float zPos = Random.Range(0.4f, 1.4f); // Position Z축 3 ~ 5 사이의 랜덤 범위 생성
        float yPos = Random.Range(-0.2f, 0.2f);

        return new Vector3(xPos, yPos, zPos);
    }

}