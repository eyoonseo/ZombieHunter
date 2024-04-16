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

    public GameObject zombie;
    public GameObject bloodEffect;

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

    public Animator playerAnimator;
    public ZombieController zombieController;

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
    public bool isAttacking = false;
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
            if (playerAnimator != null)
            {
               playerAnimator.SetBool("Spear", false);  
            }
        }
        if (Input.GetMouseButtonDown(0))
        {

            if (!isAttacking) // 한 번만 공격하도록 확인
            {
                StartCoroutine(PlayAndDisableAnimation(2f));
                isAttacking = true; // 공격 중으로 플래그 설정
            }
        }
        

        // 2번 키를 눌렀을 때 bow를 생성합니다.
        //if (Input.GetKey(KeyCode.Alpha2))
        //{
        //    SetWeapon(bowPrefab);
        //    if (playerAnimator != null)
        //    {
        //        playerAnimator.SetBool("Bow", false);
        //    }
        //}
        //if(Input.GetMouseButtonDown(0))
        //{
        //        playerAnimator.SetBool("Bow", true);
        //        zombieController.zombieHP -= bowAttack;
        //        if (arrowcount > 0)
        //        {
        //            currentArrow = Instantiate(arrowPrefab, arrowPosition);
        //            arrowcount--;
        //            UpdateAmmoCount("Arrow", arrowcount);
        //        }
        //        else
        //        {
        //            ReloadAmmo("Arrow");
        //        }
        //    currentArrowcase = Instantiate(arrowcase, arrowcasePosition);
        //}
        //// 3번 키를 눌렀을 때 gun을 생성합니다.
        //if (Input.GetKey(KeyCode.Alpha3))
        //{
        //    SetWeapon(gunPrefab);
        //    if (playerAnimator != null)
        //    {
        //        playerAnimator.SetBool("Gun", false);
        //    }
        //}
        //if(Input.GetMouseButtonDown(0))
        //{
        //        playerAnimator.SetBool("Gun", true);
        //        zombieController.zombieHP -= gunAttack;
        //        if (bulletcount > 0)
        //        {
        //            currentBullet = Instantiate(bulletPrefab, bulletPosition);
        //            bulletcount--;
        //            UpdateAmmoCount("Bullet", arrowcount);
        //        }
        //        else
        //        {
        //            ReloadAmmo("Bullet");
        //        }
        //}
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (currentWeapon != null)
            {
                string weaponType = currentWeapon.tag;
                ReloadAmmo(weaponType);
            }
        }
 
    }
    private IEnumerator PlayAndDisableAnimation(float duration)
    {
        if (playerAnimator != null)
        {
            playerAnimator.SetBool("Spear", true); // 애니메이션 활성화   
            yield return new WaitForSeconds(duration); // 일정 시간 대기
            playerAnimator.SetBool("Spear", false); // 애니메이션 비활성화  
        }
    }
    



private void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.CompareTag("Zombie"))
    {
        // 피 이펙트를 생성할 위치 설정 (좀비와 충돌 지점의 중간 지점)
        Vector3 bloodEffectPosition = (transform.position + collision.transform.position) / 2f;
        // 피 이펙트를 생성
        GameObject BloodEffect = Instantiate(bloodEffect, bloodEffectPosition, Quaternion.identity);
        // 피 이펙트를 좀비 방향으로 회전시킴
        bloodEffect.transform.LookAt(collision.transform);
        // 피 이펙트 생성 후 몇 초 후에 제거
        Destroy(bloodEffect, 2f);
    }
 }

    private void OnTriggerEnter(Collider other)
    {
        // Player와 충돌한 오브젝트가 coin이라면
        if (other.gameObject.CompareTag("token"))
        {
            // 해당 coin을 파괴합니다.
            Destroy(other.gameObject);

            // 무기의 공격력을 업그레이드합니다.
            UpgradeWeaponAttack();
        }
        if (other.gameObject.CompareTag("Bullet"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Destroy(other.gameObject);
                bulletcount++;
            }
        }
        if (other.gameObject.CompareTag("Arrow"))
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
