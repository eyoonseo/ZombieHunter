using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMaker : MonoBehaviour
{
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
        Instantiate(ZombiePrefabs, transform.position, transform.rotation);
    }

    public void RandomCoolTime()
    {
        int rnd = Random.Range(15, 20); //int�� 15�̻� 20�̸�,float�� 15�̻� 20���� 
        coolTime = rnd;
    }

}

