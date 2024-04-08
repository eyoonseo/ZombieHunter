using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDivider : MonoBehaviour
{
    public Transform player; // 플레이어의 Transform
    
    // 지도의 가로 및 세로 길이
    public float mapWidth = 300f;
    public float mapHeight = 300f;

    // 세 개의 지역을 나타내는 경계 값
    public Vector3 BossBoundary; // 벡터로 변경
    public Vector3 CleanBoundary; // 초기값을 설정해줌

    // 원형 지역을 표시하는 반지름
    public float circleRadius1 = 40f;
    public float circleRadius2 = 50f;

    void Start()
    {
        // 경계를 랜덤으로 설정
        SetRandomBoundaries();
        player.position = new Vector3 (CleanBoundary.x,0, CleanBoundary.z);
    }

    void Update()
    {
        // 플레이어의 위치를 가져옴
        Vector3 playerPosition = player.position;

        // 플레이어가 어느 지역에 있는지 확인
        if (Vector3.Distance(BossBoundary, playerPosition) <= circleRadius1)
        {
            Debug.Log("플레이어는 보스 출몰 지역에 있습니다.");
        }
        else if (Vector3.Distance(CleanBoundary, playerPosition) <= circleRadius2)
        {
            Debug.Log("플레이어는 클린 지역에 있습니다.");
        }
        else
        {
            Debug.Log("플레이어는 보통 지역에 있습니다.");
        }
    }

    void OnDrawGizmosSelected()
    {
        // 지역 경계를 시각적으로 표시
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(BossBoundary, circleRadius1);

        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(CleanBoundary, circleRadius2);
    }

    void SetRandomBoundaries()
    {
        do
        {
            // 랜덤한 값을 설정하여 경계를 정의
            BossBoundary = new Vector3(Random.Range(-mapWidth / 2f, mapWidth / 2f), 0, Random.Range(-mapHeight / 2f, mapHeight / 2f));
            CleanBoundary = new Vector3(Random.Range(-mapWidth / 2f, mapWidth / 2f), 0, Random.Range(-mapHeight / 2f, mapHeight / 2f));
        }
        while (Vector3.Distance(BossBoundary, CleanBoundary) < circleRadius1 + circleRadius2); // 경계가 겹치지 않도록 반복
     
    }
   
}

