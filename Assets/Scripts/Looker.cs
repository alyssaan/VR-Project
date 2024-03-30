using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Looker : MonoBehaviour
{
    // Connect your camera here in editor.
    private Camera _camera;

    public float mouseSensitivity = 800f;
    public Transform playerBody;
    float xRotation = 0f;

    void Start()
    {
        _camera = GetComponent<Camera>();

        // This method locks our cursor to the middle of the screen while in play mode.
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Handles turning the camera in respones to player mouse movements.
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
    }
}