using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
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
        if (zombieController.target != null )
        {
            Vector3 direction = zombieController.target.position - transform.position;
            direction.y = 0; // 좀비는 수직으로 움직이지 않도록 y값을 0으로 설정합니다.
            direction.Normalize(); // 이동 방향을 정규화합니다.

            // 좀비를 타겟 방향으로 회전시킵니다.
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * zombieController.rotationSpeed);

            // 좀비를 타겟 방향으로 이동시킵니다.
            transform.Translate(Vector3.forward * zombieController.moveSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            zombieController.zombieAnim.speed *= 2.5f;
            zombieController.target = other.transform;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            zombieController.zombieAnim.speed = originspeed;
        }
    }
}
