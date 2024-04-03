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
        // 1�� Ű�� ������ �� spear�� �����մϴ�.
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Instantiate(spearPrefab, transform.position, Quaternion.identity);
        }

        // 2�� Ű�� ������ �� bow�� �����մϴ�.
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Instantiate(bowPrefab, transform.position, Quaternion.identity);
        }

        // 3�� Ű�� ������ �� gun�� �����մϴ�.
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Instantiate(gunPrefab, transform.position, Quaternion.identity);
        }
    }
}
