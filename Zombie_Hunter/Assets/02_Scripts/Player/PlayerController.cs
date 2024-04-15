using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ZombieController;

public class PlayerController : MonoBehaviour
{
    public GameObject Player;
    public GameObject GameOverPanel;
    public float moveSpeed = 10f;
    private float xlimit = 149;
    private float zlimit = 149;
    public int playerHP = 100;
    public int playerLV = 0;
    public int maxHP = 100;
    public int posion = 0;

    public List<Weapon> weapons; // ���⸦ ������ ����Ʈ(List) ���� ����
    //private int currentWeaponIndex = 0; // ���� ���õ� ������ �ε����� ��Ÿ���� ���� ���� �� �ʱ�ȭ

    public Slider HPbar;
    public Slider LVbar;
    public Slider Posionbar;
    public Text LV;
    public Text Bandagecount;
    public Text AidKitcount;
    public Text Medicationcount;
    public Text Coincount;

    public int playerPower;
    public ZombieController zombieController;

    private Vector3 cleanBoundaryPosition;

    public Animator playerAnimator;
    public void Start()
    {
        zombieController = GetComponent<ZombieController>();
        playerAnimator = GetComponentInChildren<Animator>(); //�ڽİ�ü  
        Coincount.text = ":" + "000";
    }


    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (h != 0 || v != 0)
        {
            playerAnimator.SetBool("Basic_Walk", true);
        }
        else
        {
            playerAnimator.SetBool("Basic_Walk", false);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            // shift Ű�� ������ �� moveSpeed�� �������� ����
            transform.Translate((moveSpeed / 2f) * h * Time.deltaTime, 0, (moveSpeed / 2f) * v * Time.deltaTime);
            playerAnimator.SetBool("Slow_Walk", true);
        }
        else
        {
            transform.Translate(moveSpeed * h * Time.deltaTime, 0, moveSpeed * v * Time.deltaTime);
            playerAnimator.SetBool("Slow_Walk", false);
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

        if (Input.GetKeyDown(KeyCode.Return))
        {
            switch (tag)
            {
                case "Spear":
                    playerAnimator.SetBool("Spear", true);
                    break;
                case "Bow":
                    playerAnimator.SetBool("Bow", true);
                    break;
                case "Gun":
                    playerAnimator.SetBool("Gun", true);
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

            HPbar.value = playerHP;
            Posionbar.value = posion;
            if (playerHP <= 0 || posion >= 100)
            {
                Debug.Log("##### GAME OVER #####");
                GameOverPanel.SetActive(true);
                Time.timeScale = 0f;
                //gameMgr.isGameOver = true;
            }
        }
        if (other.CompareTag("Bandage"))
        {
            Bandagecount.text = (int.Parse(Bandagecount.text) + 1).ToString();
            Destroy(other.gameObject); // �������� �԰� ���� �������� �ı��մϴ�.
        }
        else if (other.CompareTag("FirstAidKit"))
        {
            AidKitcount.text = (int.Parse(AidKitcount.text) + 1).ToString();
            Destroy(other.gameObject); // �������� �԰� ���� �������� �ı��մϴ�.
        }
        else if (other.CompareTag("Medication"))
        {
            Medicationcount.text = (int.Parse(Medicationcount.text) + 1).ToString();
            Destroy(other.gameObject); // �������� �԰� ���� �������� �ı��մϴ�.
        }
        else if (other.CompareTag("Coin"))
        {
            Coincount.text = (int.Parse(Coincount.text) + 100).ToString();
            Destroy(other.gameObject); // �������� �԰� ���� �������� �ı��մϴ�.
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
    public void UseItem()
    {
        if (gameObject.tag == "Bandage")
        {
            if (playerHP >= maxHP)
            {
                playerHP = maxHP;
            }
            else
            {
                playerHP += 10;
                Bandagecount.text = (int.Parse(Bandagecount.text) - 1).ToString();
            }
            HPbar.value = playerHP;

        }
        if (gameObject.tag == "FirstAidKit")
        {
            if (playerHP >= maxHP)
            {
                playerHP = maxHP;
            }
            else
            {
                playerHP += 50;
                AidKitcount.text = (int.Parse(AidKitcount.text) - 1).ToString();
            }
            HPbar.value = playerHP;

        }
        if (gameObject.tag == "Medication")
        {
            if (playerHP >= maxHP)
            {
                playerHP = maxHP;
            }
            else
            {
                playerHP += 30;
                Medicationcount.text = (int.Parse(Medicationcount.text) - 1).ToString();
            }
            HPbar.value = playerHP;
        }
    }
        void GameOver()
        {
            Debug.Log("���� ����!");
            // ���⿡ ���� ���� ���¿� ���õ� ó���� �߰��� �� �ֽ��ϴ�.
        }
    
}