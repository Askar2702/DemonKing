using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Health _health;

    public void TakeDamage(float amount)
    {
        _health.TakeDamage(amount);
    }

    private void OnDestroy()
    {
        ListEnemy.instance.RemoveEnemy(this);
    }
}
