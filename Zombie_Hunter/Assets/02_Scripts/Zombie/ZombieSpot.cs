using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpot : MonoBehaviour
{
    public GameObject zombieSpot;
    

    public int minSpots = 40; // 최소 스팟 수
    public int maxSpots = 50; // 최대 스팟 수
    public float mapWidth = 500f; // 지도의 가로 길이
    public float mapHeight = 500f; // 지도의 세로 길이
    public float spotRadius = 10f; // 스팟 간 최소 거리

    
    void Start()
    {
        
        // 랜덤한 수의 좀비 생성
        int Spots = Random.Range(minSpots, maxSpots + 1);
        for (int i = 0; i < Spots; i++)
        {
            SpawnZombieSpot();
        }
    }

    void SpawnZombieSpot()
    {      
        Vector3 spawnPosition = Vector3.zero;

        // 랜덤한 위치 생성
        bool spotIsValid = false;
        while (!spotIsValid)
        {
            spawnPosition = new Vector3(Random.Range(-mapWidth / 2f, mapWidth / 2f), 0f, Random.Range(-mapHeight / 2f, mapHeight / 2f));
            // 생성 위치가 다른 좀비 스팟과의 최소 거리를 충족하는지 확인
            spotIsValid = CheckValidSpot(spawnPosition);
        }

        // 좀비 스팟 생성
        Instantiate(zombieSpot, spawnPosition, Quaternion.identity);
    }

    bool CheckValidSpot(Vector3 position)
    {
        // 생성 위치와 다른 좀비 스팟 간의 거리를 검사하여 유효성을 확인
        foreach (GameObject zombieSpot in GameObject.FindGameObjectsWithTag("ZombieSpot"))
        {
            if (Vector3.Distance(position, zombieSpot.transform.position) < spotRadius)
            {
                // 생성 위치가 다른 좀비 스팟과의 최소 거리보다 가까우면 유효하지 않음
                return false;
            }
        }
        // 유효한 위치
        return true;
    }
}

