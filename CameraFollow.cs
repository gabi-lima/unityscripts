using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float sensitivity = 2f; // Mouse sensitivity for rotation
    public float rotationSpeed = 5f; // Camera rotation speed
    public float minYAngle = -80f; // Minimum vertical rotation angle
    public float maxYAngle = 80f; // Maximum vertical rotation angle

    private CinemachineFreeLook freeLookCam; // Reference to the Cinemachine FreeLook component

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Start()
    {
        freeLookCam = GetComponent<CinemachineFreeLook>();
    }

    private void Update()
    {
        // Rotation horizontal
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        Vector3 bodyRotation = new Vector3(0f, mouseX, 0f);
        player.Rotate(bodyRotation);

        // Rotation vertical
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;
        freeLookCam.m_XAxis.Value -= mouseY * rotationSpeed * Time.deltaTime;
        freeLookCam.m_XAxis.Value = Mathf.Clamp(freeLookCam.m_XAxis.Value, minYAngle, maxYAngle);
    }

    private void LateUpdate()
    {
        // Make the camera follow the player
        transform.position = player.position;
    }
}
