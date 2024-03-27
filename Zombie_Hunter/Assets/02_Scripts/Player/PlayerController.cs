using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    public float moveSpeed = 10f;
    private float xlimit = 249;
    private float zlimit = 249;

  

    void Update()
    {        
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            // shift 키가 눌렸을 때 moveSpeed를 절반으로 줄임
            transform.Translate((moveSpeed / 2f) * h * Time.deltaTime, 0, (moveSpeed / 2f) * v * Time.deltaTime);

            if (transform.position.x < -xlimit )
            {
                transform.position = new Vector3(-xlimit, 0, transform.position.z);
            }
            if (transform.position.x > xlimit)
            {
                transform.position = new Vector3(xlimit, 0, transform.position.z);
            }
            if (transform.position.z < -zlimit)
            {
                transform.position = new Vector3(transform.position.x, 0, -zlimit);
            }
            if (transform.position.z > zlimit)
            {
                transform.position = new Vector3(transform.position.x, 0, zlimit);
            }

        }
        else
        {
            transform.Translate(moveSpeed * h * Time.deltaTime, 0, moveSpeed * v * Time.deltaTime);

            if (transform.position.x < -xlimit)
            {
                transform.position = new Vector3(-xlimit, 0, transform.position.z);
            }
            if (transform.position.x > xlimit)
            {
                transform.position = new Vector3(xlimit, 0, transform.position.z);
            }
            if (transform.position.z < -zlimit)
            {
                transform.position = new Vector3(transform.position.x, 0, -zlimit);
            }
            if (transform.position.z > zlimit)
            {
                transform.position = new Vector3(transform.position.x, 0, zlimit);
            }
        }

    }
 
}

