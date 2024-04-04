using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraMove : MonoBehaviour
{
    public Transform player; // �÷��̾��� Transform�� ������ ����
    private Vector3 offset; // �ʱ� ī�޶� ��ġ�� �÷��̾� ���� ������� ��ġ�� ������ ����

    void Start()
    {
        // �ʱ� ī�޶� ��ġ�� �÷��̾� ���� ������� ��ġ�� ����մϴ�.
        offset = transform.position - player.position;
    }

    void Update()
    {
        if (player != null)
        {
            // �÷��̾��� ���� ��ġ�� �ʱ� ������� ��ġ�� ���Ͽ� ī�޶��� ��ġ�� �����մϴ�.
            transform.position = player.position + offset;
        }
    }
}









