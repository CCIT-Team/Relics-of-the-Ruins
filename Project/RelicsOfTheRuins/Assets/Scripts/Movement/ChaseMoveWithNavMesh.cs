using System.Collections;
using System.Collections.Generic;
using OpenCover.Framework.Model;
using UnityEngine;
using UnityEngine.AI;

public class ChaseMoveWithNavMesh : MoveWithNavMeshBase
{
    private void Start()
    {
        IDestinationSelector strategy = new ChaseClass(transform);
        SetStrategy(strategy);
    }

    private void FixedUpdate()
    {
        StartMoving();
    }
}

