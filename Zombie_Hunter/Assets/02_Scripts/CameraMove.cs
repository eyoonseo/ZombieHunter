using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform player; // �÷��̾��� Transform ������Ʈ

    // ī�޶�� �÷��̾� ���� �ʱ� �Ÿ��� ����
    public Vector3 cameraOffset = new Vector3(0f, 15f, -15f);

    // ī�޶� �̵� �ӵ�
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        if (player != null)
        {
            // �÷��̾��� ��ġ�� ī�޶��� �ʱ� ��ġ�� �������ν� ī�޶��� ��� ��ġ�� ����
            Vector3 desiredPosition = player.position + cameraOffset;

            // �ε巯�� �̵��� ���� Lerp ���
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // ī�޶� ���ϴ� ��ġ�� �̵�
            transform.position = smoothedPosition;

        }
        else
        {
            Debug.LogWarning("�÷��̾ �������� �ʾҽ��ϴ�.");
        }
    }
}









