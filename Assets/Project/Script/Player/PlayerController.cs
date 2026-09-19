using DG.Tweening;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] BoardAppear boardAppear;
    [SerializeField] GameObject playerPref;
    private Vector2Int currentGridPos;
    public bool isMoving = false;

    public void SetUpPlayer(LevelDataSO levelSO)
    {
        currentGridPos = levelSO.PlayerPosition;
        GridManager.Instance.OccupiedCells.Add(currentGridPos);
        Vector3 startPos = boardAppear.GetWorldPosition(currentGridPos.x, currentGridPos.y);
        startPos.y = 1.5f;
        transform.position = startPos;
        Instantiate(playerPref, transform.position, Quaternion.identity, transform);
    }
    public void PlayerMovement(MoveDirection direction)
    {
        if (isMoving) return;
        Vector2Int step = direction switch
        {
            MoveDirection.up => Vector2Int.up,
            MoveDirection.left => Vector2Int.left,
            MoveDirection.right => Vector2Int.right,
            MoveDirection.down => Vector2Int.down,
            _=> Vector2Int.zero
        };

        Vector2Int targetPos = currentGridPos;
        bool isBlocked = false;
        while (!isBlocked)
        {
            isBlocked = GridManager.Instance.IsOccupied(targetPos + step);
            //Debug.Log(targetPos + " " + step);
            if (isBlocked) break;

            targetPos += step;
        }

        if(targetPos == currentGridPos) return;
        GridManager.Instance.OccupiedCells.Remove(currentGridPos);
        GridManager.Instance.OccupiedCells.Add(targetPos);

        currentGridPos = targetPos;
        isMoving = true;
        Vector3 targetWorldPos = boardAppear.GetWorldPosition(targetPos.x, targetPos.y);
        targetWorldPos.y = 1.5f;

        transform.DOMove(targetWorldPos, 0.2f).SetEase(Ease.Linear).OnComplete(() =>
        {
            isMoving = false;
            GameManager.Instance.SetPlayerPos(currentGridPos);
        });
    }
}
