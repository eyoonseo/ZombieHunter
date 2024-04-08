using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ZombieController : MonoBehaviour
{
    public int zombieHP = 30;
    public int virus = 5;
    private PlayerController playerController;
    

    public int attackPower;
    public float attackCurTime;

    public GameObject targetPlayer;
    public GameObject playerFollow;
    public GameObject playerAttack;

    public Slider Hpbar;
    

   
    public Animator zombieAnim;//좀비 상태에 따른 애니메이터
    //private bool isDead = false;



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

    void Run()
    {
        if (playerFollow.CompareTag("Player"))
        {
            moveSpeed *= 2;
        }
    }
    void Attack()
    {
        if(playerAttack.CompareTag("Player"))
        {
            zombieAnim.SetTrigger("Attack");
            Hpbar.value -= 10;
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


