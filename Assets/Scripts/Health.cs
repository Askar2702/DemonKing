using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _healthCount;
    [SerializeField] private Animator _animator;
    private void Awake()
    {
        _slider.maxValue = _healthCount;
        _slider.value = _healthCount;
    }
    public void TakeDamage(float amount)
    {
        ShowHealthBar(true);
        _healthCount -= amount;
        if (_healthCount <= 0)
        {
            ShowHealthBar(false);
            _healthCount = 0;
            _animator.SetTrigger("Death");
            StartCoroutine(DelayDeath());
        }
        _slider.value = _healthCount;
    }

    public void ShowHealthBar(bool a)
    {
        if (a == _slider.gameObject.activeSelf) return;
        _slider.gameObject.SetActive(a);
    }
    IEnumerator DelayDeath()
    {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }

    public bool CheckAlive()
    {
        return _healthCount > 0;
    }
}
