#if false

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class AnimatorBase : MonoBehaviour
{
    public Animator animator;
    public float maxCost = 15f;
    private IMonsterStats _monsterStats;
    public void Start()
    {
        animator = GetComponent<Animator>();
        _monsterStats = GetComponent<IMonsterStats>();
    }
    public bool CanAttack()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        NavMeshPath path = new NavMeshPath();

        foreach (GameObject player in players)
        {
            if (NavMesh.CalculatePath(transform.position, player.transform.position, NavMesh.AllAreas, path))
            {
                float pathLength = GetPathLength(path);

                foreach (float range in _monsterStats.attackRange)
                {
                    if (pathLength <= range)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
    public bool IsAnyPlayerWithinCost()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        NavMeshPath path = new NavMeshPath();

        foreach (GameObject player in players)
        {
            if (NavMesh.CalculatePath(transform.position, player.transform.position, NavMesh.AllAreas, path))
            {
                float pathLength = GetPathLength(path);

                if (pathLength <= maxCost)
                {
                    return true;
                }
            }
        }
        return false;
    }

    private float GetPathLength(NavMeshPath path)
    {
        float length = 0f;
        if (path.corners.Length < 2)
        {
            return length;
        }
        for (int i = 1; i < path.corners.Length; i++)
        {
            length += Vector3.Distance(path.corners[i - 1], path.corners[i]);
        }
        return length;
    }
    

    private void FixedUpdate()
    {
        if (CanAttack() == true)
        {
            animator.SetBool("ToAttack", true);
        }
        else if (IsAnyPlayerWithinCost() == true && CanAttack()==false)
        {
            animator.SetBool("ToAttack", false);
            animator.SetBool("ToSeek", false);
        }
        else
        {
            animator.SetBool("ToAttack", false);
            animator.SetBool("ToSeek", true);
        }

    }
}


#endif