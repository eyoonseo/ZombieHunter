using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraMove : MonoBehaviour
{
    public Transform player; // 플레이어의 Transform을 저장할 변수
    private Vector3 offset; // 초기 카메라 위치와 플레이어 간의 상대적인 위치를 저장할 변수

    void Start()
    {
        // 초기 카메라 위치와 플레이어 간의 상대적인 위치를 계산합니다.
        offset = transform.position - player.position;
    }

    void Update()
    {
        if (player != null)
        {
            // 플레이어의 현재 위치에 초기 상대적인 위치를 더하여 카메라의 위치를 설정합니다.
            transform.position = player.position + offset;
        }
    }
}









