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
    private bool escapeGateCreated = false;



    void Start()
    {
        // ���� ���� �� Hppanel, Lvpanel, Weaponpanel�� Ȱ��ȭ�մϴ�.
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

        // F1 Ű�� ������ ��
        if (Input.GetKeyDown(KeyCode.F1))
        {
            // �г��� Ȱ��ȭ�Ǿ� �ִٸ� ��Ȱ��ȭ�ϰ�, ��Ȱ��ȭ�Ǿ� �ִٸ� Ȱ��ȭ�մϴ�.
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
            LVbar.maxValue += 20; // LVbar�� �ִ� �� ����
        }
    }

    void CreateEscapeGate()
    {
        float randomX = Random.Range(-30f, 30f);
        float randomZ = Random.Range(-30f, 30f);
        Vector3 randomPosition = new Vector3(randomX, 0f, randomZ);
        Instantiate(escapeGatePrefab, randomPosition, Quaternion.identity);
    }

}
