using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpot : MonoBehaviour
{
    public GameObject zombieSpotType1; // 1��° ������ ���� ���� ������
    public GameObject zombieSpotType2; // 2��° ������ ���� ���� ������
    public GameObject zombieSpotType3; // 3��° ������ ���� ���� ������

    public int minSpots = 30; // �ּ� ���� ��
    public int maxSpots = 50; // �ִ� ���� ��
    public float mapWidth = 500f; // ������ ���� ����
    public float mapHeight = 500f; // ������ ���� ����
    public float spotRadius = 10f; // ���� �� �ּ� �Ÿ�

    
    void Start()
    {
        
        // ������ ���� ���� ����
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

        int random = Random.Range(1, 4); // 1���� 3������ ������ ���� ����
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

       

        // ���� ���� ����
        Instantiate(selectedZombieSpot, spawnPosition, Quaternion.identity);
    }
}
