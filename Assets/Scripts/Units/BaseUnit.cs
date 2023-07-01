using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    public bool isAttack { get; protected set; }

    [SerializeField] protected Health _health;
    [SerializeField] protected Animator _animator;
    [SerializeField] protected float _damage;

    public void TakeDamage(float amount)
    {
        _health.TakeDamage(amount);
    }

    public void SetDamage(float amount)
    {
        _damage = amount;
    }

    public virtual BaseUnit FindClosestEnemy()
    {
        return null;
    }

    /// <summary>
    /// вызывается в анимаций как метод
    /// </summary>
    protected void Attack()
    {
        if (FindClosestEnemy())
            FindClosestEnemy().TakeDamage(_damage);
        else isAttack = false;
    }
}
