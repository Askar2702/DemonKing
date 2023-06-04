using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeCameraControl : MonoBehaviour
{
    // Camera movement speed
    public float cameraSpeed = 2f;

    // Check if camera movement is enabled
    private bool isCameraMoving = false;

    // Initial position of the mouse on the screen
    private Vector3 initialMousePosition;
    private Camera _cam;
    // Update is called once per frame

    private void Awake()
    {
        _cam = Camera.main;
    }
    void LateUpdate()
    {
        ComputerInput();
    }

   

    private void ComputerInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isCameraMoving = true;
            initialMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isCameraMoving = false;
        }

        // Move the camera if the movement is enabled
        if (isCameraMoving)
        {
            // Calculate the distance moved by the mouse
            Vector3 mouseDelta = Input.mousePosition - initialMousePosition;
            if (mouseDelta.magnitude < 5) return;
            // Update the initial mouse position to the current mouse position
            initialMousePosition = Input.mousePosition;

            // Get the camera's forward direction
            Vector3 cameraForward = _cam.transform.forward;
            cameraForward.y = 0f;
            cameraForward.Normalize();

            // Get the camera's right direction
            Vector3 cameraRight = _cam.transform.right;
            cameraRight.y = 0f;
            cameraRight.Normalize();

            // Calculate the desired movement direction based on mouse input and camera orientation
            Vector3 movementDirection = cameraRight * -mouseDelta.x + cameraForward * -mouseDelta.y;

            // Normalize the movement direction to ensure consistent speed
            movementDirection.Normalize();

            // Move the camera based on the movement direction and camera speed
            transform.position += movementDirection * cameraSpeed * Time.deltaTime;
        }
    }
}
