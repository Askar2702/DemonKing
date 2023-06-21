using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _cameraSpeed = 2.0f;
    [SerializeField] private float _minZ;
    [SerializeField] private float _maxZ;
    [SerializeField] private float _minX;
    [SerializeField] private float _maxX;

    private Vector3 touchStart;
    private bool isDragging = false;

    private void Start()
    {
        touchStart = GetWorldPosition(Input.mousePosition);
    }

    private void LateUpdate()
    {
        if (Input.touchCount > 1) return;
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
            transform.position += direction * Time.deltaTime * _cameraSpeed;
            Vector3 pos = new Vector3(Mathf.Clamp(transform.position.x, _minX, _maxX), transform.position.y,
                Mathf.Clamp(transform.position.z, _minZ, _maxZ));
            transform.position = pos;
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




