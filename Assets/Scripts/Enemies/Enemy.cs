using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _damage;
    public bool isAttack { get; private set; }

    public void TakeDamage(float amount)
    {
        _health.TakeDamage(amount);
    }
    private void Update()
    {
        if (FindClosestEnemy() != null)
        {
            if (Vector3.Distance(transform.position, FindClosestEnemy().transform.position) < 1f && FindClosestEnemy().CheckAlive())
            {
                isAttack = true;
            }
            else isAttack = false;
        }
        _animator.SetBool("Attack", isAttack);
    }
    private void OnDestroy()
    {
        ListEnemy.instance.RemoveEnemy(this);
    }

    public bool CheckAlive()
    {
        return _health.CheckAlive();
    }

    public Player FindClosestEnemy()
    {
        float closestDistance = Mathf.Infinity;
        var enemies = ListPlayer.instance.Players;
        Player closestEnemy = null;
        foreach (var enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < closestDistance)
            {
                closestDistance = distanceToEnemy;
                closestEnemy = enemy;
            }
        }

        return closestEnemy;
    }

    /// <summary>
    /// вызывается в анимаций как метод
    /// </summary>
    private void Attack()
    {
        FindClosestEnemy().TakeDamage(_damage);
    }
}
