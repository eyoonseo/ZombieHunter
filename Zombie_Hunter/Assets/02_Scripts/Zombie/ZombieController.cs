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

    public Slider LVbar;

    //public enum ZOMBIESTATE
    //{
    //   WALK,
    //    RUN,
    //    ATTACK,
    //    DIE
    //}
    //public ZOMBIESTATE zombieState;
    //public Animator zombieAnim;//���� ���¿� ���� �ִϸ�����
    //private bool isDead = false;



    public int minX = -249; // �簢���� ���� ��� �𼭸� X ��ǥ
    public int minZ = -249; // �簢���� ���� ��� �𼭸� Y ��ǥ
    public int maxX = 249; // �簢���� ������ �ϴ� �𼭸� X ��ǥ
    public int maxZ = 249; // �簢���� ������ �ϴ� �𼭸� Y ��ǥ

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
    }

    void Update()
    {

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
                    targetPosition = GetRandomPosition();
        }

          // ���ο� ��ǥ ��ġ�� ���� �����Դϴ�.
          transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        //
        //    zombieAnim.SetInteger("ZOMBIESTATE", (int)zombieState);

        //    switch (zombieState)
        //    {
        //        case ZOMBIESTATE.WALK:
        //            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        //            {
        //                targetPosition = GetRandomPosition();
        //            }

        //            // ���ο� ��ǥ ��ġ�� ���� �����Դϴ�.
        //            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        //            if (playerFollow.CompareTag("Player"))
        //            {
        //                zombieState = ZOMBIESTATE.RUN;
        //            }
        //            break;
        //        case ZOMBIESTATE.RUN:
        //            if(playerAttack.CompareTag("Player"))
        //            {
        //                zombieState = ZOMBIESTATE.ATTACK;
        //            }
        //            break;
        //        case ZOMBIESTATE.ATTACK:                
        //            if (targetPlayer != null)
        //            {
        //                transform.LookAt(targetPlayer.transform);
        //                zombieAnim.SetBool("Attack", true);
        //            }
        //            playerController.Damaged(attackPower);
        //            break;
        //        case ZOMBIESTATE.DIE:               
        //            isDead = true;
        //            zombieAnim.SetBool("Dead", true);
        //            Destroy(this.gameObject);  
        //            break;
        //    }
        //}

        //public void Damage(int playerPower)
        //{
        //    if(isDead == false)
        //    {
        //        zombieHP -= playerPower;
        //        if (zombieHP <= 0)
        //        {
        //            zombieState = ZOMBIESTATE.DIE; 
        //        }
        //    }
    
    }

   
    // �־��� �簢�� ���� ������ ������ ��ġ�� ��ȯ�ϴ� �Լ�
    private Vector3 GetRandomPosition()
    {
        float x = Random.Range(minX, maxX + 1);
        float z = Random.Range(minZ, maxZ + 1);
        return new Vector3(x, 0f, z);
    }
}


