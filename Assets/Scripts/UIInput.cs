using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UIInput : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public static UIInput instance { get; private set; }
    public UnityEvent<Vector3> BeginPos = new UnityEvent<Vector3>();
    public UnityEvent<Vector3> DragPos = new UnityEvent<Vector3>();
    public UnityEvent<Vector3> EndPos = new UnityEvent<Vector3>();
    private void Awake()
    {
        if (!instance) instance = this;
    }
    public void OnDrag(PointerEventData eventData)
    {
        DragPos?.Invoke(eventData.position);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        BeginPos?.Invoke(eventData.position);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        EndPos?.Invoke(eventData.position);
    }
}
