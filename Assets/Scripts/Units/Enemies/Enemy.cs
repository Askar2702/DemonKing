using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BaseUnit
{

    private float _rotationSpeed = 10f;


   
    private void Update()
    {
        if (!CheckAlive()) return;
        Player player = FindClosestEnemy() as Player;
        if (player != null)
        {
            if (Vector3.Distance(transform.position,player.transform.position) < 1.5f && player.CheckAlive())
            {
                isAttack = true;
                Vector3 targetDirection = player.transform.position - transform.position;
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
            }
            else {
                isAttack = false;
                _health.ShowHealthBar(false);
            }
        }
        else
        {
            isAttack = false;
            _health.ShowHealthBar(false);
        }

        if (isAttack != _animator.GetBool("Attack"))
            _animator.SetBool("Attack", isAttack);
    }
   

    public bool CheckAlive()
    {
        if (!_health.CheckAlive())
            ListEnemy.instance.RemoveEnemy(this);
        return _health.CheckAlive();
    }

    public override BaseUnit FindClosestEnemy()
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

   
}
