using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpot : MonoBehaviour
{
    public GameObject zombieSpot;
    

    public int minSpots = 40; // �ּ� ���� ��
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
        Vector3 spawnPosition = Vector3.zero;

        // ������ ��ġ ����
        bool spotIsValid = false;
        while (!spotIsValid)
        {
            spawnPosition = new Vector3(Random.Range(-mapWidth / 2f, mapWidth / 2f), 0f, Random.Range(-mapHeight / 2f, mapHeight / 2f));
            // ���� ��ġ�� �ٸ� ���� ���̰��� �ּ� �Ÿ��� �����ϴ��� Ȯ��
            spotIsValid = CheckValidSpot(spawnPosition);
        }

        // ���� ���� ����
        Instantiate(zombieSpot, spawnPosition, Quaternion.identity);
    }

    bool CheckValidSpot(Vector3 position)
    {
        // ���� ��ġ�� �ٸ� ���� ���� ���� �Ÿ��� �˻��Ͽ� ��ȿ���� Ȯ��
        foreach (GameObject zombieSpot in GameObject.FindGameObjectsWithTag("ZombieSpot"))
        {
            if (Vector3.Distance(position, zombieSpot.transform.position) < spotRadius)
            {
                // ���� ��ġ�� �ٸ� ���� ���̰��� �ּ� �Ÿ����� ������ ��ȿ���� ����
                return false;
            }
        }
        // ��ȿ�� ��ġ
        return true;
    }
}

