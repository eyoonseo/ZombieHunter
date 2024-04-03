using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    public Text Time;
    public Text Day;
    public Text LV;

    void Start()
    {
        // 게임 시작 시 Hppanel, Lvpanel, Weaponpanel을 활성화합니다.
        Hppanel.SetActive(true);
        Lvpanel.SetActive(true);
        Weaponpanel.SetActive(true);
        Timepanel.SetActive(true);
        Windowpanel.SetActive(true);
    }

    void Update()
    {
        // F1 키를 눌렀을 때
        if (Input.GetKeyDown(KeyCode.F1))
        {
            // 패널이 활성화되어 있다면 비활성화하고, 비활성화되어 있다면 활성화합니다.
            Windowpanel.SetActive(!Windowpanel.activeSelf);
        }


    }

    void LVup()
    {
        if (LVbar.value >= 100f)
        {
            int currentLV = int.Parse(LV.text);
            currentLV++;
            LV.text = currentLV.ToString();

            LVbar.value = 0f;
            LVbar.maxValue += 20;
        }
    }
}
