using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _damage;
   
    [field:SerializeField] public SkinnedMeshRenderer SkinnedMeshRenderer { get; private set; }
    public bool isAttack { get; private set; }

    public void TakeDamage(float amount)
    {
        _health.TakeDamage(amount);
    }
    private void Update()
    {
        if (!CheckAlive()) return;
        
        if (FindClosestEnemy() != null)
        {
            var target = FindClosestEnemy();
            if (Vector3.Distance(transform.position,target.transform.position) < 1f && target.CheckAlive())
            {
                isAttack = true;
            }
            else {
                isAttack = false;
                _health.ShowHealthBar(false);
            }
        }
        _animator.SetBool("Attack", isAttack);
    }
   

    public bool CheckAlive()
    {
        if (!_health.CheckAlive())
            ListEnemy.instance.RemoveEnemy(this);
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
