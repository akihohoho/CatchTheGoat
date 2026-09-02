using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class BoardAppear : MonoBehaviour
{
    [SerializeField] BoardData boardData;
    private List<GameObject> boardList;
    [SerializeField] GameObject ground;

    private void Start()
    {
        boardList = new List<GameObject>();
        DrawBoard(boardData);
    }

    public void DrawBoard(BoardData board)
    {
        for (int x = 0; x < board.BoardSize.x; x++)
        {
            for (int y = 0; y < board.BoardSize.y; y++)
            {
                Instantiate(ground, GetWorldPosition(x, y), Quaternion.identity, transform);
            }
        }
    }

    public void DeleteBoard(BoardData board)
    {
        for(int i = boardList.Count - 1; i >= 0; i--)
        {
            Destroy(boardList[i]);
            boardList.RemoveAt(i);
        }
    }
    public Vector3 GetWorldPosition(int x, int y)
    {
        float posX = (x - (boardData.BoardSize.x - 1) / 2) * boardData.CellDistance.x;
        float posY = (y - (boardData.BoardSize.y - 1) / 2) * boardData.CellDistance.y;

        return new Vector3(posX, 0,  posY);
    }
}
