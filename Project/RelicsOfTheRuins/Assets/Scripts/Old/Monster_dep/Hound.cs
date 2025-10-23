// using System.Collections;
// using System.Collections.Generic;
// using System.Net;
// using System.Threading;
// using OpenCover.Framework.Model;
// using Unity.Services.Analytics;
// using Unity.VisualScripting;
// using UnityEditor;
// using UnityEditor.Experimental.GraphView;
// using UnityEngine;
// using UnityEngine.AI;
// using UnityEngine.Playables;

// public class Hound : MoveWithNavMeshBase
// {
//     public Animator animator;
//     private Rigidbody _rb;
//     protected HoundBite _attackStrategy;
//     protected float[] _attackDelay= { 1.5f, 2.0f };
//     protected float[] _attackTimer = { 0f, 0f };
//     protected ChaseClass _chaseClass;
//     protected IMonsterStats _monsterStats;
//     private void Start()
//     {
//         animator = GetComponent<Animator>();
//         _rb = GetComponent<Rigidbody>();
//         _attackStrategy = GetComponent<HoundBite>();
//         _chaseClass = new ChaseClass(transform);
//         _monsterStats = GetComponent<IMonsterStats>();
//     }
//     private void Update()
//     {
//         AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
//         if (stateInfo.IsName("Idle"))
//         {
//             // ��� ����
//         }
//         else if (stateInfo.IsName("Attack"))
//         {
//             Transform targetTransform = _chaseClass.SelectDestination();
//             GameObject targetObject = targetTransform.gameObject;
//             PlayerHpBase damage = targetObject.GetComponent<PlayerHpBase>();
//             if (_attackTimer[0] > 0)
//             {
//                 _attackTimer[0] -= Time.deltaTime;
//             }
//             if (_attackTimer[1] > 0)
//             {
//                 _attackTimer[1] -= Time.deltaTime;
//             }
//             if (_attackTimer[1] <= 0)
//             {
//                 if (Vector3.Distance(this.transform.position, targetObject.transform.position) >= _monsterStats.attackRange[1] && Vector3.Distance(this.transform.position, targetObject.transform.position) <= _monsterStats.attackRange[2])
//                 {
//                     _rb.velocity = Vector3.zero;
//                     _agent.isStopped = true;
//                     _agent.ResetPath();
//                     _attackTimer[1] = _attackDelay[1];
//                     AttackUpdate2(targetObject);
//                 }
//             }
//             if (_attackTimer[0] <= 0)
//             {
//                 if (_attackStrategy._bIsDashing == false && Vector3.Distance(this.transform.position, targetObject.transform.position) <= _monsterStats.attackRange[0])
//                 {
//                     _rb.velocity = Vector3.zero;
//                     _agent.isStopped = true;
//                     _agent.ResetPath();
//                     _attackTimer[0] = _attackDelay[0];
//                     AttackUpdate1(damage);
//                 }
//             }
//             if (_attackStrategy._bIsDashing==false && Vector3.Distance(this.transform.position, targetObject.transform.position) >= _monsterStats.attackRange[0] && Vector3.Distance(this.transform.position, targetObject.transform.position) <= _monsterStats.attackRange[1])
//             {
//                 if (_agent.isStopped == true)
//                 {
//                     _agent.isStopped = false;
//                 }
//                 _rb.velocity = Vector3.zero;
//                 IDestinationSelector strategy = new ChaseClass(transform);
//                 SetStrategy(strategy);
//                 StartMoving();
//             }
//         }
//         else if (stateInfo.IsName("Chase"))
//         {
//             if (_agent.isStopped == true)
//             {
//                 //_agent.enabled = true;
//                 _agent.isStopped = false;
//             }
//             ChaseUpdate();
//         }
//         else if (stateInfo.IsName("Seek"))
//         {
//             if (_agent.isStopped == true)
//             {
//                 //_agent.enabled = true;
//                 _agent.isStopped = false;
//             }
//             SeekUpdate();
//         }
        

//     }

//     private void IdleUpdate()
//     {
//         // ������ �� �ൿ
//     }

//     private void SeekUpdate()
//     {
//         IDestinationSelector strategy = new PatrolClass(transform);
//         SetStrategy(strategy);
//         StartMoving();

//     }
//     private void ChaseUpdate()
//     {
//         IDestinationSelector strategy = new ChaseClass(transform);
//         SetStrategy(strategy);
//         StartMoving();
//     }
//     private void AttackUpdate1(PlayerHpBase damage)
//     { 
//         _attackStrategy.AttackHound1(damage);
//     }
//     private void AttackUpdate2(GameObject targetObject)
//     {

//         _attackStrategy.AttackHound2(targetObject);
//     }
// }
