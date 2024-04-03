using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMgr : MonoBehaviour
{
    public GameObject spear;
    public GameObject bow;
    public GameObject gun;

    private int spearAttackIncrement = 5;
    private int bowAttackIncrement = 5;
    private int gunAttackIncrement = 5;

    public int spearAttack;
    public int bowAttack;
    public int gunAttack;

    private int upgradeCount = 0;

    private void Start()
    {
        // ������� �ʱ� ���ݷ��� �����մϴ�.
        spearAttack = 10;
        bowAttack = 15;
        gunAttack = 15;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Player�� �浹�� ������Ʈ�� coin�̶��
        if (other.CompareTag("coin"))
        {
            // �ش� coin�� �ı��մϴ�.
            Destroy(other.gameObject);

            // ������ ���ݷ��� ���׷��̵��մϴ�.
            UpgradeWeaponAttack();
        }
    }

    private void UpgradeWeaponAttack()
    {
        if (upgradeCount < 3)
        {
            // ���ݷ��� �����մϴ�.
            spearAttack += spearAttackIncrement;
            bowAttack += bowAttackIncrement;
            gunAttack += gunAttackIncrement;

            upgradeCount++; // ���� Ƚ���� ����մϴ�.

            Debug.Log("Weapon attack upgraded.");
        }
        else
        {
            Debug.Log("Max upgrade level reached.");
        }
    }
}
