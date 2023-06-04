using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _meshAgent;
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
        if (CheckDistance()) ChangeTarget();
      //  _meshAgent.SetDestination(_target.position);
    }

    private bool CheckDistance()
    {
        return Vector3.Distance(_target.position, transform.position) < _distanceTarget;
    }
    private void ChangeTarget()
    {
        _target = PointManager.instance.Points[Random.Range(0, PointManager.instance.Points.Length - 1)];
    }
}
