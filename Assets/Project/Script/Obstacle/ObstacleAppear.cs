using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAppear : MonoBehaviour
{
    [SerializeField] private ObstacleLogic obsPref;
    private List<ObstacleLogic> obsList = new List<ObstacleLogic>();

    public void Spawn(Vector3 positionInWorld, Vector2Int root, RotateType currentRotate, List<Vector2Int> child)
    {
        ObstacleLogic obsLogic = Instantiate(obsPref, Vector3.zero, Quaternion.identity, transform);
        obsLogic.Spawn(positionInWorld + Vector3.up, root, currentRotate, child);
        obsList.Add(obsLogic);
    }
}
