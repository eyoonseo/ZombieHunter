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
   
    public Animator zombieAnim;//���� ���¿� ���� �ִϸ�����



    public int minX = -149; // �簢���� ���� ��� �𼭸� X ��ǥ
    public int minZ = -149; // �簢���� ���� ��� �𼭸� Y ��ǥ
    public int maxX = 149; // �簢���� ������ �ϴ� �𼭸� X ��ǥ
    public int maxZ = 149; // �簢���� ������ �ϴ� �𼭸� Y ��ǥ

    private Vector3 targetPosition;
    public float moveSpeed = 0.5f;

    void Start()
    {
        // ������ �ʱ� ��ġ�� �����ϰ� �����մϴ�.
        transform.position = GetRandomPosition();
        // ���� ó�� ������ ��ǥ ��ġ�� �����մϴ�.
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

          // ���ο� ��ǥ ��ġ�� ���� �����Դϴ�.
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
        // ������ �迭 ����
        GameObject[] items = { potionPrefab, bandagePrefab, aidkitPrefab, medicationPrefab, coinPrefab, tokenPrefab };

        for (int i = 0; i < numItems; i++)
        {
            // ������ ������ ����
            GameObject randomItem = items[Random.Range(0, items.Length)];
            Instantiate(randomItem, zombie.transform.position, Quaternion.identity);
        }
    }


    // �־��� �簢�� ���� ������ ������ ��ġ�� ��ȯ�ϴ� �Լ�
    private Vector3 GetRandomPosition()
    {
        float x = Random.Range(minX, maxX + 1);
        float z = Random.Range(minZ, maxZ + 1);
        return new Vector3(x, 0f, z);
    }
}


