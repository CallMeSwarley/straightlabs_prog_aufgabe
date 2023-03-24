using System;
using UnityEngine;


public class CameraRotation : MonoBehaviour
{

    [SerializeField] private float rotationSpeed = 3f;
    [Range(0, 90)] [SerializeField] private float maxRotationAngleX = 80f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private float rotationX = 0f;

    private void Update()
    {
        // Get the mouse input
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

        // Rotate the camera horizontally
        transform.Rotate(Vector3.up, mouseX);

        // Calculate the new rotation angle for the camera vertically
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -maxRotationAngleX, maxRotationAngleX);

        // Apply the new rotation to the camera
        transform.localEulerAngles = new Vector3(rotationX, transform.localEulerAngles.y, 0);
    }
}
