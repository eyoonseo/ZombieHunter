using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 100f;
    public Transform playerBody;
    float mouseX = 0f;
    float mouseY = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        mouseX += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        mouseX -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        mouseY = Mathf.Clamp(mouseX, -180f, 180f); // 상하 각도 제한

        transform.localRotation = Quaternion.Euler(mouseY, 0f, 0f);
        playerBody.rotation = Quaternion.Euler(0f, mouseX, 0f);


        //    float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        //    transform.localRotation = Quaternion.Euler(0f, mouseX, 0f);

        //float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        //xRotation -= mouseY;
        //xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        //playerBody.Rotate(Vector3.up * mouseX);
    }
}
