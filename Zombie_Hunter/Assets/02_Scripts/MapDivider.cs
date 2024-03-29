using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDivider : MonoBehaviour
{
    public Transform player; // �÷��̾��� Transform
    public GameObject playerPrefab; // �÷��̾� ������

    // ������ ���� �� ���� ����
    public float mapWidth = 500f;
    public float mapHeight = 500f;

    // �� ���� ������ ��Ÿ���� ��� ��
    public Vector3 BossBoundary; // ���ͷ� ����
    public Vector3 CleanBoundary; // ���ͷ� ����

    // ���� ������ ǥ���ϴ� ������
    public float circleRadius1 = 40f;
    public float circleRadius2 = 50f;

    void Start()
    {
        // ��踦 �������� ����
        SetRandomBoundaries();
        SpawnPlayerInCleanArea();
    }

    void Update()
    {
        // �÷��̾��� ��ġ�� ������
        Vector3 playerPosition = player.position;

        // �÷��̾ ��� ������ �ִ��� Ȯ��
        if (Vector3.Distance(BossBoundary, playerPosition) <= circleRadius1)
        {
            Debug.Log("�÷��̾�� ���� ��� ������ �ֽ��ϴ�.");
        }
        else if (Vector3.Distance(CleanBoundary, playerPosition) <= circleRadius2)
        {
            Debug.Log("�÷��̾�� Ŭ�� ������ �ֽ��ϴ�.");
        }
        else
        {
            Debug.Log("�÷��̾�� ���� ������ �ֽ��ϴ�.");
        }
    }

    void OnDrawGizmosSelected()
    {
        // ���� ��踦 �ð������� ǥ��
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(BossBoundary, circleRadius1);

        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(CleanBoundary, circleRadius2);
    }

    void SetRandomBoundaries()
    {
        do
        {
            // ������ ���� �����Ͽ� ��踦 ����
            BossBoundary = new Vector3(Random.Range(-mapWidth / 2f, mapWidth / 2f), 0, Random.Range(-mapHeight / 2f, mapHeight / 2f));
            CleanBoundary = new Vector3(Random.Range(-mapWidth / 2f, mapWidth / 2f), 0, Random.Range(-mapHeight / 2f, mapHeight / 2f));
        }
        while (Vector3.Distance(BossBoundary, CleanBoundary) < circleRadius1 + circleRadius2); // ��谡 ��ġ�� �ʵ��� �ݺ�
    }

    void SpawnPlayerInCleanArea()
    {
        // Ŭ�� ���� ������ ������ ��ġ�� �÷��̾� ����
        Vector3 randomPosition = new Vector3(Random.Range(CleanBoundary.x - circleRadius2, CleanBoundary.x + circleRadius2), 1f, Random.Range(CleanBoundary.z - circleRadius2, CleanBoundary.z + circleRadius2));
        Instantiate(playerPrefab, randomPosition, Quaternion.identity);
    }
}

