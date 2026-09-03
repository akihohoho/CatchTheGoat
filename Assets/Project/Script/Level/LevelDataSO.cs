using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level Data", menuName = "ScriptableObject/Level")]
public class LevelDataSO : ScriptableObject
{
    [SerializeField] private int levelNumber;
    [SerializeField] private BoardData boardData;
    [SerializeField] private List<ObstacleModelData> obstacleList;

    public int LevelNumber => levelNumber;
    public List<ObstacleModelData> ObstacleList => obstacleList;
    public BoardData BoardData => boardData;
}
