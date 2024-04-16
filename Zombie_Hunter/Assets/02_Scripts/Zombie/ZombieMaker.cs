using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMaker : MonoBehaviour
{
    public Transform zombieSpot;
    public GameObject ZombiePrefabs;

    public float curTime = 0;
    public float coolTime = 2f;

    void Start()
    {
        RandomCoolTime();
    }

    void Update()
    {
        curTime += Time.deltaTime;
        if (curTime > coolTime)
        {
            curTime = 0;
            MakeZombie();
        }
    }

    void MakeZombie()
    {
        Instantiate(ZombiePrefabs, zombieSpot.transform.position, zombieSpot.transform.rotation);
    }

    public void RandomCoolTime()
    {
        int rnd = Random.Range(20, 25); //int는 15이상 20미만,float은 15이상 20이하 
        coolTime = rnd;
    }

}

