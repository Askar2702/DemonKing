using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasHealth : MonoBehaviour
{
    private Camera _cam;
    void Start()
    {
        _cam = Camera.main;
    }

    private void LateUpdate()
    {
        transform.LookAt(transform.position + _cam.transform.forward);
    }
}
