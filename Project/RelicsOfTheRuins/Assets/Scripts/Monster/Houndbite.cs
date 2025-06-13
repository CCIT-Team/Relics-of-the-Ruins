using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HoundBite : MonoBehaviour
{
    protected ChaseClass _chaseClass;
    protected IMonsterStats _monsterStats;
    protected void Start()
    {
        _monsterStats = GetComponent<IMonsterStats>();
        _chaseClass = new ChaseClass(transform);
    }
    public void AttackHound1()
    {
        Transform targetTransform = _chaseClass.SelectDestination();
        GameObject targetObject = targetTransform.gameObject;
        PlayerHpBase damage = targetObject.GetComponent<PlayerHpBase>();
        if (Vector3.Distance(this.transform.position, targetObject.transform.position) <= 2.5f)
        {

            damage.TakeDamage(10.0f);
            return;
        }

    }
    /* 나중에 상태머신 뜯어고쳐서 수정 예정
    public void AttackHound2()
    {
        Transform targetTransform = _chaseClass.SelectDestination();
        GameObject targetObject = targetTransform.gameObject;
        PlayerHpBase damage = targetObject.GetComponent<PlayerHpBase>();
        if (Vector3.Distance(this.transform.position, targetObject.transform.position) <=4.0f && 3.0f<=Vector3.Distance(this.transform.position, targetObject.transform.position))
        {
            damage.TakeDamage(15.0f);
            Debug.Log($"몬스터가 플레이어에게 {_monsterStats.curStrength * 1} 데미지를 입힘!");
            return;
        }

    }*/
}
