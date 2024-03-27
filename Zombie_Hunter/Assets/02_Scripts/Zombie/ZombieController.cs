using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public int BosszombieHP = 80;
    public int zombie1HP = 30;
    public int zombie2HP = 50;



    public int minX = -249; // 사각형의 왼쪽 상단 모서리 X 좌표
    public int minZ = -249; // 사각형의 왼쪽 상단 모서리 Y 좌표
    public int maxX = 249; // 사각형의 오른쪽 하단 모서리 X 좌표
    public int maxZ = 249; // 사각형의 오른쪽 하단 모서리 Y 좌표

    private Vector3 targetPosition;
    public float moveSpeed = 0.5f;

    void Start()
    {
        // 좀비의 초기 위치를 랜덤하게 지정합니다.
        transform.position = GetRandomPosition();
        // 좀비가 처음 움직일 목표 위치를 설정합니다.
        targetPosition = GetRandomPosition();
    }

    void Update()
    {
        // 목표 위치에 도달했는지 확인하고 새로운 목표 위치를 설정합니다.
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            targetPosition = GetRandomPosition();
        }

        // 새로운 목표 위치로 좀비를 움직입니다.
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    // 주어진 사각형 범위 내에서 랜덤한 위치를 반환하는 함수
    private Vector3 GetRandomPosition()
    {
        float x = Random.Range(minX, maxX + 1);
        float z = Random.Range(minZ, maxZ + 1);
        return new Vector3(x, 0f, z);
    }
}


