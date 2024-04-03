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
        // 무기들의 초기 공격력을 설정합니다.
        spearAttack = 10;
        bowAttack = 15;
        gunAttack = 15;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Player와 충돌한 오브젝트가 coin이라면
        if (other.CompareTag("coin"))
        {
            // 해당 coin을 파괴합니다.
            Destroy(other.gameObject);

            // 무기의 공격력을 업그레이드합니다.
            UpgradeWeaponAttack();
        }
    }

    private void UpgradeWeaponAttack()
    {
        if (upgradeCount < 3)
        {
            // 공격력을 증가합니다.
            spearAttack += spearAttackIncrement;
            bowAttack += bowAttackIncrement;
            gunAttack += gunAttackIncrement;

            upgradeCount++; // 증가 횟수를 기록합니다.

            Debug.Log("Weapon attack upgraded.");
        }
        else
        {
            Debug.Log("Max upgrade level reached.");
        }
    }
}
