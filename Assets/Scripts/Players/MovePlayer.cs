using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _meshAgent;
    [SerializeField] private Player _player;
    private Transform _target;
    private float _distanceTarget = 3;
    void Start()
    {
        _meshAgent = GetComponent<NavMeshAgent>();
        ChangeTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if (_target==null || CheckDistance()) ChangeTarget();
        if (!_player.isAttack)
        {
            if (_target != null)
            {
                _meshAgent.isStopped = false;
                _meshAgent.SetDestination(_target.position);
            }
            else _meshAgent.isStopped = true;
        }
        else _meshAgent.isStopped = true;
    }

    private bool CheckDistance()
    {
        return Vector3.Distance(_target.position, transform.position) < _distanceTarget;
    }
    private void ChangeTarget()
    {
        if (_player.FindClosestEnemy() != null)
        {
            _meshAgent.isStopped = false;
            _target = _player.FindClosestEnemy().transform;
        }
        else _meshAgent.isStopped = true;
        //  _target = PointManager.instance.Points[Random.Range(0, PointManager.instance.Points.Length - 1)];
    }
}
