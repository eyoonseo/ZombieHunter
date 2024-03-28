using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ZombieController;

public class PlayerController : MonoBehaviour
{
   
    public float moveSpeed = 10f;
    private float xlimit = 249;
    private float zlimit = 249;
    public int playerHP = 100;
    public int playerPower;
    public int posion=0;
    public ZombieController zombieController;

    public GameObject iconPanel;

    public enum PLAYERSTATE
    {
        WALK,
        QUIETWALk,
        ATTACK,
        DIE
    }
    public PLAYERSTATE playerState;
    public Animator playerAnim;

    public void Start()
    {
        zombieController = GetComponent<ZombieController>();
    }
    void Update()
    {        
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

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

        playerAnim.SetInteger("PLAYERSTATE", (int)playerState);
        switch (playerState)
        {
            case PLAYERSTATE.WALK:
                break;
            case PLAYERSTATE.QUIETWALk:
                break;
            case PLAYERSTATE.ATTACK:
                playerAnim.SetBool("Hunt", true);
                break;
            case PLAYERSTATE.DIE:
                playerAnim.SetBool("Die", true);
                break;
        }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            // iconPanel이 활성화되어 있으면 비활성화, 비활성화되어 있으면 활성화
            iconPanel.SetActive(!iconPanel.activeSelf);
        }

    }

    public void Damaged(int attackPower)
    {
        if (CompareTag("Zombie"))
        {
            playerHP -= attackPower;
            posion += zombieController.virus;
            if(posion == 100)
            {
                    playerState = PLAYERSTATE.DIE;
            }
        }
    }

    public void Attack()
    {
        if (CompareTag("Zombie"))
        {
            zombieController.zombieHP -= playerPower;
        }
    }
 
}
    

