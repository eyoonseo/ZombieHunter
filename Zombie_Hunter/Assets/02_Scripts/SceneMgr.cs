using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMgr : MonoBehaviour
{

    public GameObject OPTIONpanel;
    public GameObject controllimage;
    public GameObject scrollview;

    public void OnGameButtonClick1()
    {
        SceneManager.LoadScene(1); 
    }

    public void OPTION()
    {
        OPTIONpanel.SetActive(true);
    }

    public void CONTROLLIMG()
    {
        scrollview.SetActive(false);
        controllimage.SetActive(true);
    }
    public void BACKTOOPTION()
    {
        scrollview.SetActive(true);
        controllimage.SetActive(false);
    }

    public void OnExitButtonClick()
    {
        Application.Quit(); // 게임 종료
    }
    public void BACKTOFIRST()
    {
        OPTIONpanel.SetActive(false);
    }
}
