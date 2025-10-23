using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class HoundBite : MonoBehaviour
{
    private Rigidbody _rb;
    private GameObject _currentTarget;
    private Vector3 _startPos;
    public bool _bIsDashing = false;
    private float _maxDashDistance = 8f;
    private Rigidbody _targetRb;
    protected IMonsterStats _monsterStats;
    protected void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _monsterStats = GetComponent<IMonsterStats>();
    }
    public void AttackHound1(in PlayerHpBase inDamage)
    {

        inDamage.TakeDamage(_monsterStats.curStrength * 1);
#if UNITY_EDITOR
        Debug.Log("예이1");
#endif
    }

    public void AttackHound2(in GameObject inTarget)
    {
        _startPos = this.transform.position;
        _currentTarget = inTarget;
        Vector3 direction = (inTarget.transform.position - this.transform.position).normalized;
        float distance = Vector3.Distance(this.transform.position, inTarget.transform.position);
        float force = distance * 1.5f;
        _rb.AddForce(direction * force, ForceMode.Impulse);
        _bIsDashing = true;
    }
    private void OnCollisionStay(Collision collision)
    {
        if (_currentTarget == null)
        {
            return;
        }
        if (collision.gameObject == _currentTarget)
        {
            _bIsDashing = false;
            PlayerHpBase damage = _currentTarget.GetComponent<PlayerHpBase>();
            damage.TakeDamage(_monsterStats.curStrength * 1.5f);
            Debug.Log("예이2");
            _rb.velocity = Vector3.zero;
            Vector3 direction = _currentTarget.transform.position - this.transform.position;
            direction.y = 0f;
            direction.Normalize();
            Vector3 knockbackVelocity = direction * (1f / 0.2f);
            _targetRb = _currentTarget.GetComponent<Rigidbody>();
            _targetRb.velocity = knockbackVelocity;
            StartCoroutine(StopKnockbackAfterTime(0.2f));
            _currentTarget = null;
        }
    }
    private System.Collections.IEnumerator StopKnockbackAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        if (_targetRb != null)
        {
            _targetRb.velocity = Vector3.zero;
            _targetRb = null;
        }

    }
    private void FixedUpdate()
    {
        if (_bIsDashing == false) return;

        if (Vector3.Distance(_startPos, this.transform.position) >= _maxDashDistance)
        {
            _rb.velocity = Vector3.zero;
            _currentTarget = null;
            _bIsDashing = false;
        }
    }

}
