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
            direction.y = 0; // ����� �������� �������� �ʵ��� y���� 0���� �����մϴ�.
            direction.Normalize(); // �̵� ������ ����ȭ�մϴ�.

            // ���� Ÿ�� �������� ȸ����ŵ�ϴ�.
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * zombieController.rotationSpeed);

            // ���� Ÿ�� �������� �̵���ŵ�ϴ�.
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
