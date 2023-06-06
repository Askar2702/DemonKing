using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _meshAgent;
    [SerializeField] private Animator _animator;
    [SerializeField] private Enemy _enemy;
    private Transform _target;
    private float _distanceTarget = 3;
    public Vector3 _startPos;
    void Start()
    {
        _meshAgent = GetComponent<NavMeshAgent>();
        _startPos = transform.position;
       // ChangeTarget();
    }

    // Update is called once per frame
    void Update()
    {
        // if (CheckDistance()) ChangeTarget();
        if (_enemy.isAttack)
        {
            _animator.SetBool("Move", false);
            _meshAgent.isStopped = true;
            return;
        }
        if (_enemy.FindClosestEnemy() != null && CheckDistance() && _enemy.FindClosestEnemy().CheckAlive())
        {
            _meshAgent.isStopped = false;
            _animator.SetBool("Move", true);
            _meshAgent.SetDestination(_enemy.FindClosestEnemy().transform.position);
        }
        else if(_enemy.FindClosestEnemy() == null || _enemy.FindClosestEnemy() != null && _enemy.FindClosestEnemy().CheckAlive())
        {
            //if (Vector3.Distance(_startPos, transform.position) > 2f)
            //{
            //    _animator.SetBool("Move", true);
            //    print(Vector3.Distance(_startPos, transform.position));
            //    _meshAgent.SetDestination(_startPos);
            //}
            //else
            {
                _animator.SetBool("Move", false);
            }
        }
    }

    private bool CheckDistance()
    {
        return Vector3.Distance(_enemy.FindClosestEnemy().transform.position, transform.position) < _distanceTarget;
    }
    private void ChangeTarget()
    {
        _target = PointManager.instance.Points[Random.Range(0, PointManager.instance.Points.Length - 1)];
    }
}
