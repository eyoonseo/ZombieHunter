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
        // ���� ���� �� Hppanel, Lvpanel, Weaponpanel�� Ȱ��ȭ�մϴ�.
        Hppanel.SetActive(true);
        Lvpanel.SetActive(true);
        Weaponpanel.SetActive(true);
        Timepanel.SetActive(true);
        Windowpanel.SetActive(true);
    }

    void Update()
    {
        // F1 Ű�� ������ ��
        if (Input.GetKeyDown(KeyCode.F1))
        {
            // �г��� Ȱ��ȭ�Ǿ� �ִٸ� ��Ȱ��ȭ�ϰ�, ��Ȱ��ȭ�Ǿ� �ִٸ� Ȱ��ȭ�մϴ�.
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
