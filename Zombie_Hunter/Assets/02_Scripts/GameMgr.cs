using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public GameObject panel;
    
    void Update()
    {
        // F1 Ű�� ������ ��
        if (Input.GetKeyDown(KeyCode.F1))
        {
            // �г��� Ȱ��ȭ�Ǿ� �ִٸ� ��Ȱ��ȭ�ϰ�, ��Ȱ��ȭ�Ǿ� �ִٸ� Ȱ��ȭ�մϴ�.
            panel.SetActive(!panel.activeSelf);
        }
    }
}
