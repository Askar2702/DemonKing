using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BaseUnit
{
  
    protected void Start()
    {
        ListPlayer.instance.AddPlayer(this);
    }
  

    protected void Update()
    {
        if (!CheckAlive()) return;
        Enemy enemy = FindClosestEnemy() as Enemy;
        if (enemy != null)
        {
            if (Vector3.Distance(transform.position, enemy.transform.position) < 1.5f && enemy.CheckAlive())
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
        if(enemy == null)
        {
            isAttack = false;
            _animator.SetBool("Move", false);
            _health.ShowHealthBar(false);
        }

        if (isAttack != _animator.GetBool("Attack"))
            _animator.SetBool("Attack", isAttack);
    }
    public override BaseUnit FindClosestEnemy()
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

  
   
}
