using DG.Tweening;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] LevelDataSO levelSo;
    [SerializeField] BoardAppear boardAppear;
    private Vector2Int currentGridPos;
    public bool isMoving = false;

    private List<Vector2Int> curOccupiedCells;

    public void SetUpPlayer()
    {
        currentGridPos = levelSo.PlayerPosition;
        gameObject.transform.position = boardAppear.GetWorldPosition((int)levelSo.PlayerPosition.x, (int)levelSo.PlayerPosition.y);

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
        int safecount = 0;

        while (safecount < 50)
        {
            safecount++;
            bool isBlocked = GridManager.Instance.IsOccupied(targetPos + step);
            if (isBlocked) break;

            targetPos += step;
        }

        if(targetPos == currentGridPos) return;

        currentGridPos = targetPos;
        isMoving = true;
        Vector3 targetWorldPos = boardAppear.GetWorldPosition(targetPos.x, targetPos.y);

        transform.DOMove(targetWorldPos, 0.2f).SetEase(Ease.Linear).OnComplete(() => isMoving = false);

    }
}
