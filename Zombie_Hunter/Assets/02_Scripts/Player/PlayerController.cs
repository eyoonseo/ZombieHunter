using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ZombieController;

public class PlayerController : MonoBehaviour
{
    public GameObject Player;
    public float moveSpeed = 10f;
    private float xlimit = 149;
    private float zlimit = 149;
    public int playerHP = 100;
    public int maxHP = 100;
    public int posion = 0;

    public List<Weapon> weapons; // ���⸦ ������ ����Ʈ(List) ���� ����
    //private int currentWeaponIndex = 0; // ���� ���õ� ������ �ε����� ��Ÿ���� ���� ���� �� �ʱ�ȭ

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
        if (Input.GetKeyDown(KeyCode.Space) )
        {

            switch(tag)
            {
                case "Spear":
                    Basic.SetInteger("Att", 1);
                    break;
                case "Bow":
                    Basic.SetInteger("Att", 2);
                    break;
                case "Gun":
                    Basic.SetInteger("Att", 3);
                    break;
                default:
                    break;
            }
            
        }
        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "zombie")
        {
            playerHP -= 10;
            posion += 5;
            if (playerHP <= 0 || posion >= 100)
            {
                Debug.Log("##### GAME OVER #####");
                //gameOverPanel.SetActive(true);
                //gameObject.SetActive(false);
                //gameMgr.isGameOver = true;
            }
        }
        if(other.gameObject.tag == "item")
        {
            if (playerHP >= maxHP)
            {
                playerHP = maxHP;
            }
            else
            {
               //switch ()
                    
            }
        }
        if (other.gameObject.tag == "potion")
        {
            if (posion <= 15)
            {
                posion = 0;
            }
            else
            {
                posion -= 15;
            }
            Destroy(other.gameObject);
        }
           
    }


    //void Attack()
    //{
    //    if (weapons.Count == 0)
    //    {
    //        return;
    //    }
    //    Weapon currentWeapon = weapons[currentWeaponIndex];
    //    int damage = currentWeapon.GetDamage();
    //}

    void GameOver()
    {
        Debug.Log("���� ����!");
        // ���⿡ ���� ���� ���¿� ���õ� ó���� �߰��� �� �ֽ��ϴ�.
    }
}