using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.UI.Image;
public class PatrolClass : IDestinationSelector
{
    private Transform _tempDestination;
    private float _radius;
    private Transform _ownerTransform;

    public PatrolClass(Transform origin, float radius = 30f)
    {
        this._ownerTransform = origin;
        this._radius = radius;
        if (GameObject.Find("TempDestination") == null)
        {
            GameObject tempGO = new GameObject("TempDestination");
            _tempDestination = tempGO.transform;
            //Destroy(tempGO, 3);
            Object.Destroy(tempGO, 3);
            
        }
    }

    public Transform SelectDestination()
    {
        Vector3 randomDir;
        float minDistance = 30f;

        int maxTries = 10;
        int tries = 0;

        do
        {
            randomDir = Random.insideUnitSphere * _radius + _ownerTransform.position;
            //randomDir.y = _ownerTransform.position.y; // 높이 고정
            tries++;
        }
        while (Vector3.Distance(_ownerTransform.position, randomDir) < minDistance && tries < maxTries);

        if (NavMesh.SamplePosition(randomDir, out NavMeshHit hit, _radius, NavMesh.AllAreas)&&_tempDestination!=null)
        {
            _tempDestination.position = hit.position;
            return _tempDestination;
        }

        return _tempDestination;
    }
}
