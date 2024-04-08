using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ZombieController;

public class PlayerController : MonoBehaviour
{    
    public float moveSpeed = 10f;
    private float xlimit = 149;
    private float zlimit = 149;
    public int playerHP = 100;

    public List<Weapon> weapons; // ���⸦ ������ ����Ʈ(List) ���� ����
    private int currentWeaponIndex = 0; // ���� ���õ� ������ �ε����� ��Ÿ���� ���� ���� �� �ʱ�ȭ

    public Slider HPbar;
    public Slider LVbar;
    public Slider Posionbar;

    public Text LV;

    public int playerPower;
    public ZombieController zombieController;

    private Vector3 cleanBoundaryPosition;

    public Animator Basic;
    public void Start()
    {
        zombieController = GetComponent<ZombieController>();    
        Basic = GetComponentInChildren<Animator>(); //�ڽİ�ü  
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
            // shift Ű�� ������ �� moveSpeed�� �������� ����
            transform.Translate((moveSpeed / 2f) * h * Time.deltaTime, 0, (moveSpeed / 2f) * v * Time.deltaTime);
            Basic.SetBool("Slow_Walk", true);
        }
        else
        {
            transform.Translate(moveSpeed * h * Time.deltaTime, 0, moveSpeed * v * Time.deltaTime);
            Basic.SetBool("Slow_Walk", false);
        }
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


        // ���콺 ���� ��ư�� ������ ���� �ִϸ��̼��� ����
        if (Input.GetMouseButtonDown(0) && CompareTag("Spear"))
        {
                Basic.SetInteger("Att", 1);
            
        }
        if (Input.GetMouseButtonDown(0) && CompareTag("Bow"))
        {
                Basic.SetInteger("Att", 2);               
        }
        if (Input.GetMouseButtonDown(0) && CompareTag("Gun"))
        {
                Basic.SetInteger("Att", 3);
        }
       
    }

    void Attack()
    {
        if (weapons.Count == 0)
        {
            return;
        }
        Weapon currentWeapon = weapons[currentWeaponIndex];
        int damage = currentWeapon.GetDamage();
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

    
    void GameOver()
    {
        Debug.Log("���� ����!");
        // ���⿡ ���� ���� ���¿� ���õ� ó���� �߰��� �� �ֽ��ϴ�.
    }
}