using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private static GridManager instance;
    public static GridManager Instance => instance;

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

    public void ClearCells()
    {
        OccupiedCells.Clear();
    }

    public bool IsOccupied(Vector2Int position)
    {
        return OccupiedCells.Contains(position);
    }
}
