using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossZombieSpot : MonoBehaviour
{
    public GameObject BosszombieSpot;
    private Vector3 bossBoundaryPosition;

    public int minSpots = 7; // 최소 스팟 수
    public int maxSpots = 12; // 최대 스팟 수
    
    void Start()
    {
        bossBoundaryPosition = FindObjectOfType<MapDivider>().BossBoundary;
        SpawnBossZombieSpots();
    }

    void SpawnBossZombieSpots()
    {
        // 랜덤한 수의 보스 좀비 스팟 생성
        int spots = Random.Range(minSpots, maxSpots + 1);
        for (int i = 0; i < spots; i++)
        {
            // BossBoundary 내 랜덤 위치 생성
            Vector3 spawnPosition = new Vector3(Random.Range(bossBoundaryPosition.x - 5f, bossBoundaryPosition.x + 5f),
                                                bossBoundaryPosition.y,
                                                Random.Range(bossBoundaryPosition.z - 5f, bossBoundaryPosition.z + 5f));

            // 보스 좀비 스팟 생성
            Instantiate(BosszombieSpot, spawnPosition, Quaternion.identity);
        }
    }
}
