using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Level List")]
    public List<LevelDataSO> levelList;

    [SerializeField] private BoardAppear boardAppear;
    [SerializeField] private ObstacleAppear obstacleAppear;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GoatController goatController;
    private int currNumber = 0;
    public LevelDataSO currentLevel => levelList[currNumber];
    public void LoadLevel(int levelNumber)
    {
        currNumber = levelNumber;
        var level = levelList[levelNumber];
        var board = level.BoardData;
        GridManager.Instance.SetBoard(currentLevel.BoardData);

        boardAppear.DrawBoard(board);
        obstacleAppear.ClearObs();

        var obstacleList = level.ObstacleList;
        foreach (var obstacle in obstacleList)
        {
            Vector3 position = boardAppear.GetWorldPosition(obstacle.positionInGrid.x, obstacle.positionInGrid.y);
            obstacleAppear.Spawn(position, obstacle.positionInGrid, obstacle.rotate, obstacle.data.Child);
        }
        GameManager.Instance.SetEndPos(levelList[levelNumber].GoatPosition);
        GameManager.Instance.SetPlayerPos(levelList[levelNumber].PlayerPosition);
        goatController.SetUpGoat(currentLevel);
        playerController.SetUpPlayer(currentLevel);
    }
}
