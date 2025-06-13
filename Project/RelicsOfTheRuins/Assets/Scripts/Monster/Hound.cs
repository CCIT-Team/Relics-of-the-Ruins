using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using OpenCover.Framework.Model;
using Unity.Services.Analytics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Playables;

public class Hound : MoveWithNavMeshBase
{
    public Animator animator;
    private Rigidbody _rb;
    protected HoundBite _attackStrategy;
    protected float _attackDelay=2.5f;
    protected float _attackTimer = 0f;
    private void Start()
    {
        animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
        _attackStrategy = GetComponent<HoundBite>();
    }
    private void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("Idle"))
        {
            // 대기 상태
        }
        else if (stateInfo.IsName("Attack"))
        {
            if (_attackTimer > 0)
            {
                _attackTimer -= Time.deltaTime;
            }
            if (_attackTimer <= 0)
            {
                _attackTimer = _attackDelay;
                if (_agent.enabled == true)
                {
                    _agent.isStopped = true;
                    _agent.ResetPath();
                    _rb.velocity = Vector3.zero;
                    _rb.angularVelocity = Vector3.zero;
                    _agent.enabled = false;
                }
                AttackUpdate();
            }


        }
        else if (stateInfo.IsName("Chase"))
        {
            if (_agent.enabled == false)
            {
                _agent.enabled = true;
                _agent.isStopped = false;
            }
            ChaseUpdate();
        }
        else if (stateInfo.IsName("Seek"))
        {
            if (_agent.enabled == false)
            {
                _agent.enabled = true;
                _agent.isStopped = false;
            }
            SeekUpdate();
        }
        

    }

    private void IdleUpdate()
    {
        // 서있을 때 행동
    }

    private void SeekUpdate()
    {
        IDestinationSelector strategy = new PatrolClass(transform);
        SetStrategy(strategy);
        StartMoving();

    }
    private void ChaseUpdate()
    {
        IDestinationSelector strategy = new ChaseClass(transform);
        SetStrategy(strategy);
        StartMoving();
    }
    private void AttackUpdate()
    {
        _attackStrategy.AttackHound1();
    }
}
