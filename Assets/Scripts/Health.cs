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
        _healthCount -= amount;
        if (_healthCount <= 0)
        {
            _healthCount = 0;
            _animator.SetTrigger("Death");
            StartCoroutine(DelayDeath());
        }
        _slider.value = _healthCount;
    }

    IEnumerator DelayDeath()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    public bool CheckAlive()
    {
        return _healthCount > 0;
    }
}
