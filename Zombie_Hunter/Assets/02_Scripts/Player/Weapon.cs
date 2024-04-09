using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Weapon : MonoBehaviour
{
    public GameObject spearPrefab;
    public GameObject bowPrefab;
    public GameObject gunPrefab;
    public GameObject arrowPrefab;
    public GameObject arrowcase;

    public Transform weaponPosition;
    public Transform arrowPosition;
    public Transform arrowcasePosition;
    public GameObject currentWeapon;
    public GameObject currentArrow;
    public GameObject currentArrowcase;

    private int spearAttackIncrement = 5;
    private int bowAttackIncrement = 5;
    private int gunAttackIncrement = 5;

    public int spearAttack;
    public int bowAttack;
    public int gunAttack;

    private int upgradeCount = 0;

    public string Weaponname;
    public int damage;
    public Animator Basic;

    private void Start()
    {
        // ������� �ʱ� ���ݷ��� �����մϴ�.
        spearAttack = 10;
        bowAttack = 15;
        gunAttack = 15;
    }
    void Update()
    {
        // 1�� Ű�� ������ �� spear�� �����մϴ�.
        if (Input.GetKey(KeyCode.Alpha1))
        {
            SetWeapon(spearPrefab);
        }

        // 2�� Ű�� ������ �� bow�� �����մϴ�.
        if (Input.GetKey(KeyCode.Alpha2))
        {
            SetWeapon(bowPrefab);
            currentArrow=Instantiate(arrowPrefab,arrowPosition);
            currentArrowcase=Instantiate(arrowcase, arrowcasePosition);
        }           
        // 3�� Ű�� ������ �� gun�� �����մϴ�.
        if (Input.GetKey(KeyCode.Alpha3))
        {
            SetWeapon(gunPrefab);      
        }
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


    private void SetWeapon(GameObject weaponPrefab)
    {
        // ���� ���⸦ ��Ȱ��ȭ�մϴ�.
        Destroy(currentWeapon);
        Destroy(currentArrow);
        Destroy(currentArrowcase);

        // ���ο� ���⸦ Ȱ��ȭ�ϰ� ��ġ�� �����մϴ�.
        currentWeapon = Instantiate(weaponPrefab, weaponPosition.position, weaponPrefab.transform.rotation, weaponPosition);
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
    public int GetDamage()
    {
        return damage;
    }
}
