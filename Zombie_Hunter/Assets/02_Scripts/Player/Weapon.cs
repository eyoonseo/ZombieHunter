using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject spearPrefab;
    public GameObject bowPrefab;
    public GameObject gunPrefab;

    void Update()
    {
        // 1번 키를 눌렀을 때 spear를 생성합니다.
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Instantiate(spearPrefab, transform.position, Quaternion.identity);
        }

        // 2번 키를 눌렀을 때 bow를 생성합니다.
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Instantiate(bowPrefab, transform.position, Quaternion.identity);
        }

        // 3번 키를 눌렀을 때 gun을 생성합니다.
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Instantiate(gunPrefab, transform.position, Quaternion.identity);
        }
    }
}
