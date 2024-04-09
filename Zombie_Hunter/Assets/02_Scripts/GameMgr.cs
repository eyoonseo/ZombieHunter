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
    public GameObject Timepanel;
    public GameObject Hppanel;
    public GameObject Lvpanel;
    public GameObject Weaponpanel;

    public Slider HPbar;
    public Slider LVbar;
    public Slider Virusbar;

    public Text Timetxt;
    public float curTime;
    public Text Day;
    public Text LV;

    private int curHour = 0;
    private int daysPassed = 0;


    void Start()
    {
        // 게임 시작 시 Hppanel, Lvpanel, Weaponpanel을 활성화합니다.
        Hppanel.SetActive(true);
        Lvpanel.SetActive(true);
        Weaponpanel.SetActive(true);
        Timepanel.SetActive(true);
        Windowpanel.SetActive(true);

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

        curTime += Time.deltaTime;
        if (curTime >= 60)
        {
            curTime -= 60;
            curHour += 1;
            if (curHour >= 24)
            {
                curHour -= 24;
                daysPassed += 1;
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

}
