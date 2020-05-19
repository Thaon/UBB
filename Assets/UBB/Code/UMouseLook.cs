using System;
using UnityEngine;
//from: https://answers.unity.com/questions/29741/mouse-look-script.html


public class UMouseLook : MonoBehaviour
{
    public bool m_hideCursor = true;
    [Range(1, 1000)]
    public float m_mouseSensitivity = 100.0f;
    [Range(0, 90)]
    public float m_clampAngle = 80.0f;

    private float m_rotY = 0.0f; // rotation around the up/y axis
    private float m_rotX = 0.0f; // rotation around the right/x axis

    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        m_rotY = rot.y;
        m_rotX = rot.x;
        SetCursorVisibility(!m_hideCursor);
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        m_rotY += mouseX * m_mouseSensitivity * Time.deltaTime;
        m_rotX += mouseY * m_mouseSensitivity * Time.deltaTime;

        m_rotX = Mathf.Clamp(m_rotX, -m_clampAngle, m_clampAngle);

        Quaternion localRotation = Quaternion.Euler(m_rotX, m_rotY, 0.0f);
        transform.rotation = localRotation;
    }

    public void SetCursorVisibility(bool vis)
    {
        Cursor.lockState = vis ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = vis;
    }
}