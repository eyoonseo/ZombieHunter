using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class ZombieController : MonoBehaviour
{
    public int zombieHP = 30;
    public int virus = 5;
    public float rotationSpeed = 100;
    private PlayerController playerController;

    public int attackPower;
    public float attackCurTime;

    public GameObject zombie;
    public Transform target;
    public GameObject potionPrefab;
    public GameObject bandagePrefab;
    public GameObject aidkitPrefab;
    public GameObject medicationPrefab;
    public GameObject coinPrefab;
    public GameObject tokenPrefab;
    public GameObject bloodEffect;

    public Slider Hpbar;

    AttackPlayer attackPlayer;
    FollowPlayer followPlayer;
   
    public Animator zombieAnim;//좀비 상태에 따른 애니메이터



    public int minX = -149; // 사각형의 왼쪽 상단 모서리 X 좌표
    public int minZ = -149; // 사각형의 왼쪽 상단 모서리 Y 좌표
    public int maxX = 149; // 사각형의 오른쪽 하단 모서리 X 좌표
    public int maxZ = 149; // 사각형의 오른쪽 하단 모서리 Y 좌표

    private Vector3 targetPosition;
    public float moveSpeed = 0.5f;

    void Start()
    {
        // 좀비의 초기 위치를 랜덤하게 지정합니다.
        transform.position = GetRandomPosition();
        // 좀비가 처음 움직일 목표 위치를 설정합니다.
        targetPosition = GetRandomPosition();
        //zombieAnim = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
        attackPlayer = GetComponentInChildren<AttackPlayer>();
        followPlayer = GetComponentInChildren<FollowPlayer>();
    }

    void Update()
    {
        
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
                    targetPosition = GetRandomPosition();
        }

          // 새로운 목표 위치로 좀비를 움직입니다.
          transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);


    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == ("Spear"))
    //    {
    //        zombieHP -= weapon.spearAttack;
    //        if (zombieHP <= 0)
    //        {
    //            zombieAnim.SetTrigger("DIE");
    //            Destroy(zombie.gameObject);
    //            playerController.playerLV += 10;

    //            playerController.LVbar.value = playerController.playerLV;

    //            SpawnRandomItem();
    //        }

    //        Instantiate(bloodEffect, transform.position, transform.rotation); 
    //    }
       
    //}

    public void TakeDamage(int dmg)
    {
        zombieHP -= dmg;
        if (zombieHP <= 0)
        {
            zombieAnim.SetTrigger("DIE");
            Destroy(zombie.gameObject);
            playerController.playerLV += 10;

            playerController.LVbar.value = playerController.playerLV;

            SpawnRandomItem();
        }
        
    }

    public void SpawnRandomItem()
    {
        // Define the range of items to spawn
        int minItems = 2;
        int maxItems = 4;

        // Randomly determine the number of items to spawn within the range
        int numItems = Random.Range(minItems, maxItems + 1);
        // 아이템 배열 생성
        GameObject[] items = { potionPrefab, bandagePrefab, aidkitPrefab, medicationPrefab, coinPrefab, tokenPrefab };

        for (int i = 0; i < numItems; i++)
        {
            // 랜덤한 아이템 선택
            GameObject randomItem = items[Random.Range(0, items.Length)];
            Instantiate(randomItem, zombie.transform.position, Quaternion.identity);
        }
    }


    // 주어진 사각형 범위 내에서 랜덤한 위치를 반환하는 함수
    private Vector3 GetRandomPosition()
    {
        float x = Random.Range(minX, maxX + 1);
        float z = Random.Range(minZ, maxZ + 1);
        return new Vector3(x, 0f, z);
    }
}


