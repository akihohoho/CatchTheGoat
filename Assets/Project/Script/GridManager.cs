using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private static GridManager instance;
    public static GridManager Instance => instance;
    [SerializeField] private BoardData boardData;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // Bắt buộc phải có để diệt bản sao lỗi khi chơi lại màn
        }
    }

    HashSet<Vector2Int> OccupiedCells = new HashSet<Vector2Int>();

    public void SetBoard(BoardData board)
    {
        boardData = board;
        ClearCells();
    }
    public void RegisterCells(List<Vector2Int> cells)
    {
        foreach (var cell in cells)
        {
            OccupiedCells.Add(cell);
        }
    }

    public void UnregisterCells(List<Vector2Int> cells)
    {
        foreach (var cell in cells)
        {
            OccupiedCells.Remove(cell);
        }
    }

    public bool IsOutOfBound(Vector2Int curPos)
    {
        if (curPos.x < 0 || curPos.y < 0) return true;
        if (curPos.x >= boardData.BoardSize.x || curPos.y >= boardData.BoardSize.y) return true;
        return false;
    }
    public void ClearCells()
    {
        OccupiedCells.Clear();
    }

    public bool IsOccupied(Vector2Int position)
    {
        if(IsOutOfBound(position)) return true;
        return OccupiedCells.Contains(position);
    }
}
