using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Level List")]
    [SerializeField] private List<LevelDataSO> levelList;

    [SerializeField] private BoardAppear boardAppear;
    [SerializeField] private ObstacleAppear obstacleAppear;
    [SerializeField] private PlayerController playerController;
    private int currNumber = 0;
    public void LoadLevel(int levelNumber)
    {
        var level = levelList[levelNumber];
        var board = level.BoardData;
        GridManager.Instance.SetBoard(board);

        boardAppear.DrawBoard(board);

        var obstacleList = level.ObstacleList;
        foreach (var obstacle in obstacleList)
        {
            Vector3 position = boardAppear.GetWorldPosition(obstacle.positionInGrid.x, obstacle.positionInGrid.y);
            obstacleAppear.Spawn(position, obstacle.positionInGrid, obstacle.rotate, obstacle.data.Child);
        }
        GameManager.Instance.SetEndPos(levelList[levelNumber].GoatPosition);
        GameManager.Instance.SetPlayerPos(levelList[levelNumber].PlayerPosition);
        playerController.SetUpPlayer();
    }
}
