using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ZombieController;

public class PlayerController : MonoBehaviour
{
   
    public float moveSpeed = 10f;
    private float xlimit = 249;
    private float zlimit = 249;
    public int playerHP = 100;

    public Slider HPbar;

    public int playerPower;
    public int posion=0;
    public ZombieController zombieController;

    private Vector3 cleanBoundaryPosition;

    //public enum PLAYERSTATE
    //{
    //    IDLE,
    //    WALK,
    //    QUIETWALK,
    //    ATTACK,
    //    DIE
    //}
    //public PLAYERSTATE playerState;

    public Animator Basic;

    public void Start()
    {
        zombieController = GetComponent<ZombieController>();
        Basic = GetComponentInChildren<Animator>(); //자식객체
    }


    void Update()
    {        
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (h != 0 || v != 0)
        {
            Basic.SetBool("Basic_Walk", true);
        }
        else
        {
            Basic.SetBool("Basic_Walk", false);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            // shift 키가 눌렸을 때 moveSpeed를 절반으로 줄임
            transform.Translate((moveSpeed / 2f) * h * Time.deltaTime, 0, (moveSpeed / 2f) * v * Time.deltaTime);

            if (transform.position.x < -xlimit )
            {
                transform.position = new Vector3(-xlimit, 0, transform.position.z);
            }
            if (transform.position.x > xlimit)
            {
                transform.position = new Vector3(xlimit, 0, transform.position.z);
            }
            if (transform.position.z < -zlimit)
            {
                transform.position = new Vector3(transform.position.x, 0, -zlimit);
            }
            if (transform.position.z > zlimit)
            {
                transform.position = new Vector3(transform.position.x, 0, zlimit);
            }

        }
        else
        {
            transform.Translate(moveSpeed * h * Time.deltaTime, 0, moveSpeed * v * Time.deltaTime);

            if (transform.position.x < -xlimit)
            {
                transform.position = new Vector3(-xlimit, 0, transform.position.z);
            }
            if (transform.position.x > xlimit)
            {
                transform.position = new Vector3(xlimit, 0, transform.position.z);
            }
            if (transform.position.z < -zlimit)
            {
                transform.position = new Vector3(transform.position.x, 0, -zlimit);
            }
            if (transform.position.z > zlimit)
            {
                transform.position = new Vector3(transform.position.x, 0, zlimit);
            }
        }

        //playerAnim.SetInteger("PLAYERSTATE", (int)playerState);
        //switch (playerState)
        //{
        //    case PLAYERSTATE.IDLE:

        //        break;
        //    case PLAYERSTATE.WALK:
        //        break;
        //    case PLAYERSTATE.QUIETWALK:
        //        break;
        //    case PLAYERSTATE.ATTACK:
        //        playerAnim.SetBool("Hunt", true);
        //        break;
        //    case PLAYERSTATE.DIE:
        //        playerAnim.SetBool("Die", true);
        //        break;
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        Damaged();
    }

    //public void Damaged(int attackPower)
    //{
    //    if (CompareTag("Zombie"))
    //    {
    //        playerHP -= attackPower;
    //        posion += zombieController.virus;
    //        if(posion == 100)
    //        {
    //               // playerState = PLAYERSTATE.DIE;
    //        }
    //    }
    //}

    void Damaged()
    {
        if (playerHP > 0)
        {
            if (CompareTag("Zombie"))
                playerHP -= 10;
            if (CompareTag("Boss"))
                playerHP -= 20;
        }
        else
        {
            Destroy(gameObject);
            GameOver();
        }
    }
    void GameOver()
    {
        Debug.Log("게임 오버!");
        // 여기에 게임 오버 상태에 관련된 처리를 추가할 수 있습니다.
    }
}