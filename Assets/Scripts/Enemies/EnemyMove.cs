using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _meshAgent;
    [SerializeField] private Animator _animator;
    [SerializeField] private Enemy _enemy;
    private float _distanceTarget = 3f;
    void Start()
    {
        _meshAgent = GetComponent<NavMeshAgent>();
       // ChangeTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_enemy.CheckAlive())
        {
            _meshAgent.enabled = false;
            return;
        }
        var target = _enemy.FindClosestEnemy();
        if (_enemy.isAttack)
        {
            _animator.SetBool("Move", false);
            _meshAgent.isStopped = true;
            return;
        }
        if (target != null && CheckDistance(_distanceTarget) && target.CheckAlive())
        {
            _meshAgent.isStopped = false;
            _animator.SetBool("Move", true);
            _meshAgent.SetDestination(target.transform.position);
        }
        else if(target == null)
        {
            _animator.SetBool("Move", false);
        }
    }

    private bool CheckDistance(float dist)
    {
        return Vector3.Distance(_enemy.FindClosestEnemy().transform.position, transform.position) < dist;
    }
   
}
