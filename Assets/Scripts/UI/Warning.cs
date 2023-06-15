using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class Warning : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private CanvasGroup _child;
    public void Init()
    {
        _child.DOFade(1, _speed).OnComplete(()=> 
        {
            _child.DOFade(0, _speed * 5);
        });
    }
}
