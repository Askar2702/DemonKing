using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _damage;
    public bool isAttack { get; private set; }
    private void Start()
    {
        ListPlayer.instance.AddPlayer(this);
    }
    public void TakeDamage(float amount)
    {
        _health.TakeDamage(amount);
    }

    private void Update()
    {
        if (!CheckAlive()) return;
        if (FindClosestEnemy() != null)
        {
            if (Vector3.Distance(transform.position, FindClosestEnemy().transform.position) < 1f && FindClosestEnemy().CheckAlive())
            {
                isAttack = true;
                _animator.SetBool("Move", false);
            }
            else {
                isAttack = false;
                _animator.SetBool("Move", true);
                _health.ShowHealthBar(false);
            }
        }
        if(FindClosestEnemy() == null)
        {
            isAttack = false;
            _animator.SetBool("Move", false);
            _health.ShowHealthBar(false);
        }
       
        _animator.SetBool("Attack", isAttack);
    }
    public Enemy FindClosestEnemy()
    {
        float closestDistance = Mathf.Infinity;
        var enemies = ListEnemy.instance.Enemies;
        Enemy closestEnemy = null;
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

    public bool CheckAlive()
    {
        if (!_health.CheckAlive()) ListPlayer.instance.RemovePlayer(this);
        return _health.CheckAlive();
    }

    /// <summary>
    /// вызывается в анимаций как метод
    /// </summary>
    private void Attack()
    {
        if (FindClosestEnemy())
            FindClosestEnemy().TakeDamage(_damage);
        else isAttack = false;
    }

   
}
