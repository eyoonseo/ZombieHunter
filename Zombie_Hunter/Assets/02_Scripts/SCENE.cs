using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SCENE : MonoBehaviour
{
    public void OnGameButtonClick1()
    {
        SceneManager.LoadScene(0); // 1�� ������ �̵�
    }

    public void OnGameButtonClick2()
    {
        SceneManager.LoadScene(2); // 1�� ������ �̵�
    }
    public void OnGameButtonClick3()
    {
        SceneManager.LoadScene(3); // 1�� ������ �̵�
    }
    public void OnGameButtonClick4()
    {
        SceneManager.LoadScene(1); // 1�� ������ �̵�
    }
    public void STARTGAME()
    {
        SceneManager.LoadScene(4); // 1�� ������ �̵�
    }
}
