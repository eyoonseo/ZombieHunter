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
            if (playerAnimator != null)
            {
               playerAnimator.SetBool("Spear", false);  
            }
        }
        if (Input.GetMouseButtonDown(0))
        {

            if (!isAttacking) // �� ���� �����ϵ��� Ȯ��
            {
                StartCoroutine(PlayAndDisableAnimation(2f));
                isAttacking = true; // ���� ������ �÷��� ����
            }
        }
        

        // 2�� Ű�� ������ �� bow�� �����մϴ�.
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
        //// 3�� Ű�� ������ �� gun�� �����մϴ�.
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
            playerAnimator.SetBool("Spear", true); // �ִϸ��̼� Ȱ��ȭ   
            yield return new WaitForSeconds(duration); // ���� �ð� ���
            playerAnimator.SetBool("Spear", false); // �ִϸ��̼� ��Ȱ��ȭ  
        }
    }
    



private void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.CompareTag("Zombie"))
    {
        // �� ����Ʈ�� ������ ��ġ ���� (����� �浹 ������ �߰� ����)
        Vector3 bloodEffectPosition = (transform.position + collision.transform.position) / 2f;
        // �� ����Ʈ�� ����
        GameObject BloodEffect = Instantiate(bloodEffect, bloodEffectPosition, Quaternion.identity);
        // �� ����Ʈ�� ���� �������� ȸ����Ŵ
        bloodEffect.transform.LookAt(collision.transform);
        // �� ����Ʈ ���� �� �� �� �Ŀ� ����
        Destroy(bloodEffect, 2f);
    }
 }

    private void OnTriggerEnter(Collider other)
    {
        // Player�� �浹�� ������Ʈ�� coin�̶��
        if (other.gameObject.CompareTag("token"))
        {
            // �ش� coin�� �ı��մϴ�.
            Destroy(other.gameObject);

            // ������ ���ݷ��� ���׷��̵��մϴ�.
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
        // ���� ���⸦ ��Ȱ��ȭ�մϴ�.
        Destroy(currentWeapon);
        Destroy(currentArrow);
        Destroy(currentArrowcase);
        Destroy(currentBullet);

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
        yield return new WaitForSeconds(2f); // ������ �ð�
        if (ammoType == "Arrow")
        {
            arrowcount = 10; // ������ �� �ʱ�ȭ
            UpdateAmmoCount(ammoType, arrowcount);
        }
        else if (ammoType == "Bullet")
        {
            bulletcount = 30; // ������ �� �ʱ�ȭ
            UpdateAmmoCount(ammoType, bulletcount);
        }
        isReloading = false;
        Debug.Log(ammoType + " reloaded.");
    }

    private void UpdateAmmoCount(string ammoType, int count)
    {
        // ȭ�鿡 �Ѿ� ������ ǥ���մϴ�.
        Debug.Log(ammoType + " Count: " + count);
    }
    public int GetDamage()
    {
        return damage;
    }
}
