using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics;
using UnityEngine;
using UnityEngine.AI;

public class MoveWithNavMeshBase : MonoBehaviour
{
    protected NavMeshAgent _agent;
    protected Transform _target;
    protected IDestinationSelector _settingDestinationStrategy;
    private void Awake()
    {
        if (_agent == null)
        {
            _agent = GetComponent<NavMeshAgent>();
        }
        _agent.stoppingDistance = 2.0f;
        _agent.autoBraking = true;
    }
    public void SetStrategy(in IDestinationSelector inStrategy)
    {
           _settingDestinationStrategy = inStrategy;
    }
    public void StartMoving()
    {
        _target = _settingDestinationStrategy.SelectDestination();
        if (_target != null )
        {
            _agent.SetDestination(_target.position);
        }
    }
}
