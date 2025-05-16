using UnityEngine;
using UnityEngine.AI;

public class ChaseClass : IDestinationSelector
{
    private readonly Transform _ownerTransform;

    public ChaseClass(in Transform inOwnerTransform)
    {
        _ownerTransform = inOwnerTransform;
    }

    private float CalculatePathCost(in NavMeshPath inPath)
    {
        float cost = 0f;

        if (inPath.corners.Length < 2)
        {
            return Mathf.Infinity;
        }

        for (int i = 1; i < inPath.corners.Length; i++)
        {
            cost += Vector3.Distance(inPath.corners[i - 1], inPath.corners[i]);
        }

        return cost;
    }

    public Transform SelectDestination()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        if (players == null || players.Length == 0)
        {
            return null;
        }

        NavMeshPath navMeshPath = new NavMeshPath();
        Transform bestTarget = null;
        float bestCost = Mathf.Infinity;

        foreach (GameObject playerObj in players)
        {
            Transform playerTransform = playerObj.transform;

            bool bPathCalculated = NavMesh.CalculatePath(_ownerTransform.position, playerTransform.position, NavMesh.AllAreas, navMeshPath);

            if (!bPathCalculated || navMeshPath.status != NavMeshPathStatus.PathComplete)
            {
                continue;
            }

            float cost = CalculatePathCost(navMeshPath);

            if (cost < bestCost)
            {
                bestCost = cost;
                bestTarget = playerTransform;
            }
        }

        return bestTarget;
    }
}
