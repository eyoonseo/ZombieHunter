using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class GameMgr : MonoBehaviour
{
    public GameObject Windowpanel;
    public GameObject Bagpanel;
    public GameObject ESCpanel;
    public GameObject Optionpanel;
    public GameObject Optionscroll;
    public GameObject controllimage;
    public GameObject EXITpanel;
    public GameObject Timepanel;
    public GameObject Hppanel;
    public GameObject Lvpanel;
    public GameObject Weaponpanel;
    public GameObject escapeGatePrefab;

    public Slider HPbar;
    public Slider LVbar;
    public Slider Virusbar;

    public Text Timetxt;
    public float curTime;
    public Text Day;
    public Text LV;


    private int curHour = 0;
    private int daysPassed = 0;
    private bool escapeGateCreated;

    void Start()
    {
        // 게임 시작 시 Hppanel, Lvpanel, Weaponpanel을 활성화합니다.
        Hppanel.SetActive(true);
        Lvpanel.SetActive(true);
        Weaponpanel.SetActive(true);
        Timepanel.SetActive(true);
        Windowpanel.SetActive(true);
        escapeGateCreated = false;

        curHour = 0;
        daysPassed = 1;
        LV.text = "LV." + "1";
        
    }

    void Update()
    {

        // F1 키를 눌렀을 때
        if (Input.GetKeyDown(KeyCode.F1))
        {
            // 패널이 활성화되어 있다면 비활성화하고, 비활성화되어 있다면 활성화합니다.
            Windowpanel.SetActive(!Windowpanel.activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            // 패널이 활성화되어 있다면 비활성화하고, 비활성화되어 있다면 활성화합니다.
            Bagpanel.SetActive(!Bagpanel.activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // 패널이 활성화되어 있다면 비활성화하고, 비활성화되어 있다면 활성화합니다.
            TogglePause();

        }
       



        curTime += Time.deltaTime;
        if (curTime >= 60)
        {
            curTime -= 60;
            curHour += 1;
            if (curHour >= 24)
            {
                curHour -= 24;
                daysPassed += 1;

                if (daysPassed == 7)
                {
                    CreateEscapeGate();
                    escapeGateCreated = true;
                }
                else
                {
                    escapeGateCreated = false;
                }
            }

        }

        Timetxt.text =  curHour + ":"  + (int)curTime;
        Day.text = "Day "+ daysPassed;

        if (LVbar.value >= LVbar.maxValue)
        {
            int currentLV = int.Parse(LV.text);
            currentLV++;
            LV.text = "LV." + currentLV.ToString();

            LVbar.value = 0f;
            LVbar.maxValue += 20; // LVbar의 최대 값 증가
        }
    }
    void TogglePause()
    {
        if (ESCpanel.activeSelf) // ESC 패널이 활성화되어 있는 경우
        {
            ESCpanel.SetActive(false); // ESC 패널을 비활성화
            Time.timeScale = 1f; // 게임 시간을 다시 진행
        }
        else // ESC 패널이 비활성화되어 있는 경우
        {
            ESCpanel.SetActive(true); // ESC 패널을 활성화
            Time.timeScale = 0f; // 게임 시간을 정지
        }
    }
    public void OnMainButtonClick()
    {
        ESCpanel.SetActive(false);// ESC 패널 비활성화
        EXITpanel.SetActive(true); // Exit 패널 활성화
    }
    public void  BacktoESCpanel()
    {
        ESCpanel.SetActive(true);// ESC 패널 비활성화
        EXITpanel.SetActive(false); // Exit 패널 활성화
    }
    public void Option()
    {
        ESCpanel.SetActive (false);
        Optionpanel.SetActive(true);
    }

    public void BacktoOption()
    {
        controllimage.SetActive(false);
        Optionscroll.SetActive(true);
    }
    public void ControllImage()
    {
        controllimage.SetActive(true);
        Optionscroll.SetActive(false);
    }
    public void BacktoESC()
    {
        Optionpanel.SetActive(false);
        ESCpanel.SetActive(true);
    }
    public void BacktoGame()
    {
        ESCpanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void ReturnToStartScene()
    {
        SceneManager.LoadScene("01_Start"); // "StartScene"은 첫 시작 화면의 씬 이름입니다. 적절히 변경해야 합니다.
    }

    void CreateEscapeGate()
    {
        float randomX = Random.Range(-30f, 30f);
        float randomZ = Random.Range(-30f, 30f);
        Vector3 randomPosition = new Vector3(randomX, 0f, randomZ);
        Instantiate(escapeGatePrefab, randomPosition, Quaternion.identity);
    }

}
