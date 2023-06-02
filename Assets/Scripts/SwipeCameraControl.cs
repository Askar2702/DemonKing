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

    // Update is called once per frame
    void Update()
    {
        // Check for input on both editor and Android
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

            // Update the initial mouse position to the current mouse position
            initialMousePosition = Input.mousePosition;

            // Move the camera based on the mouse movement
            Vector3 newPosition = transform.position;
            newPosition.x -= mouseDelta.x * cameraSpeed * Time.deltaTime;
            newPosition.z -= mouseDelta.y * cameraSpeed * Time.deltaTime;
            transform.position = newPosition;
        }
    }
}
