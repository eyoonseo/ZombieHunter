using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    public ZombieController zombieController;
    public float originspeed;

    void Start()
    {
        zombieController = transform.parent.GetComponent<ZombieController>();
        originspeed = zombieController.zombieAnim.speed;
    }

   
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            zombieController.zombieAnim.speed = originspeed;
            zombieController.zombieAnim.SetBool("ATTACK", true);

        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            zombieController.zombieAnim.SetBool("ATTACK", false);
        }

    }
}
