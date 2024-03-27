using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpot : MonoBehaviour
{
    public GameObject zombieSpotType1; // 1번째 종류의 좀비 스팟 프리팹
    public GameObject zombieSpotType2; // 2번째 종류의 좀비 스팟 프리팹
    public GameObject zombieSpotType3; // 3번째 종류의 좀비 스팟 프리팹

    public int minSpots = 30; // 최소 스팟 수
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

        GameObject selectedZombieSpot = null;
        Vector3 spawnPosition = Vector3.zero;

        int random = Random.Range(1, 4); // 1부터 3까지의 랜덤한 숫자 생성
        switch (random)
        {
            case 1:
                selectedZombieSpot = zombieSpotType1;
                
                break;
            case 2:
                selectedZombieSpot = zombieSpotType2;               
                break;
            case 3:
                selectedZombieSpot = zombieSpotType3;
                break;
        }

       

        // 좀비 스팟 생성
        Instantiate(selectedZombieSpot, spawnPosition, Quaternion.identity);
    }
}
