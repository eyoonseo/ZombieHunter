using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public GameObject panel;
    
    void Update()
    {
        // F1 키를 눌렀을 때
        if (Input.GetKeyDown(KeyCode.F1))
        {
            // 패널이 활성화되어 있다면 비활성화하고, 비활성화되어 있다면 활성화합니다.
            panel.SetActive(!panel.activeSelf);
        }
    }
}
