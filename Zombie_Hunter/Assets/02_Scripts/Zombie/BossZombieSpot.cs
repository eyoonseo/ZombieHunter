using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossZombieSpot : MonoBehaviour
{
    public GameObject BosszombieSpot;
    private Vector3 bossBoundaryPosition;

    public int minSpots = 7; // �ּ� ���� ��
    public int maxSpots = 12; // �ִ� ���� ��
    
    void Start()
    {
        bossBoundaryPosition = FindObjectOfType<MapDivider>().BossBoundary;
        SpawnBossZombieSpots();
    }

    void SpawnBossZombieSpots()
    {
        // ������ ���� ���� ���� ���� ����
        int spots = Random.Range(minSpots, maxSpots + 1);
        for (int i = 0; i < spots; i++)
        {
            // BossBoundary �� ���� ��ġ ����
            Vector3 spawnPosition = new Vector3(Random.Range(bossBoundaryPosition.x - 5f, bossBoundaryPosition.x + 5f),
                                                bossBoundaryPosition.y,
                                                Random.Range(bossBoundaryPosition.z - 5f, bossBoundaryPosition.z + 5f));

            // ���� ���� ���� ����
            Instantiate(BosszombieSpot, spawnPosition, Quaternion.identity);
        }
    }
}
