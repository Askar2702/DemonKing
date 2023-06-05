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
        touchStart = GetWorldPosition(Input.mousePosition);
    }

    private void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            touchStart = GetWorldPosition(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

          if (isDragging)
        {
            Vector3 direction = touchStart - GetWorldPosition(Input.mousePosition);
            direction.y = 0;
            transform.position += direction * Time.deltaTime * cameraSpeed;
        }
    }

    private Vector3 GetWorldPosition(Vector3 screenPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            return hit.point;
        }
        return Camera.main.transform.position;
    }

}




