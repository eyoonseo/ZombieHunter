using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform player; // 플레이어의 Transform 컴포넌트

    // 카메라와 플레이어 간의 초기 거리와 각도
    public Vector3 cameraOffset = new Vector3(0f, 15f, -15f);

    // 카메라 이동 속도
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        if (player != null)
        {
            // 플레이어의 위치에 카메라의 초기 위치를 더함으로써 카메라의 상대 위치를 설정
            Vector3 desiredPosition = player.position + cameraOffset;

            // 부드러운 이동을 위해 Lerp 사용
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // 카메라를 원하는 위치로 이동
            transform.position = smoothedPosition;

        }
        else
        {
            Debug.LogWarning("플레이어가 설정되지 않았습니다.");
        }
    }
}









