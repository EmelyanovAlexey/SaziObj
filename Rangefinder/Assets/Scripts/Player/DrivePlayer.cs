using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrivePlayer : MonoBehaviour
{
    public Transform playerBody;
    private CharacterController controller;
    public float mouseSensitiviti = 200f;
    public float speed = 0.01f;

    private float xRotation = 0f;
    private float mouseX;
    private float mouseY;
    private float x;
    private float z;
    private bool mouseShow = false;

    void Start()
    {
        controller = playerBody.GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; // ����� ������� ������ �����
    }

    void Update()
    {
        // ����������� �������
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!mouseShow)
            {
                Cursor.lockState = CursorLockMode.Confined;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            mouseShow = !mouseShow;
        }
    }

    void FixedUpdate()
    {
        // mouseMove();
        playerMove();
    }

    // ���������� �����
    private void mouseMove()
    {
        // ����
        mouseX = Input.GetAxis("Mouse X") * mouseSensitiviti * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitiviti * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    // ���������� �������
    private void playerMove()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        controller.Move((transform.right * x + transform.forward * z) * speed * Time.deltaTime);
    }
}
