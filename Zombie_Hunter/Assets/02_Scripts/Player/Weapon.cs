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
    public GameObject bulletPrefab;
    public GameObject arrowPrefab;
    public GameObject arrowcase;

    public Transform weaponPosition;
    public Transform arrowPosition;
    public Transform arrowcasePosition;
    public Transform bulletPosition;
    public GameObject currentWeapon;
    public GameObject currentArrow;
    public GameObject currentArrowcase;
    public GameObject currentBullet;

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

    public int arrowcount = 15;
    public int bulletcount = 30;
    public bool isReloading = false;

    private void Start()
    {
        // 무기들의 초기 공격력을 설정합니다.
        spearAttack = 10;
        bowAttack = 15;
        gunAttack = 15;
    }
    void Update()
    {
        // 1번 키를 눌렀을 때 spear를 생성합니다.
        if (Input.GetKey(KeyCode.Alpha1))
        {
            SetWeapon(spearPrefab);
        }

        // 2번 키를 눌렀을 때 bow를 생성합니다.
        if (Input.GetKey(KeyCode.Alpha2))
        {
            SetWeapon(bowPrefab);
            if (arrowcount > 0)
            {
                currentArrow = Instantiate(arrowPrefab, arrowPosition);
                arrowcount--;
                UpdateAmmoCount("Arrow",arrowcount);
            }
            else
            {
                ReloadAmmo("Arrow");
            }
            currentArrowcase=Instantiate(arrowcase, arrowcasePosition);
        }           
        // 3번 키를 눌렀을 때 gun을 생성합니다.
        if (Input.GetKey(KeyCode.Alpha3))
        {
            SetWeapon(gunPrefab);
            if (bulletcount > 0)
            {
                currentBullet = Instantiate(bulletPrefab, bulletPosition);
                bulletcount--;
                UpdateAmmoCount("Bullet", arrowcount);
            }
            else
            {
                ReloadAmmo("Bullet");
            }
        }

        
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
        if (other.CompareTag("Bullet"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Destroy(other.gameObject);
                bulletcount++;
            }
        }
        if (other.CompareTag("Arrow"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Destroy(other.gameObject);
                arrowcount++;
            }
        }
    }


    private void SetWeapon(GameObject weaponPrefab)
    {
        // 현재 무기를 비활성화합니다.
        Destroy(currentWeapon);
        Destroy(currentArrow);
        Destroy(currentArrowcase);
        Destroy(currentBullet);

        // 새로운 무기를 활성화하고 위치를 설정합니다.
        currentWeapon = Instantiate(weaponPrefab, weaponPosition.position, weaponPrefab.transform.rotation, weaponPosition);
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

    void ReloadAmmo(string ammoType)
    {
        if (!isReloading)
        {
            StartCoroutine(ReloadAmmoCoroutine(ammoType));
        }
    }

    private IEnumerator ReloadAmmoCoroutine(string ammoType)
    {
        isReloading = true;
        Debug.Log("Reloading " + ammoType + "...");
        yield return new WaitForSeconds(2f); // 재장전 시간
        if (ammoType == "Arrow")
        {
            arrowcount = 10; // 재장전 후 초기화
            UpdateAmmoCount(ammoType, arrowcount);
        }
        else if (ammoType == "Bullet")
        {
            bulletcount = 30; // 재장전 후 초기화
            UpdateAmmoCount(ammoType, bulletcount);
        }
        isReloading = false;
        Debug.Log(ammoType + " reloaded.");
    }

    private void UpdateAmmoCount(string ammoType, int count)
    {
        // 화면에 총알 개수를 표시합니다.
        Debug.Log(ammoType + " Count: " + count);
    }
    public int GetDamage()
    {
        return damage;
    }
}
