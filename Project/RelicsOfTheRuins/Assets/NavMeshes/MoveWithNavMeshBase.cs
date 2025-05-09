using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveWithNavMeshBase : MonoBehaviour
{
    protected NavMeshAgent _agent;
    protected Transform _target;
    protected IDestinationSelector _settingDestinationStrategy;
    public void SetStrategy(IDestinationSelector strategy)
    {
           _settingDestinationStrategy = strategy;
    }
    public void StartMoving()
    {
        _target = _settingDestinationStrategy.SelectDestination();
        if (_target != null )
        {
            if(_agent == null)
            {
                _agent=GetComponent<NavMeshAgent>();
            }
            _agent.SetDestination(_target.position);
        }
    }
}
