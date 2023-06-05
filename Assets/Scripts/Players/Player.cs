using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Animator _animator;
    public bool isAttack;
   
    public void TakeDamage(float amount)
    {
        _health.TakeDamage(amount);
    }

    private void Update()
    {
        if (FindClosestEnemy() != null)
        {
            if (Vector3.Distance(transform.position, FindClosestEnemy().transform.position) < 1f)
            {
                isAttack = true;
            }
            else isAttack = false;
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
}
