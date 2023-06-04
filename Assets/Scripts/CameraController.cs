using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraSpeed = 2.0f;

    private Vector3 touchStart;
    private bool isDragging = false;
    private void Start()
    {
        touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

     //   if (isDragging)
        {
            Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction.y = 0;
           transform.position += direction * cameraSpeed * Time.deltaTime;

        }
    }
}




