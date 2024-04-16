using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SCENE : MonoBehaviour
{
    public void OnGameButtonClick1()
    {
        SceneManager.LoadScene(0); // 1번 씬으로 이동
    }

    public void OnGameButtonClick2()
    {
        SceneManager.LoadScene(2); // 1번 씬으로 이동
    }
    public void OnGameButtonClick3()
    {
        SceneManager.LoadScene(3); // 1번 씬으로 이동
    }
    public void OnGameButtonClick4()
    {
        SceneManager.LoadScene(1); // 1번 씬으로 이동
    }
    public void STARTGAME()
    {
        SceneManager.LoadScene(4); // 1번 씬으로 이동
    }
}
