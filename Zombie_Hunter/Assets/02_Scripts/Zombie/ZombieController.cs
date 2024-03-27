using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public int BosszombieHP = 80;
    public int zombie1HP = 30;
    public int zombie2HP = 50;



    public int minX = -249; // �簢���� ���� ��� �𼭸� X ��ǥ
    public int minZ = -249; // �簢���� ���� ��� �𼭸� Y ��ǥ
    public int maxX = 249; // �簢���� ������ �ϴ� �𼭸� X ��ǥ
    public int maxZ = 249; // �簢���� ������ �ϴ� �𼭸� Y ��ǥ

    private Vector3 targetPosition;
    public float moveSpeed = 0.5f;

    void Start()
    {
        // ������ �ʱ� ��ġ�� �����ϰ� �����մϴ�.
        transform.position = GetRandomPosition();
        // ���� ó�� ������ ��ǥ ��ġ�� �����մϴ�.
        targetPosition = GetRandomPosition();
    }

    void Update()
    {
        // ��ǥ ��ġ�� �����ߴ��� Ȯ���ϰ� ���ο� ��ǥ ��ġ�� �����մϴ�.
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            targetPosition = GetRandomPosition();
        }

        // ���ο� ��ǥ ��ġ�� ���� �����Դϴ�.
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    // �־��� �簢�� ���� ������ ������ ��ġ�� ��ȯ�ϴ� �Լ�
    private Vector3 GetRandomPosition()
    {
        float x = Random.Range(minX, maxX + 1);
        float z = Random.Range(minZ, maxZ + 1);
        return new Vector3(x, 0f, z);
    }
}


